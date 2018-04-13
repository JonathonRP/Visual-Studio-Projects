using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CustomXamarinControls
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangedEventHandler PropertyChanging;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnPropertyChanging(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanging;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
