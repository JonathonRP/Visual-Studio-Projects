using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TestBrokenApp.Models;
using TestBrokenApp.Views;
using TestBrokenApp.Events;
using Prism.Commands;
using Prism.Navigation;
using Prism.Events;

namespace TestBrokenApp.ViewModels
{
    public class SubtasksViewModel : BaseViewModel
    {
        private ToDoTask _task;
        public ToDoTask Task
        {
            get { return _task; }
            set { SetProperty(ref _task, value); }
        }

        private ToDoTask _subtask;
        public ToDoTask Subtask
        {
            get { return _subtask; }
            set { SetProperty(ref _subtask, value); }
        }

        private ObservableCollection<ToDoTask> _subtasks;
        public ObservableCollection<ToDoTask> Subtasks
        {
            get { return _subtasks; }
            set { SetProperty(ref _subtasks, value); }
        }

        public DelegateCommand AddSubtask => new DelegateCommand(Add);

        private DelegateCommand<ToDoTask> _tapped;
        public DelegateCommand<ToDoTask> Tapped => _tapped ?? (_tapped = new DelegateCommand<ToDoTask>(OnItemTapped, CanNavigate));
        public Command LoadItemsCommand { get; set; }
        
        public SubtasksViewModel(INavigationService navigationService, IEventAggregator eventAggregator) 
            : base (navigationService, eventAggregator)
        {
            Title = Task?.Title;
            Subtasks = new ObservableCollection<ToDoTask>(Task?.Subtasks);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Task));

            eventAggregator.GetEvent<AddSubtasks>().Subscribe(async task =>
            {
                var _task = task.Task as ToDoTask;
                var _subtask = task.Subtask as ToDoTask;

                if (!(_task.Subtasks.Contains(_subtask)))
                {
                    _task.Subtasks.Add(_subtask);
                    await DataStore.UpdateAsync(_task);
                }
            });
        }

        async Task ExecuteLoadItemsCommand(ToDoTask _task)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Subtasks.Clear();
                var tasks = await DataStore.GetItemsAsync(true);
                foreach (var task in tasks.Where(x => x.Title == _task.Title))
                {
                    foreach (var subtask in task.Subtasks)
                    {
                        Subtasks.Add(subtask);
                    }
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

        private bool CanNavigate(ToDoTask task)
        {
            if (task == null)
                return false;

            if (task.Subtasks != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        async void OnItemTapped(ToDoTask task)
        {
            var param = new NavigationParameters
            {
                { "Task", task }
            };

            await NavigationService.NavigateAsync("Subtasks", param);
        }

        async void Add()
        {
            var param = new NavigationParameters
            {
                { "Task", Task }
            };

            await NavigationService.NavigateAsync("NavigationPage/NewSubtask", param, useModalNavigation: true);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Task"))
            {
                Task = (ToDoTask)parameters["Task"];
                Title = Task?.Title;
                Subtasks = new ObservableCollection<ToDoTask>(Task.Subtasks);
                LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Task));
            }
        }
    }
}
