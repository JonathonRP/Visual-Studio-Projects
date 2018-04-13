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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            count++;

            WPFLabel.Content = "You Clicked the Button!";

            Count.Content = $"Count: {count}";

            await Task.Delay(2000);

            Count.Content = "";

            WPFLabel.Content = "Hello World";

            if (WPFTextbox.Text.ToLower() != "textbox" || WPFTextbox.Text != "")
            {
                WPFTextBlock.Text = WPFTextbox.Text;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ( double.TryParse(Number.Text, out double isNumber) )
            {
                double square = isNumber * isNumber;

                Answer.Content = square;
            }
            else
            {
                Answer.Content = "Cant Square Value";
                return;
            }
        }
    }
}
