using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TestBrokenApp.Models;
using TestBrokenApp.Views;

namespace TestBrokenApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel() : base()
        {
            Title = "Settings";
        }
    }
}