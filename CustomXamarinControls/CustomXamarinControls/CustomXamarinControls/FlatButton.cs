using CustomXamarinControls;
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class FlatButton : Button
    {
        public static BindableProperty HorizontalTextAlignmentProperty = 
            BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(FlatButton), TextAlignment.Center, BindingMode.TwoWay);

        public TextAlignment HorizontalTextAlignment
        {
            get
            {
                return (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
            }
            set
            {
                SetValue(HorizontalTextAlignmentProperty, value);
            }
        }
    }
}
