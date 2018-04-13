using CoreGraphics;
using CustomXamarinControls;
using CustomXamarinControls.iOS;
using Foundation;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CheckBox), typeof(CheckBoxRenderer))]
namespace CustomXamarinControls.iOS
{
    class CheckBoxRenderer : ViewRenderer<CheckBox, CheckBoxView>
    {
        private UIColor defaultTextColor;

        /// <summary>
        /// Handles the Element Changed event
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<CheckBox> e)
        {
            base.OnElementChanged(e);

            if (Element == null) return;

            BackgroundColor = Element.BackgroundColor.ToUIColor();
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var checkBox = new CheckBoxView(Bounds);
                    checkBox.TouchUpInside += (s, args) => Element.Checked = Control.Checked;
                    defaultTextColor = checkBox.TitleColor(UIControlState.Normal);
                    SetNativeControl(checkBox);
                }
                Control.LineBreakMode = UILineBreakMode.CharacterWrap;
                Control.VerticalAlignment = UIControlContentVerticalAlignment.Top;
                Control.CheckedTitle = string.IsNullOrEmpty(e.NewElement.CheckedText) ? e.NewElement.DefaultText : e.NewElement.CheckedText;
                Control.UncheckedTitle = string.IsNullOrEmpty(e.NewElement.UncheckedText) ? e.NewElement.DefaultText : e.NewElement.UncheckedText;
                Control.Checked = e.NewElement.Checked;
                
                UpdateTextColor();
            }

            Control.Frame = Frame;
            Control.Bounds = Bounds;

            UpdateFont();
        }

        /// <summary>
        /// Resizes the text.
        /// </summary>
        private void ResizeText()
        {
            if (Element == null)
                return;

            var text = Element.Checked ? string.IsNullOrEmpty(Element.CheckedText) ? Element.DefaultText : Element.CheckedText :
                string.IsNullOrEmpty(Element.UncheckedText) ? Element.DefaultText : Element.UncheckedText;

            var bounds = Control.Bounds;

            var width = Control.TitleLabel.Bounds.Width;

            var height = text.StringHeight(Control.Font, width);

            var minHeight = string.Empty.StringHeight(Control.Font, width);

            var requiredLines = Math.Round(height / minHeight, MidpointRounding.AwayFromZero);

            var supportedLines = Math.Round(bounds.Height / minHeight, MidpointRounding.ToEven);

            if (supportedLines != requiredLines)
            {
                bounds.Height += (float)(minHeight * (requiredLines - supportedLines));
                Control.Bounds = bounds;
                Element.HeightRequest = bounds.Height;
            }
        }

        /// <summary>
        /// Draws the specified rect.
        /// </summary>
        /// <param name="rect">The rect.</param>
        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);
            ResizeText();
        }

        /// <summary>
        /// Updates the font.
        /// </summary>
        private void UpdateFont()
        {
            if (!string.IsNullOrEmpty(Element.FontName))
            {
                var font = UIFont.FromName(Element.FontName, (Element.FontSize > 0) ? (float)Element.FontSize : 12.0f);
                if (font != null)
                {
                    Control.Font = font;
                }
            }
            else if (Element.FontSize > 0)
            {
                var font = UIFont.FromName(Control.Font.Name, (float)Element.FontSize);
                if (font != null)
                {
                    Control.Font = font;
                }
            }
        }

        private void UpdateTextColor()
        {
            Control.SetTitleColor(Element.TextColor.ToUIColorOrDefault(defaultTextColor), UIControlState.Normal);
            Control.SetTitleColor(Element.TextColor.ToUIColorOrDefault(defaultTextColor), UIControlState.Selected);
        }

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    break;
                case "TextColor":
                    UpdateTextColor();
                    break;
                case "CheckedText":
                    Control.CheckedTitle = string.IsNullOrEmpty(Element.CheckedText) ? Element.DefaultText : Element.CheckedText;
                    break;
                case "UncheckedText":
                    Control.UncheckedTitle = string.IsNullOrEmpty(Element.UncheckedText) ? Element.DefaultText : Element.UncheckedText;
                    break;
                case "FontSize":
                    UpdateFont();
                    break;
                case "FontName":
                    UpdateFont();
                    break;
                case "Element":
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("Property change for {0} has not been implemented.", e.PropertyName);
                    return;
            }
        }
    }

    /// <summary>
    /// Extension class for Colors.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts the UIColor to a Xamarin Color object.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="defaultColor">The default color.</param>
        /// <returns>UIColor.</returns>
        public static UIColor ToUIColorOrDefault(this Xamarin.Forms.Color color, UIColor defaultColor)
        {
            if (color == Xamarin.Forms.Color.Default)
                return defaultColor;

            return color.ToUIColor();
        }
    }

    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Gets the height of a string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="width">The width.</param>
        /// <returns>nfloat.</returns>
        public static nfloat StringHeight(this string text, UIFont font, nfloat width)
        {
            return text.StringRect(font, width).Height;
        }

        /// <summary>
        /// To the native string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>NSString.</returns>
        public static NSString ToNativeString(this string text)
        {
            return new NSString(text);
        }

        /// <summary>
        /// Gets the rectangle of a string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="width">The width.</param>
        /// <returns>CGRect.</returns>
        public static CGRect StringRect(this string text, UIFont font, nfloat width)
        {
            return text.ToNativeString().GetBoundingRect(
                new CGSize(width, nfloat.MaxValue),
                NSStringDrawingOptions.OneShot,//.UsesFontLeading | NSStringDrawingOptions.UsesLineFragmentOrigin,
                new UIStringAttributes { Font = font },
                null);
        }

        /// <summary>
        /// Strings the size.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns>CGSize.</returns>
        public static CGSize StringSize(this string text, UIFont font)
        {
            return text.ToNativeString().GetSizeUsingAttributes(new UIStringAttributes { Font = font });
        }
    }
}
