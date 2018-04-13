using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Settings;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace CustomXamarinControls
{
    public class SettingsEntryCell : ViewCell
    {
        public static readonly BindableProperty TitleProperty
            = BindableProperty.Create(nameof(Title), typeof(string), typeof(ColorPickerCell), "", BindingMode.TwoWay,
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {

                    (bindable as SettingsEntryCell).TitleLable.Text = (string)newValue;

                });

        public static readonly BindableProperty PlaceholderProperty
            = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(SettingsEntryCell), "",
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {

                    (bindable as SettingsEntryCell).MaxCalories.Placeholder = (string)newValue;

                });

        public static readonly BindableProperty StorageKeyProperty
            = BindableProperty.Create(nameof(StorageKey), typeof(string), typeof(SettingsEntryCell), "",
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {

                    (bindable as SettingsEntryCell).MaxCalories.Text 
                        = CrossSettings.Current.GetValueOrDefault((string)newValue, null);
                });

        public static readonly BindableProperty MessageProperty
            = BindableProperty.Create(nameof(Message), typeof(string), typeof(SettingsEntryCell), "");

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public string StorageKey
        {
            get { return (string)GetValue(StorageKeyProperty); }
            set { SetValue(StorageKeyProperty, value); }
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(Command), typeof(ColorPickerCell), null, BindingMode.TwoWay);

        public Command Command
        {
            get { return (Command)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        Label TitleLable;
        Entry MaxCalories;
        FlatButton Save;

        public SettingsEntryCell()
        {
            TitleLable = new Label()
            {
                VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            MaxCalories = new Entry()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Keyboard = Keyboard.Numeric,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 200
            };

            MaxCalories.TextChanged += TextChanged;

            Save = new FlatButton()
            {
                Text = "Save",
                TextColor = Color.DodgerBlue,
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = 60,
                IsVisible = false
            };

            Save.Clicked += SaveClicked;

            View = new StackLayout()
            {
                Children =
                {
                    TitleLable,
                    MaxCalories,
                    Save
                },

                Orientation = StackOrientation.Horizontal
            };
        }

        void TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(MaxCalories.Text, out double Num) && MaxCalories.Text != CrossSettings.Current.GetValueOrDefault(StorageKey, null))
            {
                Save.IsVisible = true;
            }
            else
            {
                Save.IsVisible = false;
            }
        }

        void SaveClicked(object sender, EventArgs e)
        {
            if (MaxCalories.Text == null)
            {
                CrossSettings.Current.AddOrUpdateValue(StorageKey, null);
                CrossSettings.Current.Remove(StorageKey);
            }
            else
            {
                CrossSettings.Current.AddOrUpdateValue(StorageKey, MaxCalories.Text);
            }

            MessagingCenter.Send(this, Message, MaxCalories.Text);
            Save.IsVisible = false;

            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }

        //protected override void OnPropertyChanged(string propertyName = null)
        //{
        //    if (nameof(this.PlaceHolder).Equals(propertyName))
        //    {
                
        //    }
        //    else if(nameof(this.StorageKey).Equals(propertyName))
        //    {
                
        //    }

        //    base.OnPropertyChanged(propertyName);
        //}
    }
}
