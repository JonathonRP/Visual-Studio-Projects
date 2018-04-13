using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DatabaseTesting.Models;
using DatabaseTesting.Views;
using DatabaseTesting.ViewModels;

namespace DatabaseTesting.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : ContentPage
	{
        SettingsViewModel viewModel;

        public Settings()
        {
            InitializeComponent();

            BindingContext = viewModel = new SettingsViewModel();
        }

        private void DisableSelecting(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            ((ListView)sender).SelectedItem = false;
        }
    }
}