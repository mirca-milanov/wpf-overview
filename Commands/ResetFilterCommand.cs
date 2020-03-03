using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfOverview.Commands
{
    class ResetFilterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                string input = parameter.ToString();
                if (input.Length > 0) return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Reset Filter.");
        }
    }
}
