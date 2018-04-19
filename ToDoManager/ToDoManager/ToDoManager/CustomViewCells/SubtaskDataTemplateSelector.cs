using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using ToDoManager.Models;

namespace ToDoManager.CustomViewCells
{
    public class SubtaskDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TaskCell { get; set; }
        public DataTemplate SubtaskCellInEdit { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((ToDoTask)item).InEdit == true ? SubtaskCellInEdit : TaskCell;
        }
    }
}
