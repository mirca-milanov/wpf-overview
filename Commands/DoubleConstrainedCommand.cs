using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfOverview.Commands
{
    public class DoubleConstrainedCommand : ICommand, INotifyPropertyChanged
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private int number = 2;

        public int Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return Number < 1000000;
        }

        public void Execute(object parameter)
        {
            Number *= 2;
        }
    }
}
