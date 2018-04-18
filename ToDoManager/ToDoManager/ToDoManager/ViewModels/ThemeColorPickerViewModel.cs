using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Prism.Commands;
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

        Color Primary = Color.FromHex("#9121F3");
        Color Accent = Color.FromHex("#FF07C5");

        public DelegateCommand Close => new DelegateCommand(OnClose);
        public DelegateCommand Reset => new DelegateCommand(OnReset);

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

        public ThemeColorPickerViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        async void SetNewColor()
        {
            Color = Color.FromHsla(Hue, Saturation, Luminosity);
            App.Current.Resources[$"{Name}"] = Color;

            App.Current.Properties[$"{Name}"] = Color;
            await App.Current.SavePropertiesAsync();
        }

        public async void OnClose()
        {
            await NavigationService.ClearPopupStackAsync();
        }

        public async void OnReset()
        {
            App.Current.Resources["Primary"] = Primary;
            App.Current.Properties["Primary"] = Primary;

            App.Current.Resources["Accent"] = Accent;
            App.Current.Properties["Accent"] = Accent;

            await App.Current.SavePropertiesAsync();
            await NavigationService.ClearPopupStackAsync();
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Color"))
            {
                Color = (Color)parameters["Color"];
            }

            if (parameters.ContainsKey("Name"))
            {
                Name = (string)parameters["Name"];
                ColorName = $"{(string)parameters["Name"]} Color";
            }
        }
    }
}
