using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoManager.CustomViewCells;
using ToDoManager.Models;

namespace ToDoManager.CustomViewCells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskCell : ViewCell
	{
        public static readonly BindableProperty ParentContextProperty =
            BindableProperty.Create("ParentContext", typeof(object), typeof(TaskCell), null, propertyChanged: OnParentContextPropertyChanged);

        public object ParentContext
        {
            get { return GetValue(ParentContextProperty); }
            set { SetValue(ParentContextProperty, value); }
        }

        public TaskCell()
		{
			InitializeComponent ();
		}

        private static void OnParentContextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != oldValue && newValue != null)
            {
                (bindable as TaskCell).ParentContext = newValue;
            }
        }

        private void CheckBox_CheckedChanged(object sender, CustomXamarinControls.EventArgs<bool> e)
        {
            if (e.Value)
            {
                if (App.Current.Properties.Keys.Contains("delete"))
                {
                    if ((bool)App.Current.Properties["delete"] == true)
                    {
                        MessagingCenter.Send<ToDoTask>(((ToDoTask)BindingContext), "deleteTask");
                    }
                }
            }
        }
    }
}