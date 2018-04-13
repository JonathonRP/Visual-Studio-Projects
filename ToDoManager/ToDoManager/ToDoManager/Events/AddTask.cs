using System;
using System.Collections.Generic;
using System.Text;

using ToDoManager.Models;
using Prism.Events;

namespace ToDoManager.Events
{
    class AddTask : PubSubEvent<ToDoTask>
    {

    }
}
