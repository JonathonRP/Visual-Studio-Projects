using System;
using SQLite;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Realms;
using Prism.Mvvm;
using PropertyChanged;
using System.Collections.Generic;

namespace DatabaseTesting.Models
{
    [AddINotifyPropertyChangedInterface]
    public class ToDoTask : RealmObject
    {
        public int Id { get; set; }

        public bool InEdit { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Backlink(nameof(ToDoTask.Subtasks))]
        public IList<ToDoTask> Subtasks { get; set; }
    }
}