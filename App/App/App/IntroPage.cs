using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App
{
	// inherits from ContentPage to load into MainPage property of -> App.axml.cs
	public class IntroPage : ContentPage
	{
        private Button button1;
        private Label l1;
        private Label l2;
        private Entry Textbox;

        private StackLayout LabelLayout;
        private StackLayout TextLayout;
        private StackLayout ButtonLayout;
        private StackLayout layout;

        private int count = 0;

        public IntroPage()
        {
            l1 = new Label {
                Text = "Welcome User!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.PaleVioletRed,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            l2 = new Label
            {
                Text = "Enter Name!",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                IsVisible = false
            };

            button1 = new Button {
                Text = "Click Me!",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Textbox = new Entry {
                Placeholder = "Enter Name",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Keyboard = Keyboard.Text
            };

            button1.Clicked += onButtonClicked;

            LabelLayout = new StackLayout
            {
                Children =
                {
                    l1
                },

                Padding = new Thickness(0, 40, 0, 20)
            };

            TextLayout = new StackLayout
            {
                Children =
                {
                    Textbox,
                    l2
                },

                Padding = new Thickness(0, 40, 0, 20)
            };

            ButtonLayout = new StackLayout
            {
                Children =
                {
                    button1
                },

                Padding = new Thickness(0, 90, 0, 10)
            };

            layout = new StackLayout()
            {
                Children =
                {
                    LabelLayout,
                    TextLayout,
                    ButtonLayout
                },

                VerticalOptions = LayoutOptions.Center
            };

            Content =  layout;
	}

        void onButtonClicked(object sender, EventArgs e)
        {
	    // if textbox dosn't have a value typed in it, encluding spaces
            if (string.IsNullOrEmpty(Textbox.Text) || string.IsNullOrWhiteSpace(Textbox.Text))
            {
                count++;
		//only show l2 {second label: error message} if button clicked more than once
                if (count > 1)
                {
                    l2.IsVisible = true;
                }

                button1.Text = "Click Me!";
                l1.Text = $"Welcome User!";
                l1.TextColor = Color.PaleVioletRed;
            }
            else
            {
                count = 0;

                l2.IsVisible = false;
                button1.Text = "You Clicked Me!";
                l1.Text = $"Welcome {Textbox.Text}!";
                l1.TextColor = Color.BlueViolet;
            }
        }
	}
}
