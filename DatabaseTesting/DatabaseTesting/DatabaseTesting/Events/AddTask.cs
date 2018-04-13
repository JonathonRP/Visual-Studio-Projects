using System;
using System.Collections.Generic;
using System.Text;

using DatabaseTesting.Models;
using Prism.Events;

namespace DatabaseTesting.Events
{
    class AddTask : PubSubEvent<ToDoTask>
    {

    }
}
