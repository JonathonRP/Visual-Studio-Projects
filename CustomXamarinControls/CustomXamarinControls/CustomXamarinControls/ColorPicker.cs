using Plugin.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CustomXamarinControls
{
    public class ColorPicker : Picker
    {
        public static readonly BindableProperty StorageKeyProperty
            = BindableProperty.Create(nameof(StorageKey), typeof(string), typeof(ColorPicker), "", BindingMode.TwoWay);

        public string StorageKey
        {
            get { return (string)GetValue(StorageKeyProperty); }
            set { SetValue(StorageKeyProperty, value); OnPropertyChanging(nameof(StorageKey)); }
        }

        public ColorPickerViewModel ViewModel = new ColorPickerViewModel();

        public ColorPicker()
        {
            SetBinding(ItemsSourceProperty, new Binding("Colors"));
            SetBinding(SelectedItemProperty, new Binding("SelectedColor"));

            ItemDisplayBinding = new Binding("Name");
            BindingContext = ViewModel;
        }

        protected override void OnPropertyChanging(string propertyName = null)
        {
            if(nameof(StorageKey).Equals(propertyName))
            {
                ViewModel.StorageKey = StorageKey;
                //Console.WriteLine($"Storage Key: {StorageKey}");

                SetBinding(ItemsSourceProperty, new Binding("Colors"));
                SetBinding(SelectedItemProperty, new Binding("SelectedColor", BindingMode.TwoWay));

                ItemDisplayBinding = new Binding("Name");
                BindingContext = ViewModel;
            }

            base.OnPropertyChanging(propertyName);
        }
    }
}
