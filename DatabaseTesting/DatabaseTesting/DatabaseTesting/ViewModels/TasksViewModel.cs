using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;
using Prism.Navigation;
using Prism.Events;
using Prism.Services;

using DatabaseTesting.Models;
using DatabaseTesting.Events;
using Prism.Commands;

namespace DatabaseTesting.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        private ObservableCollection<ToDoTask> _tasks;
        public ObservableCollection<ToDoTask> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }

        //private bool shouldAddSubtasks;
        //public bool AddSubtasks
        //{
        //    get { return shouldAddSubtasks; }
        //    set { SetProperty(ref shouldAddSubtasks, value); }
        //}

        public DelegateCommand AddTask => new DelegateCommand(Add);

        private DelegateCommand<ToDoTask> _tapped;
        public DelegateCommand<ToDoTask> Tapped => _tapped ?? (_tapped = new DelegateCommand<ToDoTask>(OnItemTapped, CanNavigate));
        public DelegateCommand<ToDoTask> Edit => new DelegateCommand<ToDoTask>(OnEditingEntered);
        public DelegateCommand<ToDoTask> Delete => new DelegateCommand<ToDoTask>(OnDeleting);

        public Command LoadItemsCommand { get; set; }

        public TasksViewModel(INavigationService navigationService, IEventAggregator eventAggregator, IPageDialogService pageDialogService) 
            : base (navigationService, eventAggregator, pageDialogService)
        {
            Title = "ToDo's";
            Tasks = new ObservableCollection<ToDoTask>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            eventAggregator.GetEvent<AddTask>().Subscribe(async task =>
            {
                var _task = task as ToDoTask;
                Tasks.Remove(_task);
                Tasks.Add(_task);
                await DataStore.AddAsync(_task);
            });

            eventAggregator.GetEvent<UpdateTask>().Subscribe(async task =>
            {
                var _task = Tasks.Where(x => x.Id == task.Id).FirstOrDefault();
                Tasks.Remove(_task);
                Tasks.Add(task);
                await DataStore.UpdateAsync(task);
            });

            eventAggregator.GetEvent<DeleteTask>().Subscribe(async task =>
            {
                var _task = task as ToDoTask;
                Tasks.Remove(_task);
                await DataStore.DeleteAsync(_task);
            });

            if (Tasks.Count == 0)
                LoadItemsCommand.Execute(null);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Tasks.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Tasks.Add(item);
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

        private async void DeleteSubtasks(ToDoTask task)
        {
            var result = await PageDialogService.DisplayAlertAsync("Subtasks Are About to be Deleted",
                                    "Are you sure you want to delete current subtasks?", "Delete", "Cancel");

            if (result)
            {
                task.Subtasks = null;
            }
            else
            {
                task.InEdit = true;
                LoadItemsCommand.Execute(null);
            }
        }

        private bool CanNavigate(ToDoTask task)
        {
            if (task == null)
                return false;

            if (task.InEdit == true)
            {
                task.InEdit = false;

                //if (AddSubtasks == true)
                //{
                //    if (task.Subtasks == null)
                //    {
                //        task.Subtasks = new ObservableCollection<ToDoTask>();
                //    }
                //    else
                //    {
                //        task.Subtasks = task.Subtasks;
                //    }
                //}
                //else
                //{
                //    if (task.Subtasks == null)
                //    {
                //        task.Subtasks = null;
                //    }
                //    else
                //    {
                //        DeleteSubtasks(task);
                //    }
                //}

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
            if (Tasks.Contains(Tasks.Where(x => x.InEdit == true).SingleOrDefault()))
            {
                foreach (var _task in Tasks.Where(x => x.InEdit == true))
                {
                    _task.InEdit = false;
                }
            }

            task.InEdit = true;

            //if (task.Subtasks == null)
            //{
            //    shouldAddSubtasks = false;
            //}
            //else
            //{
            //    shouldAddSubtasks = true;
            //}

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

        async void Add()
        {
            await NavigationService.NavigateAsync("NavigationPage/NewTask", useModalNavigation: true);
        }
    }
}