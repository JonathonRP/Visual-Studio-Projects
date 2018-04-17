using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoManager.Models
{
    public class TaskList : ObservableCollection<ToDoTask>
    {
        public string Heading { get; set; }

        public ObservableCollection<ToDoTask> Tasks => this;
    }
}
