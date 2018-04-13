using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class TableView : Xamarin.Forms.TableView
    {
        public static BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(TableView), Color.Accent);

        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        public TableView()
        {

        }
    }
}
