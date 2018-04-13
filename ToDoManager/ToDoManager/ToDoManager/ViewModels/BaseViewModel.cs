using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using ToDoManager.Models;
using ToDoManager.Services;
using Prism;
using Prism.DryIoc;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Events;
using Prism.Services;

namespace ToDoManager.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        protected IDataStore<ToDoTask> DataStore { get; private set; }

        protected INavigationService NavigationService { get; private set; }
        protected IEventAggregator EventAggregator { get; private set; }
        protected IPageDialogService PageDialogService { get; private set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);
            return true;
        }

        public BaseViewModel(INavigationService navigationService = null, IEventAggregator eventAggregator = null, 
            IPageDialogService pageDialogService = null, IDataStore<ToDoTask> dataStore = null)
        {
            NavigationService = navigationService;
            EventAggregator = eventAggregator;
            PageDialogService = pageDialogService;
            //DependencyService.Get<IDataStore<ToDoTask>>() ?? new TaskMockDataStore();
            DataStore = dataStore ?? new TaskMockDataStore();
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public virtual void OnNavigatingFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatingTo(INavigationParameters parameters) { }

        public virtual void Destroy() { }

        #region INotifyPropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    var changed = PropertyChanged;
        //    if (changed == null)
        //        return;

        //    changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        #endregion
    }
}
