using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.ChiefControlCommands
{
    public class AddCommand : BaseControlCommand
    {
        public AddCommand(ChiefControlViewModel viewModel):base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            viewModel.CurrentSituation = (int)Enums.CurrentSituation.Add;



        }
    }
}
