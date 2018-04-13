using CustomXamarinControls;
using CustomXamarinControls.iOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FlatButton), typeof(FlatButtonRenderer))]
namespace CustomXamarinControls.iOS
{
    class FlatButtonRenderer : ButtonRenderer
    {
        public new FlatButton Element
        {
            get
            {
                return (FlatButton)base.Element;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            SetTextAlignment();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == FlatButton.HorizontalTextAlignmentProperty.PropertyName)
            {
                SetTextAlignment();
            }
        }

        public void SetTextAlignment()
        {
            Control.HorizontalAlignment = Element.HorizontalTextAlignment.ToHorizontalFlags();
        }
    }

    public static class AlignmentHelper
    {
        public static UIKit.UIControlContentHorizontalAlignment ToHorizontalFlags(this Xamarin.Forms.TextAlignment alignment)
        {
            if (alignment == Xamarin.Forms.TextAlignment.Center)
                return UIKit.UIControlContentHorizontalAlignment.Center;
            return alignment == Xamarin.Forms.TextAlignment.End ? UIKit.UIControlContentHorizontalAlignment.Right : UIKit.UIControlContentHorizontalAlignment.Left;
        }
    }
}
