using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomXamarinControls;
using CustomXamarinControls.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(FlatButton), typeof(FlatButtonRenderer))]
namespace CustomXamarinControls.Droid
{
    public class FlatButtonRenderer : Xamarin.Forms.Platform.Android.ButtonRenderer
    {
        public FlatButtonRenderer(Context context) : base(context)
        {

        }

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

            if (Control != null)
            {
                Control.Elevation = 0;
            }

            SetTextAlignment();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == FlatButton.HorizontalTextAlignmentProperty.PropertyName)
            {
                SetTextAlignment();
                Control.SetPadding(0, 0, 0, 0);
                Control.SetPaddingRelative(0, 0, 0, 0);
            }
        }

        public void SetTextAlignment()
        {
            Control.Gravity = Element.HorizontalTextAlignment.ToHorizontalGravityFlags();
        }
    }

    public static class AlignmentHelper
    {
        public static GravityFlags ToHorizontalGravityFlags(this Xamarin.Forms.TextAlignment alignment)
        {
            if (alignment == Xamarin.Forms.TextAlignment.Center)
                return GravityFlags.AxisSpecified;
            return alignment == Xamarin.Forms.TextAlignment.End ? GravityFlags.Right : GravityFlags.Left;
        }
    }
}