using System.Collections.Generic;
using System.ComponentModel;

namespace FP.PostSharpSamples.UI.Business
{
    public class BaseErrorViewModel : IErrorInfoPropertyChanged
    {
        private Dictionary<string, string> errors = new Dictionary<string, string>();

        public void SetError(string property, string error)
        {
            errors[property] = error;
        }

        public void OnPropertyChanged(string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Error
        {
            get { return string.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                if (errors.ContainsKey(columnName))
                {
                    return errors[columnName];
                }
                return string.Empty;
            }
        }
    }
}
