using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfOverview.Models
{
    class SuperPerson : INotifyPropertyChanged
    {
        public SuperPerson()
        {

        }
        public SuperPerson(string first, string last, int age, bool isAlive)
        {
            FirstName = first;
            LastName = last;
            Age = age;
            IsAlive = isAlive;
        }
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
        private int age;

        public int Age
        {
            get => age;
            set
            {
                if (age != value)
                {
                    age = value;
                    PropertyChangedInvoker();
                }
            }
        }
        private bool isAlive;

        public bool IsAlive
        {
            get => isAlive;

            set
            {
                if (isAlive != value)
                {
                    isAlive = value;
                    PropertyChangedInvoker();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void PropertyChangedInvoker([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
