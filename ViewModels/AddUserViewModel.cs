using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfOverview.Commands;
using WpfOverview.Models;
using WpfOverview.Patterns;

namespace WpfOverview.ViewModels
{
    class AddUserViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors => errors.Any(e => e.Value.Count > 0);
        private readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        public DelegateCommand AddUserCommand { get; set; }
        public AddUserViewModel()
        {
            AddUserCommand = new DelegateCommand(o => UserAddingMediator.Default.Send(new User(Username, Email)), (o) => !HasErrors);
        }
        private string username;
        [MinLength(6, ErrorMessage = "Minimum length of 6 characters")]
        [MaxLength(20, ErrorMessage = "Maximum length of 20 characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required.")]
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    RaisePropertyChanged("Username");
                    Validate("Username", value);
                }
            }
        }
        private string email;
        [EmailAddress]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    RaisePropertyChanged("Email");
                    Validate("Email", value);
                }
            }
        }

        private void Validate(string propertyName, object value)
        {
            List<ValidationResult> validationResult = new List<ValidationResult>();
            errors.Remove(propertyName);
            if (!Validator.TryValidateProperty(value, new ValidationContext(this) { MemberName = propertyName }, validationResult))
            {
                errors[propertyName] = new List<string>();
                validationResult.ForEach(vr => errors[propertyName].Add(vr.ErrorMessage));
            }
            RaiseErrorsChanged(propertyName);
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RaiseErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public IEnumerable GetErrors(string propertyName)
        {
            if (errors.ContainsKey(propertyName))
            {
                return errors[propertyName];
            }
            return null;
        }
    }
}
