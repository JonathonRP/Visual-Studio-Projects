using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using ToDoManager.Models;

namespace ToDoManager.CustomViewCells
{
    public class TaskDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TaskCell { get; set; }
        public DataTemplate TaskCellInEdit { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((ToDoTask)item).InEdit == true ? TaskCellInEdit : TaskCell;
        }
    }
}
