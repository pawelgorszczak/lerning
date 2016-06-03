using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM.ViewModels;

namespace WpfMVVM.Commands
{
    internal class CustomerUpdateCommand : ICommand
    {
        public CustomerUpdateCommand(CustomerViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private CustomerViewModel _viewModel;


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            _viewModel.SaveChanges();
        }
    }
}
