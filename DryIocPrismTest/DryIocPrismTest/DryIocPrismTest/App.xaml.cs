using System;

using DryIocPrismTest.Views;
using DryIocPrismTest.ViewModels;
using Prism.Services;
using Prism.DryIoc;
using Xamarin.Forms;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DryIocPrismTest
{
	public partial class App : PrismApplication
	{
        public App (IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterPopupNavigationService();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            //containerRegistry.RegisterForNavigation<Tasks>();
            //containerRegistry.RegisterForNavigation<Subtasks>();
            //containerRegistry.RegisterForNavigation<Settings>();
            //containerRegistry.RegisterForNavigation<ThemeColorPicker>();
        }
    }
}
