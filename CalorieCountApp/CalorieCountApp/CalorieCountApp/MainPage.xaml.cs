using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CustomXamarinControls;
using System.Runtime.CompilerServices;
using Plugin.Settings;

namespace CalorieCountApp
{
	public partial class MainPage : ContentPage
	{
        private Image Logo;
        private Label AllowedCalories;
        private Label AppTitle;
        private FlatButton Settings;
        private Entry Food;
        private Entry Calories;
        private Button Add;
        private Button reset;
        private int click = 0;
        private double calories = 0;

        public MainPage()
		{
            Logo = new Image()
            {
                Source = "generic_yoga_logo.png",
                HeightRequest = 150,
                WidthRequest = 150,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };

            AppTitle = new Label()
            {
                Text = "Calorie Counting App",
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            Settings = new FlatButton()
            {
                Text = "Settings",
                TextColor = Color.DodgerBlue,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Start
            };

            AllowedCalories = new Label()
            {
                Text = $"Available: {CrossSettings.Current.GetValueOrDefault("maxCalories","2000")}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Fill
            };

            Food = new Entry()
            {
                Placeholder = "Enter Food",
                Keyboard = Keyboard.Text,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Calories = new Entry()
            {
                Placeholder = "Enter Calories",
                Keyboard = Keyboard.Numeric,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Add = new Button()
            {
                Text = "Add",
                BackgroundColor = Color.LightGreen,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            reset = new Button()
            {
                Text = "Reset",
                BackgroundColor = Color.LightSkyBlue,
                HorizontalOptions = LayoutOptions.End
            };

            StackLayout SettingsLayout = new StackLayout()
            {
                Children =
                {
                    Settings
                },

                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
            };

            StackLayout LogoStack = new StackLayout()
            {
                Children =
                {
                    Logo,
                    AppTitle
                },

                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                Padding = new Thickness(0,-69,0,20)
            };

            StackLayout EntryStack = new StackLayout()
            {
                Children =
                {
                    Food,
                    Calories
                },

                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, 20, 0, 0)
            };

            StackLayout ButtonStack = new StackLayout()
            {
                Children =
                {
                    Add,
                    reset
                },

                Orientation = StackOrientation.Horizontal
            };

            StackLayout stack = new StackLayout()
            {
                Children =
                {
                    SettingsLayout,
                    LogoStack,
                    AllowedCalories,
                    EntryStack,
                    ButtonStack
                },

                Padding = new Thickness(3,5,3,0)
            };

            Content = stack;

            MessagingCenter.Subscribe<ColorPickerCell, Color>(this, "ChangeBackColor", (sender, arg) => {
                // do something whenever the "ChangeBackColor" message is sent
                this.BackgroundColor = arg;
            });

            MessagingCenter.Subscribe<ColorPickerCell, Color>(this, "ChangeTextColor", (sender, arg) => {
                // do something whenever the "ChangeTextColor" message is sent
                this.AllowedCalories.TextColor = arg;
                this.AppTitle.TextColor = arg;
                this.Food.TextColor = arg;
                this.Food.PlaceholderColor = arg;
                this.Calories.TextColor = arg;
                this.Calories.PlaceholderColor = arg;
            });

            MessagingCenter.Subscribe<ColorPickerCell, Color>(this, "ChangeCaloriesColor", (sender, arg) => {
                // do something whenever the "ChangeTextColor" message is sent
                this.AllowedCalories.TextColor = arg;
            });

            MessagingCenter.Subscribe<SettingsEntryCell, string>(this, "NewMaxCalories", (sender, arg) => {
                this.AllowedCalories.Text = $"Available: {arg}";
            });

            Add.Clicked += AddButtonClicked;
            reset.Clicked += ResetButtonClicked;
            Settings.Clicked += SettingsButtonClicked;
            this.Appearing += PageIsAppearing;
        }

        private void PageIsAppearing(object sender, EventArgs e)
        {
            string White = Color.White.ToHex();
            string Default = Color.Default.ToHex();

            this.BackgroundColor = Color.FromHex(CrossSettings.Current.GetValueOrDefault("backColor", White));
            this.AppTitle.TextColor = Color.FromHex(CrossSettings.Current.GetValueOrDefault("textColor", Default));
            this.AllowedCalories.TextColor = Color.FromHex(CrossSettings.Current.GetValueOrDefault("textColor", Default));
            this.Food.TextColor = Color.FromHex(CrossSettings.Current.GetValueOrDefault("textColor", Default));
            this.Food.PlaceholderColor = Color.FromHex(CrossSettings.Current.GetValueOrDefault("textColor", Default));
            this.Calories.TextColor = Color.FromHex(CrossSettings.Current.GetValueOrDefault("textColor", Default));
            this.Calories.PlaceholderColor = Color.FromHex(CrossSettings.Current.GetValueOrDefault("textColor", Default));

            this.AllowedCalories.Text = $"Available: {CrossSettings.Current.GetValueOrDefault("maxCalories", "2000")}";

            CrossSettings.Current.Remove("CaloriesColor");

            if (CrossSettings.Current.GetValueOrDefault("caloriesColor", null) != null)
            {
                this.AllowedCalories.TextColor = Color.FromHex(CrossSettings.Current.GetValueOrDefault("caloriesColor", Default));
            }

            if (((BackgroundColor.R * 299) + (BackgroundColor.G * 587) + (BackgroundColor.B * 114) / 100) < 500)
            {
                if (AppTitle.TextColor.Equals(Color.Default))
                {
                    AppTitle.TextColor = Color.White;
                }

                if (AllowedCalories.TextColor.Equals(Color.Default))
                {
                    AllowedCalories.TextColor = Color.White;
                }

                if (Food.TextColor.Equals(Color.Default))
                {
                    Food.TextColor = Color.White;
                }

                if (Food.PlaceholderColor.Equals(Color.Default))
                {
                    Food.PlaceholderColor = Color.White;
                }

                if (Calories.TextColor.Equals(Color.Default))
                {
                    Calories.TextColor = Color.White;
                }

                if (Calories.PlaceholderColor.Equals(Color.Default))
                {
                    Calories.PlaceholderColor = Color.White;
                }
            }
            else
            {
                if (AppTitle.TextColor.Equals(Color.Default))
                {
                    AppTitle.TextColor = Color.Default;
                }

                if (AllowedCalories.TextColor.Equals(Color.Default))
                {
                    AllowedCalories.TextColor = Color.Default;
                }

                if (Food.TextColor.Equals(Color.Default))
                {
                    Food.TextColor = Color.Default;
                }

                if (Food.PlaceholderColor.Equals(Color.Default))
                {
                    Food.PlaceholderColor = Color.Default;
                }

                if (Calories.TextColor.Equals(Color.Default))
                {
                    Calories.TextColor = Color.Default;
                }

                if (Calories.PlaceholderColor.Equals(Color.Default))
                {
                    Calories.PlaceholderColor = Color.Default;
                }
            }
        }

        private void SettingsButtonClicked(object sender, EventArgs e)
        {
            SettingsPageCall();
        }

        private void ResetButtonClicked(object sender, EventArgs e)
        {
            Reset();
        }

        private void AddButtonClicked(object sender, EventArgs e)
        {
            if ( (!(string.IsNullOrEmpty(Food.Text)) || !(string.IsNullOrWhiteSpace(Food.Text)) ) && (!(string.IsNullOrWhiteSpace(Calories.Text)) || !(string.IsNullOrEmpty(Calories.Text)) ))
            {
                if (double.TryParse(Calories.Text, out double caloriesNum))
                {
                    if (click == 0 || calories == 0)
                    {
                        calories = double.Parse(CrossSettings.Current.GetValueOrDefault("maxCalories", "2000")) - caloriesNum;
                    }
                    else
                    {
                        calories = calories - caloriesNum;
                    }
                }
                else
                {
                    Calories.Text = string.Empty;
                    Calories.Placeholder = $"{Calories.Placeholder}!";
                    Calories.PlaceholderColor = Color.Red;
                    return;
                }

                this.OnAppearing();
                Calories.Placeholder = "Enter Calories";
                AllowedCalories.Text = $@"{calories} are left for today";
                click++;
            }
            else
            {
                return;
            }
        }

        private void Reset()
        {
            calories = 0;
            this.OnAppearing();
            AllowedCalories.Text = $"Available: {CrossSettings.Current.GetValueOrDefault("maxCalories", "2000")}";
            Food.Text = string.Empty;
            Calories.Placeholder = "Enter Calories";
            Calories.Text = string.Empty;
        }

        private async void SettingsPageCall()
        {
            NavigationPage settingPage = new NavigationPage(new SettingsPage());
            await Navigation.PushModalAsync(settingPage);
        }
    }
}
