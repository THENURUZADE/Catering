using Catering.Enums;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.CustomerControlCommands
{
    public class RejectCustomerCommand : BaseCustomerCommand
    {
        public RejectCustomerCommand(CustomerControlViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            viewModel.CurrentModel = new CustomerControlModel();
            viewModel.SelectedModel = null;

            viewModel.CurrentSituation = (int)Situation.Normal;
        }
    }
}
