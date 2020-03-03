using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfOverview.Commands
{
    class CommandWithParameter : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }
            string input = parameter.ToString();
            return input.Length > 0;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show(parameter.ToString().Length.ToString());
        }
    }
}
