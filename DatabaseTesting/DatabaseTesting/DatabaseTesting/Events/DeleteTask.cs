using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;
using DatabaseTesting.Models;

namespace DatabaseTesting.Events
{
    class DeleteTask : PubSubEvent<ToDoTask>
    {

    }
}
