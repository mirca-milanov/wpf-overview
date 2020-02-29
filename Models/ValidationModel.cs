using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfOverview.Models
{
    public class ValidationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string someName;

        public string SomeName
        {
            get { return someName; }
            set
            {
                if (value.Length > 10)
                {
                    throw new Exception("SomeName cannot be longer than 10 characters.");
                }
                else if (someName != value)
                {
                    someName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SomeName"));
                }
            }
        }

    }
}
