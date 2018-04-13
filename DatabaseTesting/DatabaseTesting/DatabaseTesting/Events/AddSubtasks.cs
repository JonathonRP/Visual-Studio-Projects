using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using DatabaseTesting.Models;

namespace DatabaseTesting.Events
{
    class AddSubtasks : PubSubEvent<AddSubtasks>
    {
        public ToDoTask Task { get; set; }
        public ToDoTask Subtask { get; set; }
    }
}
