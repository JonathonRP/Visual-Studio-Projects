using System.ComponentModel;
using CoreGraphics;
using Foundation;

using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using CustomXamarinControls;
using CustomXamarinControls.iOS;

[assembly: ExportRenderer(typeof(LabelStriked), typeof(LabelStrikedRenderer))]
namespace CustomXamarinControls.iOS
{
    public class LabelStrikedRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //Control.BorderStyle = UITextBorderStyle.None;
                //Control.BackgroundColor = UIColor.Clear;
                //Control.TintColor = UIColor.White;
                //Control.LeftView = new UIView(new CGRect(0, 0, 15, 10));
                //Control.LeftViewMode = UITextFieldViewMode.Always;
                UpdateStrikeThrough(e.NewElement as LabelStriked);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(LabelStriked.IsStrikeThrough))
            {
                UpdateStrikeThrough(sender as LabelStriked);
            }
        }

        private void UpdateStrikeThrough(LabelStriked label)
        {
            var text = new NSMutableAttributedString(Control.AttributedText);
            text.SetAttributes(new UIStringAttributes
            {
                StrikethroughStyle = label?.IsStrikeThrough == true ? NSUnderlineStyle.Single : NSUnderlineStyle.None
            }, new NSRange(0, text.Length));
            Control.AttributedText = text;
        }
    }
}