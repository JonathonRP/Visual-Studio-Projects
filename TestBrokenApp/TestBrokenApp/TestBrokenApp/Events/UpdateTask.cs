using System;
using System.Collections.Generic;
using System.Text;

using TestBrokenApp.Models;
using Prism.Events;

namespace TestBrokenApp.Events
{
    class UpdateTask : PubSubEvent<UpdateTask>
    {
        public ToDoTask Task { get; set; }
    }
}
