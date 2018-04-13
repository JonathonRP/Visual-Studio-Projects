﻿using System;

using DatabaseTesting.Views;
using DatabaseTesting.ViewModels;
using Prism.DryIoc;
using Xamarin.Forms;
using Prism;
using Prism.Ioc;
using DatabaseTesting.Services;

namespace DatabaseTesting
{
	public partial class App : PrismApplication
	{

		public App (IPlatformInitializer initializer = null) : base(initializer)
		{
			InitializeComponent();
        }

		protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("MainPage/NavigationPage/Tasks");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<Tasks>();
            containerRegistry.RegisterForNavigation<Subtasks>();
            containerRegistry.RegisterForNavigation<NewTask>();
            containerRegistry.RegisterForNavigation<NewSubtask>();
            containerRegistry.RegisterForNavigation<Settings>();
        }
    }
}
