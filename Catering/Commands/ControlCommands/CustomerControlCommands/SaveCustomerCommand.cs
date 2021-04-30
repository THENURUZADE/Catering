using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.CustomerControlCommands
{
    public class SaveCustomerCommand : BaseControlCommand<CustomerControlViewModel>
    {
        public SaveCustomerCommand(CustomerControlViewModel viewModel) : base(viewModel) { }
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
