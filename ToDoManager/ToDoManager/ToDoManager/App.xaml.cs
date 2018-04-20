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

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ToDoManager
{
	public partial class App : PrismApplication
	{
        public App (IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
        {
            InitializeComponent();

            if (App.Current.Properties.ContainsKey("Primary"))
            {
                App.Current.Resources["Primary"] = (Color)App.Current.Properties["Primary"];
            }

            if (App.Current.Properties.ContainsKey("Accent"))
            {
                App.Current.Resources["Accent"] = (Color)App.Current.Properties["Accent"];
            }

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
