using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands
{
    public abstract class BaseControlCommand : BaseCommand
    {
        public readonly BaseControlViewModel viewModel;
        public BaseControlCommand(BaseControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
