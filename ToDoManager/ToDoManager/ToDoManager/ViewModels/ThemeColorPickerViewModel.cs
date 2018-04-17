using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Prism.Navigation;
using Xamarin.Forms;

namespace ToDoManager.ViewModels
{
    public class ThemeColorPickerViewModel : BaseViewModel
    {
        double hue, saturation, luminosity;
        Color color;
        string name;
        string color_name;

        public double Hue
        {
            set
            {
                if (hue != value)
                {
                    hue = value;
                    RaisePropertyChanged("Hue");
                    SetNewColor();
                }
            }
            get
            {
                return hue;
            }
        }

        public double Saturation
        {
            set
            {
                if (saturation != value)
                {
                    saturation = value;
                    RaisePropertyChanged("Saturation");
                    SetNewColor();
                }
            }
            get
            {
                return saturation;
            }
        }

        public double Luminosity
        {
            set
            {
                if (luminosity != value)
                {
                    luminosity = value;
                    RaisePropertyChanged("Luminosity");
                    SetNewColor();
                }
            }
            get
            {
                return luminosity;
            }
        }

        public Color Color
        {
            set
            {
                if (color != value)
                {
                    color = value;
                    RaisePropertyChanged("Color");

                    Hue = value.Hue;
                    Saturation = value.Saturation;
                    Luminosity = value.Luminosity;
                }
            }
            get
            {
                return color;
            }
        }

        public string Name
        {
            get { return name; }
            set {

                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }

            }
        }

        public string ColorName
        {
            get { return color_name; }
            set
            {

                if (color_name != value)
                {
                    color_name = value;
                    RaisePropertyChanged("ColorName");
                }

            }
        }

        async void SetNewColor()
        {
            Color = Color.FromHsla(Hue, Saturation, Luminosity);
            App.Current.Resources[Name] = Color;

            App.Current.Properties[Name] = Color;
            await App.Current.SavePropertiesAsync();
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Color"))
            {
                Color = (Color)parameters["Color"];
                Name = (string)parameters["Label"];
                ColorName = $"{(string)parameters["Label"]} Color";
            }
        }
    }
}
