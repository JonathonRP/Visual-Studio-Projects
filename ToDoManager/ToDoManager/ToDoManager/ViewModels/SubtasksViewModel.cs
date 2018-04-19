using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ToDoManager.Models;
using ToDoManager.Views;
using ToDoManager.Events;
using Prism.Commands;
using Prism.Navigation;
using Prism.Events;

namespace ToDoManager.ViewModels
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

        public DelegateCommand Add => new DelegateCommand(OnAdd);

        private DelegateCommand<ToDoTask> _tapped;
        public DelegateCommand<ToDoTask> Tapped => _tapped ?? (_tapped = new DelegateCommand<ToDoTask>(OnItemTapped, CanNavigate));
        public DelegateCommand<ToDoTask> Edit => new DelegateCommand<ToDoTask>(OnEditingEntered);
        public DelegateCommand<ToDoTask> Delete => new DelegateCommand<ToDoTask>(OnDeleting);

        public DelegateCommand<ToDoTask> CheckChanged => new DelegateCommand<ToDoTask>(OnCheckedChanged);

        public Command LoadItemsCommand { get; set; }
        
        public SubtasksViewModel(INavigationService navigationService, IEventAggregator eventAggregator) 
            : base (navigationService, eventAggregator)
        {
            Title = Task?.Title;
            Subtasks = Task?.Subtasks;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Task));

            eventAggregator.GetEvent<AddSubtask>().Subscribe(async task =>
            {
                var _task = task.Task;
                var _subtask = task.Subtask;

                if (!(_task.Subtasks.Contains(_subtask)))
                {
                    _task.Subtasks.Insert(0, _subtask);

                    await DataStore.UpdateAsync(_task);
                }
            });

            eventAggregator.GetEvent<UpdateSubtask>().Subscribe(async task =>
            {
                var _task = task.Task;
                var _subtask = _task.Subtasks.Where(x => x.Id == task.Subtask.Id).FirstOrDefault();

                _subtask.Title = task.Subtask.Title;
                _subtask.InEdit = task.Subtask.InEdit;
                _subtask.IsComplete = task.Subtask.IsComplete;
                _subtask.SubtaskBook = task.Subtask.SubtaskBook;
                _subtask.Subtasks = task.Subtask.Subtasks;

                await DataStore.UpdateAsync(_task);
            });

            eventAggregator.GetEvent<DeleteSubtask>().Subscribe(async task =>
            {
                var _task = task.Task;
                var _subtask = task.Subtask;
                _task.Subtasks.Remove(_subtask);
                await DataStore.UpdateAsync(_task);
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

        private void OnCheckedChanged(ToDoTask subtask)
        {
            if (subtask.IsComplete)
            {
                subtask.Complete();
                EventAggregator.GetEvent<UpdateTask>().Publish(subtask);
                if (App.Current.Properties.Keys.Contains("delete"))
                {
                    if ((bool)App.Current.Properties["delete"] == true)
                    {
                        EventAggregator.GetEvent<DeleteSubtask>().Publish(new DeleteSubtask() { Task = Task, Subtask = subtask });
                    }
                }
            }
            else
            {
                subtask.Incomplete();
                EventAggregator.GetEvent<UpdateSubtask>().Publish(new UpdateSubtask() { Task = Task, Subtask = subtask });
            }
        }

        private bool CanNavigate(ToDoTask subtask)
        {
            if (subtask == null)
                return false;

            if (subtask.InEdit == true)
            {
                subtask.InEdit = false;

                EventAggregator.GetEvent<UpdateSubtask>().Publish(new UpdateSubtask() { Task = Task, Subtask = subtask });
                LoadItemsCommand.Execute(null);
                return false;
            }
            else if(subtask.Subtasks != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnDeleting(ToDoTask subtask)
        {
            EventAggregator.GetEvent<DeleteSubtask>().Publish(new DeleteSubtask() { Task = Task, Subtask = subtask });
        }

        private void OnEditingEntered(ToDoTask subtask)
        {
            if (Subtasks.Contains(Subtasks.Where(x => x.InEdit == true).SingleOrDefault()))
            {
                foreach (var _task in Subtasks.Where(x => x.InEdit == true))
                {
                    _task.InEdit = false;
                }
            }

            subtask.InEdit = true;

            LoadItemsCommand.Execute(null);
        }

        async void OnItemTapped(ToDoTask task)
        {
            var param = new NavigationParameters
            {
                { "Task", task }
            };

            await NavigationService.NavigateAsync("Subtasks", param);
        }

        void OnAdd()
        {
            var Subtask = new ToDoTask
            {
                InEdit = true,
                Title = "Subtask name",
                Description = "This is a subtask description.",
                Subtasks = null
            };

            EventAggregator.GetEvent<AddSubtask>().Publish(new AddSubtask() { Task = Task, Subtask = Subtask });
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Task"))
            {
                Task = (ToDoTask)parameters["Task"];
                Title = Task?.Title;
                Subtasks = Task.Subtasks;
                LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Task));
            }
        }
    }
}
