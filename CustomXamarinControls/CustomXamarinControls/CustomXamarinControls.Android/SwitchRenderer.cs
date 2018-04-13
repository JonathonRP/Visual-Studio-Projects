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
using Android.Support.V7.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomXamarinControls.Switch), typeof(CustomXamarinControls.Droid.SwitchRenderer))]
namespace CustomXamarinControls.Droid
{
    public class SwitchRenderer : Xamarin.Forms.Platform.Android.SwitchRenderer
    {
        private Switch @switch;

        public SwitchRenderer(Context context) : base (context)
        {

        }
        
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;

            @switch = (Switch)Element;

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean)
            {
                if (Control != null)
                {
                    if (Control.Checked)
                    {
                        Control.TrackDrawable.SetColorFilter(@switch.Color.ToAndroid(), PorterDuff.Mode.SrcAtop);
                        Control.ThumbDrawable.SetColorFilter(@switch.Color.ToAndroid(), PorterDuff.Mode.Multiply);
                    }
                    else
                    {
                        Control.TrackDrawable.ClearColorFilter();
                        Control.ThumbDrawable.SetColorFilter(Xamarin.Forms.Color.WhiteSmoke.ToAndroid(), PorterDuff.Mode.Multiply);
                    }
                    Control.CheckedChange += OnCheckedChange;
                }
                //Control.TrackDrawable.SetColorFilter(view.SwitchBGColor.ToAndroid(), PorterDuff.Mode.Multiply);  
            }
        }

        private void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (Control.Checked)
            {
                Control.TrackDrawable.SetColorFilter(@switch.Color.ToAndroid(), PorterDuff.Mode.SrcAtop);
                Control.ThumbDrawable.SetColorFilter(@switch.Color.ToAndroid(), PorterDuff.Mode.Multiply);
            }
            else
            {
                Control.TrackDrawable.ClearColorFilter();
                Control.ThumbDrawable.SetColorFilter(Xamarin.Forms.Color.WhiteSmoke.ToAndroid(), PorterDuff.Mode.Multiply);
            }

            Element.IsToggled = e.IsChecked;
        }
        protected override void Dispose(bool disposing)
        {
            Control.CheckedChange -= OnCheckedChange;
            base.Dispose(disposing);
        }
    }
}