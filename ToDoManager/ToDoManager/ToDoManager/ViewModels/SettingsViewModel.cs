﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;

using ToDoManager.Models;
using ToDoManager.Views;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using ToDoManager.Events;
using Prism.Events;

namespace ToDoManager.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        public DelegateCommand PrimaryTapped => new DelegateCommand(OnPrimaryTapped);
        public DelegateCommand AccentTapped => new DelegateCommand(OnAccentTapped);

        public DelegateCommand ClearAll => new DelegateCommand(OnClearDeleted);

        private bool toggled = false;
        public bool Toggled
        {
            get
            {
                return toggled;
            }
            set
            {
                SetProperty(ref toggled, value, nameof(Toggled));
                OnCheckChange(value);
            }
        }

        private ObservableCollection<ToDoTask> _deleted;
        public ObservableCollection<ToDoTask> Deleted
        {
            get { return _deleted; }
            set { SetProperty(ref _deleted, value); }
        }

        public SettingsViewModel(INavigationService navigationService, IEventAggregator eventAggregator) 
            : base(navigationService, eventAggregator)
        {
            Title = "Settings";
            Deleted = new ObservableCollection<ToDoTask>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            if (App.Current.Properties.ContainsKey("delete"))
            {
                Toggled = (bool)App.Current.Properties["delete"];
            }

            if (Deleted.Count == 0)
                LoadItemsCommand.Execute(null);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Deleted.Clear();
                var items = await DataStore.GetDeletedItemsAsync(true);
                foreach (var item in items)
                {
                    Deleted.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async void OnPrimaryTapped()
        {
            var param = new NavigationParameters()
            {
                { "Color", App.Current.Resources["Primary"] },
                { "Name", "Primary" }
            };

            await NavigationService.NavigateAsync("ThemeColorPicker", param);
        }

        async void OnAccentTapped()
        {
            var param = new NavigationParameters()
            {
                { "Color", App.Current.Resources["Accent"] },
                { "Name", "Accent" }
            };

            await NavigationService.NavigateAsync("ThemeColorPicker", param);
        }

        async void OnCheckChange(bool check)
        {
            if (check)
            {
                App.Current.Properties["delete"] = true;
                var tasks = await DataStore.GetItemsAsync();

                foreach (var task in tasks.Where(t => t.IsComplete == true))
                {
                    EventAggregator.GetEvent<DeleteTask>().Publish(task);
                    await DataStore.AddDeletedAsync(task);
                }

                LoadItemsCommand.Execute(null);
                await App.Current.SavePropertiesAsync();
            }
            else
            {
                App.Current.Properties["delete"] = false;
                await App.Current.SavePropertiesAsync();
            }
        }

        async void OnClearDeleted()
        {
            Deleted.Clear();
            var deleted = await DataStore.GetDeletedItemsAsync();

            foreach (var item in deleted)
            {
                await DataStore.RemoveDeletedAsync(item);
            }

            LoadItemsCommand.Execute(null);
        }
    }
}