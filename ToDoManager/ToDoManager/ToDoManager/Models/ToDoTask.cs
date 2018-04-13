using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using ToDoManager.Services;

namespace ToDoManager.Models
{
    [Table("Tasks")]
    public class ToDoTask : BindableBase
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id {
            get { return id; }
            set { SetProperty(ref id, value, nameof(Id)); }
        }

        private bool inEdit = false;
        [Bindable(true), Ignore]
        public bool InEdit {
            get { return inEdit; }
            set { SetProperty(ref inEdit, value, nameof(InEdit)); }
        }

        private bool isComplete = false;
        [Bindable(true)]
        public bool IsComplete
        {
            get { return isComplete; }
            set { SetProperty(ref isComplete, value, nameof(isComplete)); }
        }

        private string title;
        [Bindable(true), NotNull]
        public string Title {
            get { return title; }
            set { SetProperty(ref title, value, nameof(Title)); }
        }

        private string desctiption;
        [Bindable(true)]
        public string Description {
            get { return desctiption; }
            set { SetProperty(ref desctiption, value, nameof(Description)); }
        }

        public string SubtaskBook { get; set; }

        private ObservableCollection<ToDoTask> subtasks;
        [Bindable(true), TextBlob(nameof(SubtaskBook))]
        public ObservableCollection<ToDoTask> Subtasks
        {
            get { return subtasks; }
            set { SetProperty(ref subtasks, value, nameof(Subtasks)); }
        }

        public void Complete(ToDoTask task)
        {
            task.IsComplete = true;
        }
    }
}