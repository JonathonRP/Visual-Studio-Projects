using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace ToDoManager.Droid
{
    [Activity(Label = "ToDo Manager", Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashingActivity : FormsAppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistableState)
        {
            base.OnCreate(savedInstanceState, persistableState);

            // Create your application here
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            await Task.Delay(8000); // Simulate a bit of startup work.
        }
    }
}