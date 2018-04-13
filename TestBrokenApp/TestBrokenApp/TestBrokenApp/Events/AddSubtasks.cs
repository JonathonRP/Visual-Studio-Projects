using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using TestBrokenApp.Models;

namespace TestBrokenApp.Events
{
    class AddSubtasks : PubSubEvent<AddSubtasks>
    {
        public ToDoTask Task { get; set; }
        public ToDoTask Subtask { get; set; }
    }
}
