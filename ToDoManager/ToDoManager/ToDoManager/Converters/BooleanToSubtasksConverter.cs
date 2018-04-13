using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoManager.Models;
using ToDoManager.ViewModels;
using Prism.Services;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ToDoManager.Converters
{
    class BooleanToSubtasksConverter : IValueConverter
    {
        private ObservableCollection<ToDoTask> Subtasks;

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Subtasks = (ObservableCollection<ToDoTask>)value;

            if (value is ObservableCollection<ToDoTask>)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                {
                    if (Subtasks?.Count > 0)
                    {
                        return value;
                    }
                    else
                    {
                        return new ObservableCollection<ToDoTask>();
                    }
                }
                else
                {
                    if (Subtasks?.Count > 0)
                    {
                        return value;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return value;
        }

        #endregion
    }
}
