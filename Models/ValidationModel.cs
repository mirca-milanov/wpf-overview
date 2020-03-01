
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WpfOverview.Models
{
    public class ValidationModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private bool hasErrors = false;

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
        public Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        private string notifyString;
        [Range(-10, 50, ErrorMessage = "Between -10 & 50")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Value is required")]
        [MinLength(5)]
        public string NotifyString
        {

            get { return notifyString; }
            set
            {
                if (notifyString != value)
                {
                    errors.Remove("NotifyString");
                    notifyString = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NotifyString"));
                    var vr = new List<ValidationResult>();
                    hasErrors = !Validator.TryValidateProperty(value, new ValidationContext(this) { MemberName = "NotifyString" }, vr);
                    if (vr.Count() > 0)
                    {
                        if (!errors.ContainsKey("NotifyString"))
                        {
                            errors["NotifyString"] = new List<string>();
                            vr.ForEach(r => errors["NotifyString"].Add(r.ErrorMessage));
                        }   
                    }
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("NotifyString"));
                }
            }
        }

        public bool HasErrors => hasErrors;
        public IEnumerable GetErrors(string propertyName)
        {
            return errors[propertyName];
        }
    }
}
