using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestBrokenApp.Models;
using TestBrokenApp.Events;

using Prism.Navigation;
using Prism.Commands;
using Prism.Events;

namespace TestBrokenApp.ViewModels
{
    class NewTaskViewModel : BaseViewModel
    {
        public ToDoTask Task { get; set; }

        private bool shouldAddSubtasks = false;
        public bool AddSubtasks
        {
            get { return shouldAddSubtasks; }
            set { SetProperty(ref shouldAddSubtasks, value); }
        }

        public DelegateCommand Saved => new DelegateCommand(Save);
        
        public NewTaskViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base (navigationService, eventAggregator)
        {
            Title = "New Task";

            Task = new ToDoTask
            {
                Title = "Task name"
            };
        }

        public async void Save()
        {
            if (AddSubtasks == true)
            {
                Task.Subtasks.Add(new ToDoTask());
            }
            else
            {
                
            }

            EventAggregator.GetEvent<AddTask>().Publish(Task);
            
            await NavigationService.GoBackAsync(useModalNavigation: true);
        }
    }
}
