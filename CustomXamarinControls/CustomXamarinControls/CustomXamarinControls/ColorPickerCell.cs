using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Settings;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Interfaces;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.ComponentModel;

namespace CustomXamarinControls
{
    public class ColorPickerCell : ViewCell
    {
        public static readonly BindableProperty TitleProperty
            = BindableProperty.Create(nameof(Title), typeof(string), typeof(ColorPickerCell), "", BindingMode.TwoWay,
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {

                    (bindable as ColorPickerCell).TitleLabel.Text = (string)newValue;

                });

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty
            = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(ColorPickerCell), "", BindingMode.TwoWay,
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {

                    (bindable as ColorPickerCell).ColorPick.Title = (string)newValue;

                });

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty StorageKeyProperty
            = BindableProperty.Create(nameof(StorageKey), typeof(string), typeof(ColorPickerCell), "", BindingMode.TwoWay,
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {

                    (bindable as ColorPickerCell).ColorPick.StorageKey = (string) newValue;

                });

        public string StorageKey
        {
            get { return (string)GetValue(StorageKeyProperty); }
            set { SetValue(StorageKeyProperty, value); }
        }

        public static readonly BindableProperty MessageProperty
            = BindableProperty.Create(nameof(Message), typeof(string), typeof(ColorPickerCell), "", BindingMode.TwoWay);

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command),typeof(Command), typeof(ColorPickerCell), null, BindingMode.TwoWay);

        public Command Command
        {
            get { return (Command)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        Color newColor;

        Label TitleLabel;
        ColorPicker ColorPick;
        RoundableBoxView ColorPreview;
        FlatButton Save;

        public ColorPickerCell()
        {
            Color color = Color.White;
            newColor = Color.FromHex(CrossSettings.Current.GetValueOrDefault(StorageKey, color.ToHex()));

            TitleLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start,
                WidthRequest = 90
            };         

            ColorPreview = new RoundableBoxView()
            {
                BackgroundColor = newColor,
                CornerRadius = 28,
                HeightRequest = 28,
                WidthRequest = 28,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            ColorPick = new ColorPicker()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 80
            };

            ColorPick.SelectedIndexChanged += SelectedItem;
            ColorPreview.PropertyChanged += ColorPreviewPropertyChanged;

            if (ColorPick.SelectedItem != null)
            {
                ColorPreview.IsVisible = true;
            }

            Save = new FlatButton()
            {
                Text = "Save",
                TextColor = Color.DodgerBlue,
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 60,
                IsVisible = false
            };

            Save.Clicked += SaveClicked;

            View = new StackLayout()
            {
                Children =
                {
                    TitleLabel,
                    ColorPreview,
                    ColorPick,
                    Save
                },

                Padding = new Thickness(18,0,18,0),
                Orientation = StackOrientation.Horizontal
            };
        }

        private void ColorPreviewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (nameof(ColorPreview.IsVisible).Equals(e.PropertyName))
            {
                var ColorPreviewTapped = new TapGestureRecognizer();
                ColorPreviewTapped.Tapped += OnColorPreviewTap;

                if (ColorPreview.IsVisible)
                {
                    
                    ColorPreview.GestureRecognizers.Add(ColorPreviewTapped);
                }
                else
                {
                    ColorPreview.GestureRecognizers.Remove(ColorPreviewTapped);
                }
            }
        }

        private async void OnColorPreviewTap(object sender, EventArgs e)
        {
            PopupPage Popup = new PopupPage()
            {
                BackgroundColor = Color.Transparent,
                Content = new Frame()
                {
                    BackgroundColor = newColor,
                    HeightRequest = 200,
                    WidthRequest = 200,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    CornerRadius = 50
                },
                Animation = new ScaleAnimation(),
                Padding = new Thickness(50, 40, 0, 0),
                CloseWhenBackgroundIsClicked = true
            };

            var Close = new TapGestureRecognizer();
            Close.Tapped += async (object s, EventArgs Ayer) => { await PopupNavigation.PopAsync(); };
            Popup.Content.GestureRecognizers.Add(Close);

            await PopupNavigation.PushAsync(Popup);
        }

        void SelectedItem(object sender, EventArgs e)
        {
            Color color = Color.FromHex(CrossSettings.Current.GetValueOrDefault(StorageKey, Color.White.ToHex()));

            if ((ColorPick.SelectedItem as ColorItem).Name != ColorPick.ViewModel.Colors.GetNameByColor(color))
            {
                Save.IsVisible = true;
                ColorPreview.IsVisible = true;
            }
            else
            {
                Save.IsVisible = false;
                ColorPreview.IsVisible = true;
            }

            if ((ColorPick.SelectedItem as ColorItem).Name == "Default")
            {
                newColor = Color.White;
                ColorPreview.BackgroundColor = newColor;
            }
            else
            {
                newColor = (ColorPick.SelectedItem as ColorItem).Color;
                ColorPreview.BackgroundColor = newColor;
            }
        }

        void SaveClicked(object sender, EventArgs e)
        {
            if ((ColorPick.SelectedItem as ColorItem).Name == "Default")
            {
                Color color = Color.White;
                CrossSettings.Current.AddOrUpdateValue(StorageKey, color.ToHex());
                CrossSettings.Current.Remove(StorageKey);
            }
            else
            {
                CrossSettings.Current.AddOrUpdateValue(StorageKey, ColorPick.ViewModel.SelectedColor.Hex);
            }

            MessagingCenter.Send(this, Message, newColor);
            Save.IsVisible = false;

            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }

        protected override void OnAppearing()
        {
            Color color = Color.FromHex(CrossSettings.Current.GetValueOrDefault(StorageKey, Color.White.ToHex()));

            ColorPick.SelectedItem = ColorPick.ViewModel.Colors.FirstOrDefault(x => x.Color == color);

            base.OnAppearing();
        }
    }

    public static class ExtensionMethods
    {
        public static TKey GetKeyByValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue Value)
        {
            return dictionary.FirstOrDefault(x => x.Value.ToString() == Value.ToString()).Key;
        }

        public static string ToHex(this Xamarin.Forms.Color color)
        {
            var red = (int)(color.R * 255);
            var green = (int)(color.G * 255);
            var blue = (int)(color.B * 255);
            var alpha = (int)(color.A * 255);
            var hex = $"#{alpha:X2}{red:X2}{green:X2}{blue:X2}";

            return hex;
        }
    }
}
