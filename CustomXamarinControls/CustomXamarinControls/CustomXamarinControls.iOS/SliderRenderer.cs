using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomXamarinControls.Slider), typeof(CustomXamarinControls.iOS.SliderRenderer))]
namespace CustomXamarinControls.iOS
{
    public class SliderRenderer : Xamarin.Forms.Platform.iOS.SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Slider> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            Slider slider = Element as Slider;

            UISlider iSlider = new UISlider
            {
                ThumbTintColor = slider.Color.ToUIColor(),
                MinimumTrackTintColor = slider.Color.ToUIColor()
            };

            SetNativeControl(iSlider);
        }
    }
}