using Catering.Core.Domain.Entities;
using Catering.Helpers;
using Catering.Mappers;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.MainViewCommands
{
    public class CustomerCommand : BaseCommand
    {
        private CustomerControlViewModel viewModel;
        public CustomerCommand(CustomerControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            List<Customer> customers = DB.CustomerRepository.Get();
            CustomerMapper mapper = new CustomerMapper();
            foreach (var item in customers)
            {
                viewModel.AllModels.Add(mapper.Map(item));
                viewModel.Customers.Add(mapper.Map(item));
            }
            
            CollectionNumerator<CustomerControlModel>.Numerate(viewModel.Customers);
        }
    }
}
