using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class Switch : Xamarin.Forms.Switch
    {
        public static readonly BindableProperty ColorProperty =
        BindableProperty.Create(nameof(Color),
         typeof(Color), typeof(Switch),
         Color.Default);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
    }
}
