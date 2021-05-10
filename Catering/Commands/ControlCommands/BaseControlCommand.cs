using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands
{
    public abstract class BaseControlCommand<T> : BaseCommand where T: BaseControlViewModel
    {
        public readonly T viewModel;

        public BaseControlCommand(T viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
