using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;
using Prism.Navigation;
using Prism.Events;
using Prism.Services;

using ToDoManager.Models;
using ToDoManager.Events;
using Prism.Commands;

namespace ToDoManager.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        private ObservableCollection<TaskList> _tasks;
        public ObservableCollection<TaskList> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }

        private TaskList Today;

        private TaskList General;

        public DelegateCommand Add => new DelegateCommand(OnAdd);

        private DelegateCommand<ToDoTask> _tapped;
        public DelegateCommand<ToDoTask> Tapped => _tapped ?? (_tapped = new DelegateCommand<ToDoTask>(OnItemTapped, CanNavigate));
        public DelegateCommand<ToDoTask> Edit => new DelegateCommand<ToDoTask>(OnEditingEntered);
        public DelegateCommand<ToDoTask> Delete => new DelegateCommand<ToDoTask>(OnDeleting);

        public DelegateCommand<ToDoTask> CheckChanged => new DelegateCommand<ToDoTask>(OnCheckedChanged);

        public Command LoadItemsCommand { get; set; }

        public TasksViewModel(INavigationService navigationService, IEventAggregator eventAggregator, IPageDialogService pageDialogService) 
            : base (navigationService, eventAggregator, pageDialogService)
        {
            Title = "ToDo's";

            Today = new TaskList();
            Today.Heading = nameof(Today);

            General = new TaskList();
            General.Heading = nameof(General);

            Tasks = new ObservableCollection<TaskList>()
            {
                Today,
                General
            };

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            eventAggregator.GetEvent<AddTask>().Subscribe(async task =>
            {
                Today.Insert(0, task);

                await DataStore.AddAsync(task);
            });

            eventAggregator.GetEvent<UpdateTask>().Subscribe(async task =>
            {
                await DataStore.UpdateAsync(task);
            });

            eventAggregator.GetEvent<DeleteTask>().Subscribe(async task =>
            {
                if (task.IsToday)
                {
                    Today.Remove(task);
                }
                else
                {
                    General.Remove(task);
                }

                await DataStore.DeleteAsync(task);
            });

            if (General.Count == 0)
                LoadItemsCommand.Execute(null);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Today.Clear();
                General.Clear();

                var items = await DataStore.GetItemsAsync(true);

                foreach (var item in items.Where(x => x.IsToday == true))
                {
                    Today.Add(item);
                }

                foreach (var item in items.Where(x => x.IsToday == false))
                {
                    General.Add(item);
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

        private async Task<bool> DeleteSubtasks()
        {
            var result = await PageDialogService.DisplayAlertAsync("Subtasks Are About to be Deleted",
                                    "Are you sure you want to delete current subtasks?", "Delete", "Cancel");

            return result;
        }

        private void OnCheckedChanged(ToDoTask task)
        {
            if (task.IsComplete)
            {
                task.Complete();
                EventAggregator.GetEvent<UpdateTask>().Publish(task);
                if (App.Current.Properties.Keys.Contains("delete"))
                {
                    if ((bool)App.Current.Properties["delete"] == true)
                    {
                        EventAggregator.GetEvent<DeleteTask>().Publish(task);
                    }
                }
            }
            else
            {
                task.Incomplete();
                EventAggregator.GetEvent<UpdateTask>().Publish(task);
            }
        }

        private bool CanNavigate(ToDoTask task)
        {
            if (task == null)
                return false;

            if (task.InEdit == true)
            {
                task.InEdit = false;

                EventAggregator.GetEvent<UpdateTask>().Publish(task);
                LoadItemsCommand.Execute(null);
                return false;
            }
            else if (task.Subtasks != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnDeleting(ToDoTask task)
        {
            EventAggregator.GetEvent<DeleteTask>().Publish(task);
        }

        private void OnEditingEntered(ToDoTask task)
        {
            if (General.Contains(General.Where(x => x.InEdit == true).SingleOrDefault()))
            {
                foreach (var _task in General.Where(x => x.InEdit == true))
                {
                    _task.InEdit = false;
                }
            }

            task.InEdit = true;
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
            var Task = new ToDoTask
            {
                IsToday = true,
                InEdit = true,
                Title = "Task name",
                Description = "This is a task description.",
                Subtasks = null
            };

            EventAggregator.GetEvent<AddTask>().Publish(Task);
        }
    }
}