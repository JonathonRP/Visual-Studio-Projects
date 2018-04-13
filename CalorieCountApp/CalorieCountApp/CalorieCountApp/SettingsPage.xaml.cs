using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomXamarinControls;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Settings;

namespace CalorieCountApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        private TableView Settings;
        private ToolbarItem Close;

		public SettingsPage()
		{
            Title = "Settings";
            
            Settings = new TableView()
            {
                Intent = TableIntent.Settings,

                Root = new TableRoot
                {
                    new TableSection("Main Activity Theming")
                    {
                        new ColorPickerCell() { Title = "Background:", Placeholder = "Select Color for Background",
                            StorageKey = "backColor", Message = "ChangeBackColor",
                            Command = new Command(() => Done()) },

                        new ColorPickerCell() { Title = "All Text:", Placeholder = "Select Color for Text",
                            StorageKey = "textColor", Message = "ChangeTextColor",
                            Command = new Command(() => Done()) },

                        new ColorPickerCell() { Title = "Calories Text:", Placeholder = "Select Color for Calories",
                            StorageKey = "caloriesColor", Message = "ChangeCaloriesColor",
                            Command = new Command(() => Done()) }
                    },
                    new TableSection("Available Calories")
                    {
                        new SettingsEntryCell() { Placeholder = "Enter Maximum Calories",
                            StorageKey = "maxCalories", Message = "NewMaxCalories",
                            Command = new Command(() => GoBack()) }
                    },
                    new TableSection("Reset")
                    {
                        new SwitchCell() { Text = "Reset Calories", On = false },
                        new SwitchCell() { Text = "Reset All", On = false }
                    }
                }
            };

            Close = new ToolbarItem()
            {
                Order = ToolbarItemOrder.Primary,
                Icon = "@drawable /close"
            };

            ToolbarItems.Add(Close);

            (Settings.Root.ElementAt(2).First() as SwitchCell).PropertyChanged += SwitchChanged;
            (Settings.Root.ElementAt(2).ElementAt(1) as SwitchCell).PropertyChanged += SwitchChanged;

            StackLayout layout = new StackLayout()
            {
                Children =
                {
                    Settings
                },

                Padding = new Thickness(15,5,15,0)
            };

            Content = layout;
            Close.Clicked += CloseClicked;
		}

        private void SwitchChanged(object sender, PropertyChangedEventArgs e)
        {
            if (nameof(On).Equals(e.PropertyName))
            {
                if ((sender as SwitchCell).On)
                {
                    if ((sender as SwitchCell).Text == "Reset Calories")
                    {
                        Close.Text = "Reset Calories";
                        Close.Icon = null;
                    }
                    else
                    {
                        Close.Text = "Reset";
                        Close.Icon = null;
                    }
                }
                else
                {
                    Close.Icon = "@drawable /close";
                }
            }
        }

        private void Done()
        {
            Close.Icon = "@drawable /done";
        }

        //private void DisableSelecting(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item == null) return;
        //    ((ListView)sender).SelectedItem = false;
        //}

        private void CloseClicked(object sender, EventArgs e)
        {
            if((Settings.Root.ElementAt(2).First() as SwitchCell).On)
            {
                CrossSettings.Current.Remove("maxCalories");
            }

            if ((Settings.Root.ElementAt(2).ElementAt(1) as SwitchCell).On)
            {
                CrossSettings.Current.Clear();
            }

            GoBack();
        }

        private async void GoBack()
        {
            await Navigation.PopModalAsync();
        }
    }
}