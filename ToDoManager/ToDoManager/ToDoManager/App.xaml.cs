using System;
using ToDoManager.Views;
using ToDoManager.ViewModels;
using Prism.Services;
using Prism.DryIoc;
using Xamarin.Forms;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Xamarin.Forms.Xaml;
using Plugin.Settings;
using CustomXamarinControls;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ToDoManager
{
	public partial class App : PrismApplication
	{
        public App (IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
        {
            InitializeComponent();
            
            App.Current.Resources["Primary"] = Color.FromHex(CrossSettings.Current.GetValueOrDefault("Primary", ((Color)App.Current.Resources["Primary"]).ToHex()));
            MessagingCenter.Send(typeof(ThemeColorPickerViewModel), "UpdateStatusbar");

            App.Current.Resources["Accent"] = Color.FromHex(CrossSettings.Current.GetValueOrDefault("Accent", ((Color)App.Current.Resources["Accent"]).ToHex()));

            NavigationService.NavigateAsync("MainPage/NavigationPage/Tasks");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterPopupNavigationService();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<Tasks>();
            containerRegistry.RegisterForNavigation<Subtasks>();
            containerRegistry.RegisterForNavigation<Settings>();
            containerRegistry.RegisterForNavigation<ThemeColorPicker>();
        }
    }
}
