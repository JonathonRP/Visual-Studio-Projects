using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DatabaseTesting.Models;
using DatabaseTesting.Views;

namespace DatabaseTesting.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel() : base()
        {
            Title = "Settings";
        }
    }
}