using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoManager.CustomViewCells;

namespace ToDoManager.CustomViewCells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubtaskCellInEdit : ViewCell
	{
        public static readonly BindableProperty ParentContextProperty =
            BindableProperty.Create("ParentContext", typeof(object), typeof(SubtaskCellInEdit), null, propertyChanged: OnParentContextPropertyChanged);

        public object ParentContext
        {
            get { return GetValue(ParentContextProperty); }
            set { SetValue(ParentContextProperty, value); }
        }


        public SubtaskCellInEdit()
		{
			InitializeComponent();
        }

        private static void OnParentContextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != oldValue && newValue != null)
            {
                (bindable as SubtaskCellInEdit).ParentContext = newValue;
            }
        }
    }
}