

using WpfMVVM.Views;

namespace WpfMVVM.ViewModels
{
    using WpfMVVM.Models;
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using Commands;
    internal class CustomerViewModel
    {
        private Customer _customer;
        private CustomerInfoViewModel _childViewModel;

        /// <summary>
        /// Initialiezes a new instance of the CustomerViewModel class.
        /// </summary>
        public CustomerViewModel()
        {
            _customer = new Customer("Pawel");
            _childViewModel = new CustomerInfoViewModel() { Info = "Instantiated in CustomerViewModel() ctor."};
            UpdateCommand = new CustomerUpdateCommand(this);
        }

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
            CustomerInfoView view = new CustomerInfoView {DataContext = _childViewModel};
            _childViewModel.Info = Customer.Name + " was updated in the database";
            view.ShowDialog();
        }
                
    }
}
