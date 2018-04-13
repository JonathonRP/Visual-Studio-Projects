using System;
using System.Collections.Generic;
using System.Text;

using TestBrokenApp.Models;
using Prism.Events;

namespace TestBrokenApp.Events
{
    class AddTask : PubSubEvent<ToDoTask>
    {

    }
}
