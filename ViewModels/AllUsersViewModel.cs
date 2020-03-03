using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOverview.Models;
using WpfOverview.Patterns;

namespace WpfOverview.ViewModels
{
    class AllUsersViewModel : INotifyPropertyChanged
    {
        public AllUsersViewModel()
        {
            UserAddingMediator.Default.Register(u => Users.Add(u));
        }
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
        private string searchText;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    RaisePropertyChanged("SearchText");
                }
            }
        }

    }
}
