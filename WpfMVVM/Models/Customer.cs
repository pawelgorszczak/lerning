

namespace WpfMVVM.Models
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using WpfMVVM.Annotations;

    public class Customer : INotifyPropertyChanged
    {
        ///<sumary>
        /// Initializes a new instance of the Customer
        /// </sumary>
        public Customer(string customerName)
        {
            Name = customerName;
        }

        private string _name;
        /// <summary>
        /// Gets or sets the Customers name
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
