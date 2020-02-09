using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfOverview.Models
{
    class Person : INotifyPropertyChanged
    {
        private string firstName;

        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    PropertyChangedInvoker();
                }
            }
        }
        private string lastName;
        public void PropertyChangedInvoker([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FullName"));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    PropertyChangedInvoker();
                }
            }
        }
        public string FullName => $"{FirstName} {LastName}";
    }
}
