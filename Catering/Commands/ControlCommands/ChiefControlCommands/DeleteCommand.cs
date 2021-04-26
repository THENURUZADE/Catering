using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.ChiefControlCommands
{
    public class DeleteCommand : BaseControlCommand
    {
        public DeleteCommand(ChiefControlViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            viewModel.CurrentSituation = (int)Enums.CurrentSituation.Normal;
        }
    }
}
