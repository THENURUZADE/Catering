using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.CookControlCommands
{
    public abstract class BaseCookCommand : BaseControlCommand<CookViewModel>
    {
        public BaseCookCommand(CookViewModel viewModel) : base(viewModel) { }
    }
}
