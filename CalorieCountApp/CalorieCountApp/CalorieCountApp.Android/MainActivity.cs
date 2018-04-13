using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;

using CustomXamarinControls;
using Plugin.Settings;
using Color = Xamarin.Forms.Color;
using Xamarin.Forms;
using Android.Graphics;

namespace CalorieCountApp.Droid
{
    [Activity(Label = @"Calorie Counting App", Icon = "@drawable/generic_yoga_icon", Theme = "@style/MainTheme", 
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Color background_color = Color.FromHex(CrossSettings.Current.GetValueOrDefault("backColor", Color.White.ToHex()));
            Android.Graphics.Color statues_bar = background_color.AddLuminosity(-.07).ToAndroid();

            Window.SetStatusBarColor(statues_bar);
            this.SetStatusBarColor(statues_bar);

            MessagingCenter.Subscribe<ColorPickerCell, Color>(this, "ChangeBackColor", (sender, arg) => {
                // do something whenever the "ChangeBackColor" message is sent
                Window.SetStatusBarColor(arg.AddLuminosity(-.07).ToAndroid());
                this.SetStatusBarColor(arg.AddLuminosity(-.07).ToAndroid());
            });

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

