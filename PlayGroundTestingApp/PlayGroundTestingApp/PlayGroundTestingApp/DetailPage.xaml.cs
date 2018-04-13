using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Platform;
using Xamarin.Forms.Xaml;

using PlayGroundTestingApp;
using CustomXamarinControls;

namespace PlayGroundTestingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        private Label MealAmount;
        private Label Tip;
        private Label Total;
        private FlatButton Dismiss;

        private double mealAmount;
        private double tip;

        public DetailPage()
        {
            MealAmount = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            MealAmount.SetBinding(Label.TextProperty, "Amount");

            Tip = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            Tip.SetBinding(Label.TextProperty, "TipPercent");

            double.TryParse(MealAmount.GetValue(Label.TextColorProperty).ToString(), out mealAmount);
            double.TryParse(Tip.GetValue(Label.TextColorProperty).ToString(), out tip);

            Total = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            Total.SetBinding(Label.TextProperty, "Total");

            Dismiss = new FlatButton()
            {
                Text = "Dismiss",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            Content = new StackLayout
            {
                Children = {
                    MealAmount,
                    Tip,
                    Total,
                    Dismiss
                },

                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Dismiss.Clicked += OnDismissClicked;
        }

        private void OnDismissClicked(object sender, EventArgs e)
        {
            GoBack();
        }

        private async void GoBack()
        {
            await Navigation.PopModalAsync();
        }
    }
}