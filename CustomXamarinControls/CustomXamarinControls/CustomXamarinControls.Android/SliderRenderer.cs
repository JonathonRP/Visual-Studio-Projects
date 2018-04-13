using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomXamarinControls.Slider), typeof(CustomXamarinControls.Droid.SliderRenderer))]
namespace CustomXamarinControls.Droid
{
    public class SliderRenderer : Xamarin.Forms.Platform.Android.SliderRenderer
    {
        private Slider slider;

        public SliderRenderer(Context context) : base(context)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Slider> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            slider = (Slider)Element;

            if (Control != null)
            {
                Control.ProgressDrawable.SetColorFilter(slider.Color.ToAndroid(), PorterDuff.Mode.SrcAtop);
                Control.Thumb.SetColorFilter(slider.Color.ToAndroid(), PorterDuff.Mode.Multiply);
            }
        }
    }
}