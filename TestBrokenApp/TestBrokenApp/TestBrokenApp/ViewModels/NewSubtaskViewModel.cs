﻿using System;
using System.Collections.Generic;
using System.Text;
using TestBrokenApp.Models;
using TestBrokenApp.Events;
using Prism.Navigation;
using Prism.Commands;
using Prism.Events;
using System.Collections.ObjectModel;

namespace TestBrokenApp.ViewModels
{
    class NewSubtaskViewModel : BaseViewModel
    {
        public ToDoTask Task { get; set; }
        public ToDoTask Subtask { get; set; }

        private bool shouldAddSubtasks = false;
        public bool AddSubtasks
        {
            get { return shouldAddSubtasks; }
            set { SetProperty(ref shouldAddSubtasks, value); }
        }

        public DelegateCommand Saved => new DelegateCommand(Save);
        
        public NewSubtaskViewModel(INavigationService navigationService, IEventAggregator eventAggregator) 
            : base (navigationService, eventAggregator)
        {
            Title = "New SubTask";

            Subtask = new ToDoTask
            {
                Title = "SubTask name"
            };
        }

        async void Save()
        {
            if (AddSubtasks == true)
            {
                Subtask.Subtasks.Add(new ToDoTask());
            }
            else
            {
                
            }

            EventAggregator.GetEvent<AddSubtasks>().Publish(new AddSubtasks() { Task = Task, Subtask = Subtask });
            
            await NavigationService.GoBackAsync(useModalNavigation: true);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Task"))
            {
                Task = (ToDoTask)parameters["Task"];
            }
        }
    }
}
