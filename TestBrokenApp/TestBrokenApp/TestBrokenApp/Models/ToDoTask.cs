using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace TestBrokenApp.Models
{
    public class ToDoTask : RealmObject
    {
        public bool IsComplete { get; set; }

        public bool InEdit { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public ToDoTask Subtask { get; set; }

        [MapTo(nameof(Subtask))]
        public IList<ToDoTask> Subtasks { get; }
    }
}
