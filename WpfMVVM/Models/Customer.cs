

namespace WpfMVVM.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using WpfMVVM.Annotations;

    public class Customer : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _name;

        ///<sumary>
        /// Initializes a new instance of the Customer
        /// </sumary>
        public Customer(string customerName)
        {
            Name = customerName;
        }

        

        /// <summary>
        /// Gets or sets the Customers _name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    if (string.IsNullOrWhiteSpace(Name))
                    {
                        Error = "Name cannot be null or empty";
                    }
                    else
                    {
                        Error = null;
                    }
                }
                return Error;
            }
        }

        public string Error { get; private set; }
        #endregion
    }
}
