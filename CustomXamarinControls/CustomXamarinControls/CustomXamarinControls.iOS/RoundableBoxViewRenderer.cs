using CustomXamarinControls;
using CustomXamarinControls.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundableBoxView), typeof(RoundableBoxViewRenderer))]
namespace CustomXamarinControls.iOS
{
    class RoundableBoxViewRenderer : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if (Element == null) return;
            Layer.MasksToBounds = true;
            Layer.CornerRadius = (float)((RoundableBoxView)this.Element).CornerRadius / 2.0f;
        }
    }
}
