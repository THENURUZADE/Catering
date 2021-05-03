using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.ChiefControlCommands
{
    public class RejectCommand : BaseControlCommand<ChiefControlViewModel>
    {
        public RejectCommand(ChiefControlViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {

            viewModel.Model = null;
            viewModel.SelectedModel = null;
            viewModel.CurrentSituation = (int)Enums.Situation.Normal;
        }
    }
}
