using Catering.Core.Domain.Entities;
using Catering.Helpers;
using Catering.Mappers;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using Catering.ViewModel.WindowViewModel;
using Catering.Views.UserControls;
using Catering.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.MainViewCommands
{
    public class CustomerCommand : BaseCommand
    {
        private MainViewModel viewModel;
        public CustomerCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            CustomerControl customerControl = new CustomerControl();
            CustomerControlViewModel customerViewModel = new CustomerControlViewModel();
            customerControl.DataContext = customerViewModel;

            MainView window = (MainView)viewModel.view;
            window.grdMain.Children.Clear();
            window.grdMain.Children.Add(customerControl);

            List<Customer> customers = DB.CustomerRepository.Get();
            CustomerMapper mapper = new CustomerMapper();
            foreach (var item in customers)
            {
                customerViewModel.AllModels.Add(mapper.Map(item));
                customerViewModel.Customers.Add(mapper.Map(item));
            }
            
            CollectionNumerator<CustomerControlModel>.Numerate(customerViewModel.Customers);
        }
    }
}
