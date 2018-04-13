using System;

using ToDoManager.Views;
using ToDoManager.ViewModels;
using Prism.Services;
using Prism.DryIoc;
using Xamarin.Forms;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;

namespace ToDoManager
{
	public partial class App : PrismApplication
	{
        public App() : this(null) { }

        public App (IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
        {
            InitializeComponent();
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
