using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class CurrencyEntry : Entry
    {
        public bool ShouldReactToTextChange { get; set; }

        public double Decimal;

        protected override void OnPropertyChanged(string propertyName = null)
        {
            if (nameof(this.Text).Equals(propertyName))
            {
                if (double.TryParse(this.Text, out Decimal))
                {
                    if ((Decimal % 1) == 0)
                    {
                        this.Text = $"{Decimal:C0}";
                    }
                    else
                    {
                        this.Text = $"{Decimal:C}";
                    }
                }
            }

            base.OnPropertyChanged(propertyName);
        }
    }
}
