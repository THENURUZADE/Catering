using Catering.Enums;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.CookControlCommands
{
    public class RejectCookCommand : BaseCookCommand
    {
        public RejectCookCommand(CookViewModel viewModel) : base(viewModel) { }
        public override void Execute(object parameter)
        {
            viewModel.CurrentSituation = (int)Situation.Normal;
            viewModel.CurrentModel = new CookModel();
            viewModel.SelectedModel = null;
        }
    }
}
