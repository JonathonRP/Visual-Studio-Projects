using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using CustomXamarinControls;

namespace PlayGroundTestingApp
{
	public partial class MainPage : ContentPage
	{
        private Label PageTitle;
        private CurrencyEntry MealAmount;
        private PercentEntry Tip;
        private Button Clicky;

		public MainPage()
		{
            PageTitle = new Label()
            {
                Text = "Formatted Entry Text",
                HorizontalTextAlignment = TextAlignment.Center
            };

            MealAmount = new CurrencyEntry()
            {
                Placeholder = "Ente Meal Amount",
                HorizontalTextAlignment = TextAlignment.Center,
                Keyboard = Keyboard.Numeric
            };

            Tip = new PercentEntry()
            {
                Placeholder = "Enter Tip Percent",
                HorizontalTextAlignment = TextAlignment.Center,
                Keyboard = Keyboard.Numeric
            };

            Clicky = new Button()
            {
                Text = "What's My Total?"
            };

            //Amount.TextChanged += TextboxFormat;
            Clicky.Clicked += ClickyClick;

            StackLayout layout = new StackLayout()
            {
                Children =
                {
                    PageTitle,
                    MealAmount,
                    Tip,
                    Clicky
                },

                VerticalOptions = LayoutOptions.Center
            };

            Content = layout;
		}

        private void TextboxFormat(object sender, TextChangedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(MealAmount.Text)) || !(string.IsNullOrWhiteSpace(MealAmount.Text)))
            {
                if (double.TryParse(MealAmount.Text, out double Decimal))
                {
                    if ((Decimal % 1) == 0)
                    {
                        MealAmount.Text = $"{Decimal:C0}";
                    }
                    else
                    {
                        MealAmount.Text = $"{Decimal:C}";
                    }
                }
            }
        }

        private void ClickyClick(object sender, EventArgs e)
        {
            DisplayTotal();
        }

        private async void DisplayTotal()
        {
            var detailPage = new DetailPage
            {
                BindingContext = new { Amount = $"{MealAmount.Text}", TipPercent = $"+ {Tip.Text}",
                                        Total = $"Total: {MealAmount.Decimal + (MealAmount.Decimal * Tip.Decimal /100):C}" }
            };

            await Navigation.PushModalAsync(detailPage);
        }
	}
}
