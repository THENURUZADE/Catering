using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.ChiefControlCommands
{
    public class UpdateCommand : BaseControlCommand
    {
        public UpdateCommand(ChiefControlViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            viewModel.CurrentSituation = (int)Enums.CurrentSituation.Edit;
        }
    }
}
