using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomXamarinControls.Switch), typeof(CustomXamarinControls.iOS.SwitchRenderer))]
namespace CustomXamarinControls.iOS
{
    class SwitchRenderer : Xamarin.Forms.Platform.iOS.SwitchRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null) return;

            Switch @switch = Element as Switch;

            UISwitch iSwitch = new UISwitch();

            iSwitch.OnTintColor = @switch.Color.ToUIColor();

            SetNativeControl(iSwitch);
        }
    }
}
