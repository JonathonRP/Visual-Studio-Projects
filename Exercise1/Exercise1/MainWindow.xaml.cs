using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(MealCost.Text, out double mealCost))
            {
                Cost.Text = $"{mealCost:C}";

                if (TotalCost.IsChecked == true)
                {
                    if (double.TryParse(TipPercent.Text, out double tipPercent))
                    {
                        double tip = mealCost * (tipPercent / 100);

                        Cost.Text = $"{mealCost + tip:C}";
                    }
                    else
                    {
                        MessageBox.Show("Cant Parse tip percent");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Cant Parse meal cost");
                return;
            }
        }
    }
}
