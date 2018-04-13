using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DatabaseTesting.Models;
using DatabaseTesting.ViewModels;
using Xamarin.Forms;

namespace DatabaseTesting.Converters
{
    class BooleanAddSubtasksConverter : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if (value is bool)
            //{
            //    if ((value is bool) == true)
            //    {
            //        if ((parameter as ToDoTask).Subtasks == null)
            //        {
            //            (parameter as ToDoTask).Subtasks = new ObservableCollection<ToDoTask>();
            //        }
            //        else
            //        {
            //            (parameter as ToDoTask).Subtasks = (parameter as ToDoTask).Subtasks;
            //        }
            //    }
            //    else
            //    {
            //        if ((parameter as ToDoTask).Subtasks == null)
            //        {
            //            (parameter as ToDoTask).Subtasks = null;
            //        }
            //        else
            //        {
            //            return value;
            //        }
            //    }
            //}

            return value;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
