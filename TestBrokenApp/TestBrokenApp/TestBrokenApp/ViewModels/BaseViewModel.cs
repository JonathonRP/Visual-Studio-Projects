using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using TestBrokenApp.Models;
using TestBrokenApp.Services;
using Prism;
using Prism.DryIoc;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Events;
using Prism.Services;

namespace TestBrokenApp.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        protected IDataStore<ToDoTask> DataStore { get; private set; }
        protected IDataConnection Data => new DependencyService().Get<IDataConnection>();
        
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
            DataStore = dataStore ?? new TaskMockDataStore(Data);
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters) { }

        public virtual void OnNavigatedTo(NavigationParameters parameters) { }

        public virtual void OnNavigatingFrom(NavigationParameters parameters) { }

        public virtual void OnNavigatingTo(NavigationParameters parameters) { }

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
