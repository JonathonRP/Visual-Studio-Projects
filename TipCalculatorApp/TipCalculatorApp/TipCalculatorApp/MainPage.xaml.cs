using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TipCalculatorApp
{
	public partial class MainPage : ContentPage
	{
        private Label AppTitle;
        private Label Meal;
        private Label TipPercent;
        private Label Total;
        private Entry meal;
        private Entry tip_percent;
        private Button Calculate;

        private int count;

        public MainPage()
        {
            AppTitle = new Label
            {
                Text = "Tip Calculator",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Meal = new Label
            {
                Text = "Meal Amount:",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            TipPercent = new Label
            {
                Text = "Tip Percentage:",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            meal = new Entry
            {
                Placeholder = "Enter Meal Amount",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                TextColor = Color.Maroon,
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Center,
                Keyboard = Keyboard.Numeric
            };

            tip_percent = new Entry
            {
                Placeholder = "Enter Percentage of Tip",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                TextColor = Color.Maroon,
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Center,
                Keyboard = Keyboard.Numeric
            };

            Calculate = new Button
            {
                Text = "Calculate Tip",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.Fill
            };

            Total = new Label
            {
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.LawnGreen,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            StackLayout Labels = new StackLayout()
            {
                Children =
                {
                    Meal,
                    TipPercent
                },

                Padding = new Thickness(15, 7, 5, 0),
                Spacing = 27,
                VerticalOptions = LayoutOptions.Center
            };

            StackLayout Entries = new StackLayout()
            {
                Children =
                {
                    meal,
                    tip_percent
                },

                VerticalOptions = LayoutOptions.Center
            };

            Grid CalcLayout = new Grid()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,

                RowSpacing = 25
            };

            CalcLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Auto) });
            CalcLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Auto) });
            CalcLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            CalcLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            CalcLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            CalcLayout.Children.Add(Labels, 0, 0);
            CalcLayout.Children.Add(Entries, 1, 0);
            CalcLayout.Children.Add(Calculate, 1, 1);
            CalcLayout.Children.Add(Total, 1, 2);

            Grid.SetColumnSpan(Calculate, 2);
            Grid.SetColumnSpan(Total, 2);
            Grid.SetColumnSpan(Entries, 2);

            StackLayout Layout = new StackLayout()
            {
                Children =
                {
                    AppTitle,
                    CalcLayout
                },

                VerticalOptions = LayoutOptions.FillAndExpand
            };

            ScrollView ScrollLayout = new ScrollView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = Layout
            };

            Content = ScrollLayout;

            Calculate.Clicked += onButtonClicked;
            meal.TextChanged += CurrencyFormat;
            tip_percent.Unfocused += PercentFormat;
        }

        void CurrencyFormat(object sender, TextChangedEventArgs e)
        {
            if ( !(string.IsNullOrEmpty(meal.Text)) || !(string.IsNullOrWhiteSpace(meal.Text)))
            {
                if (double.TryParse(meal.Text, out double mealCostWithChange))
                {
                    if ((mealCostWithChange % 1) == 0)
                    {
                        meal.Text = $"{mealCostWithChange:C0}";
                    }
                    else
                    {
                        meal.Text = $"{mealCostWithChange:C}";
                    }
                }
            }
        }

        void PercentFormat(object sender, EventArgs e)
        {
            if ( !(string.IsNullOrEmpty(tip_percent.Text)) || !(string.IsNullOrWhiteSpace(tip_percent.Text)))
            {
                if (double.TryParse(tip_percent.Text, out double PercentageWithDecimal))
                {
                    if ((PercentageWithDecimal % 1) == 0)
                    {
                        tip_percent.Text = $"{PercentageWithDecimal / 100:P0}";
                    }
                    else
                    {
                        tip_percent.Text = $"{PercentageWithDecimal / 100:P}";
                    }
                }
            }
        }

        void onButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(meal.Text) || string.IsNullOrWhiteSpace(meal.Text))
            {
                count++;

                if (count > 1)
                {
                    meal.Text = "";
                    meal.PlaceholderColor = Color.Red;
                    meal.Placeholder = $"{meal.Placeholder}!";

                    if (string.IsNullOrEmpty(tip_percent.Text) || string.IsNullOrWhiteSpace(tip_percent.Text))
                    {
                        tip_percent.Text = "";
                        tip_percent.PlaceholderColor = Color.Red;
                        tip_percent.Placeholder = $"{tip_percent.Placeholder}!";
                    }
                }
            }
            else if (string.IsNullOrEmpty(tip_percent.Text) || string.IsNullOrWhiteSpace(tip_percent.Text))
            {
                count++;

                if (count > 1)
                {
                    tip_percent.Text = "";
                    tip_percent.PlaceholderColor = Color.Red;
                }
            }
            else
            {
                count = 0;

                meal.Placeholder = "Enter Meal Amount";
                tip_percent.Placeholder = "Enter Percentage of Tip";
                meal.PlaceholderColor = Color.Default;
                tip_percent.PlaceholderColor = Color.Default;

                if (double.TryParse(meal.Text.TrimStart('$'), out double mealCost))
                {
                    if (double.TryParse(tip_percent.Text.TrimEnd('%'), out double tipPercent))
                    {
                        double tip = mealCost * (tipPercent / 100);

                        Total.Text = $"{mealCost + tip:C}";
                    }
                    else
                    {
                        tip_percent.Text = "";
                        tip_percent.Placeholder = "Cant Parse tip percent";
                        tip_percent.PlaceholderColor = Color.Red;
                        return;
                    }
                }
                else
                {
                    meal.Text = "";
                    meal.Placeholder = "Cant Parse meal cost";
                    meal.PlaceholderColor = Color.Red;
                    return;
                }
            }
        }
	}
}
