using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfOverview.Views;

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
            ObservableCollection<Person> people = new ObservableCollection<Person>() { };
            dgPeople.ItemsSource = people;
            dgPeople2.ItemsSource = people;

            people.Add(new Person() { FirstName = "Will", LastName = "Smith" });
            people.Add(new Person() { FirstName = "Will2", LastName = "Smith2" });
            people.Add(new Person() { FirstName = "Will3", LastName = "Smith3" });

            ObservableCollection<SuperPerson> superPeople = new ObservableCollection<SuperPerson>() { };
            dgOrganized.ItemsSource = superPeople;
            superPeople.Add(new SuperPerson("John", "Doe", 42, true));
            superPeople.Add(new SuperPerson("Josh", "Billy", 812, false));
            superPeople.Add(new SuperPerson("Janny", "Johnsy", 52, false));
            superPeople.Add(new SuperPerson("Jill", "Ariel", 22, true));




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

        private void MoveVideoToStart(object sender, RoutedEventArgs e)
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
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"{e.RoutedEvent.RoutingStrategy.ToString()} - Routing Strategy.");
            MessageBox.Show("Button down.");
        }


        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(MainWindow), new PropertyMetadata(200));

        private void lbPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbSelectedLb.Text = "Selected listbox item: " + (e.AddedItems[0] as Person).ToString();
        }

        private void cbSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = (e.AddedItems[0] as string);
            if (selected != "None")
            {
                CollectionView cw = (CollectionView)CollectionViewSource.GetDefaultView(dgOrganized.ItemsSource);
                cw.SortDescriptions.Clear();
                cw.SortDescriptions.Add(new System.ComponentModel.SortDescription(selected, System.ComponentModel.ListSortDirection.Ascending));
            }
        }

        private void StackPanel_Checked(object sender, RoutedEventArgs e)
        {
            string selected = (e.OriginalSource as RadioButton).Content as String;
            CollectionView cw = (CollectionView)CollectionViewSource.GetDefaultView(dgOrganized.ItemsSource);

            switch (selected)
            {
                case "Is alive":
                    cw.Filter = (o) => ((SuperPerson)o).IsAlive;
                    break;
                case "Is dead":
                    cw.Filter = (o) => !((SuperPerson)o).IsAlive;
                    break;
                default:
                    cw.Filter = o => true;
                    break;
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            CollectionView cw = (CollectionView)CollectionViewSource.GetDefaultView(dgOrganized.ItemsSource);
            cw.GroupDescriptions.Add(new PropertyGroupDescription("IsAlive"));
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            CollectionView cw = (CollectionView)CollectionViewSource.GetDefaultView(dgOrganized.ItemsSource);
            cw.GroupDescriptions.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RandomWindow rw = new RandomWindow();
            rw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var mbr = MessageBox.Show("Basic message box", "Caption", MessageBoxButton.YesNoCancel);
            tbMessageBoxResult.Text = "Message box result: " + mbr;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog();
            
            if (sfd.ShowDialog() == true)
            {
                tbSaveFileResult.Text = sfd.FileName;
            }
        }
    }
}
