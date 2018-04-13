using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class LabelStriked : Label
    {
        public static readonly BindableProperty IsStrikeThroughProperty = BindableProperty.Create(nameof(IsStrikeThrough), typeof(bool), typeof(LabelStriked), false);

        public bool IsStrikeThrough
        {
            get
            {
                return (bool)GetValue(IsStrikeThroughProperty);
            }
            set
            {
                SetValue(IsStrikeThroughProperty, value);
            }
        }
    }
}
