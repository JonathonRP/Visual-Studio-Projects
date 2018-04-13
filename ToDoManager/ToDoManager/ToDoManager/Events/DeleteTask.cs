using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;
using ToDoManager.Models;

namespace ToDoManager.Events
{
    class DeleteTask : PubSubEvent<ToDoTask>
    {

    }
}
