using System.ComponentModel;
using Android.Graphics;
using Android.Text;
using Android.Views;
using Android.App;
using Android.Content;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using CustomXamarinControls;
using CustomXamarinControls.Droid;

[assembly: ExportRenderer(typeof(LabelStriked), typeof(LabelStrikedRenderer))]
namespace CustomXamarinControls.Droid
{
    public class LabelStrikedRenderer : LabelRenderer
    {
        public LabelStrikedRenderer(Context context) : base (context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //Control.Gravity = GravityFlags.CenterVertical | GravityFlags.Left;
                //Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                //Control.InputType |= InputTypes.TextFlagNoSuggestions;
                //Control.SetPadding(25, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);

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
            if (label?.IsStrikeThrough == true)
            {
                Control.PaintFlags |= PaintFlags.StrikeThruText;
            }
            else
            {
                Control.PaintFlags &= ~PaintFlags.StrikeThruText;
            }
        }
    }
}