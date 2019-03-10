using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class Slider : Xamarin.Forms.Slider
    {
        public static readonly BindableProperty ColorProperty =
        BindableProperty.Create(nameof(Color),
         typeof(Color), typeof(Slider),
         Color.Default);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
    }
}
