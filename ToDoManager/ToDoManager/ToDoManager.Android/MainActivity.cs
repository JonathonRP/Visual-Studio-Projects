using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;
using Prism;
using Prism.Ioc;
using ToDoManager.Services;
using System.IO;
using DryIoc;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

namespace ToDoManager.Droid
{
    [Activity(Label = "ToDo Manager", Icon = "@drawable/todo_manager", Theme = "@style/MainTheme")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Rg.Plugins.Popup.Popup.Init(this, bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            Android.Graphics.Color statues_bar = ((Color)App.Current.Resources["Primary"]).AddLuminosity(-.07).ToAndroid();

            Window.SetStatusBarColor(statues_bar);
            this.SetStatusBarColor(statues_bar);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}

