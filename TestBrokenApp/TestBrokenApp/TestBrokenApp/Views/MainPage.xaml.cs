using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestBrokenApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
		public MainPage ()
		{
			InitializeComponent();
		}
    }
}