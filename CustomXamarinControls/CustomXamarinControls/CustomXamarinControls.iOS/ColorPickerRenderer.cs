using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomXamarinControls;
using CustomXamarinControls.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ColorPicker), typeof(ColorPickerRenderer))]
namespace CustomXamarinControls.iOS
{
    class ColorPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextAlignment = UITextAlignment.Center;
            }
        }
    }
}