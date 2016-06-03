

namespace WpfMVVM.ViewModels
{
    using WpfMVVM.Models;
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using Commands;
    internal class CustomerViewModel
    {
        /// <summary>
        /// Initialiezes a new instance of the CustomerViewModel class.
        /// </summary>
        public CustomerViewModel()
        {
            _customer = new Customer("Pawel");
            UpdateCommand = new CustomerUpdateCommand(this);
        }

        public bool CanUpdate
        {
            get
            {
                if (Customer == null)
                    return false;
                return !string.IsNullOrWhiteSpace(Customer.Name);
            }
        }

        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
        }

        public ICommand UpdateCommand
        {
            get; private set;
        }

        public void SaveChanges()
        {
            Debug.Assert(false, string.Format("(0) was updated.", Customer.Name));
        }
                
    }
}
