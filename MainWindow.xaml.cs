using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfOverview.Models;

namespace WpfOverview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            spData.DataContext = new Person() { FirstName = "Will", LastName = "Smith" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((sender as Button).Content as TextBlock).Text);
            MessageBox.Show(e.ToString());
            MessageBox.Show(e.RoutedEvent.RoutingStrategy.ToString());
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = sender as ToggleButton;
            MessageBox.Show(tb.IsChecked.ToString());
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Checked!");
            ToggleButton tb = sender as ToggleButton;
            MessageBox.Show(tb.IsChecked.ToString());
        }
        int counter;
        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            tbCounter.Text = counter.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //meSpongebob.Position = new TimeSpan(0);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            spData.Resources["drColor"] = Brushes.Blue;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            spData.Resources["drColor"] = Brushes.Red;
        }
    }
}
