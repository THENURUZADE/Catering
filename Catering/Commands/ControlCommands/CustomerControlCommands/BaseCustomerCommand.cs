using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.CustomerControlCommands
{
    public abstract class BaseCustomerCommand : BaseControlCommand<CustomerControlViewModel>
    {
        public BaseCustomerCommand(CustomerControlViewModel viewModel) : base(viewModel) { }
    }
}
