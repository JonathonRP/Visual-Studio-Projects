using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoManager.Models;

namespace ToDoManager.Events
{
    class UpdateSubtask : PubSubEvent<UpdateSubtask>
    {
        public ToDoTask Task { get; set; }
        public ToDoTask Subtask { get; set; }
    }
}
