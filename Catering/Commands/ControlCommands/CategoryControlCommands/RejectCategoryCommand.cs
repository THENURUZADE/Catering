using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Commands.ControlCommands.CategoryControlCommands
{
    public class RejectCategoryCommand:BaseControlCommand<CategoryControlViewModel>
    {
        public RejectCategoryCommand(CategoryControlViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {

            viewModel.CurrentModel = null;
            viewModel.SelectedModel = null;
            viewModel.CurrentSituation = (int)Enums.Situation.Normal;
        }
    }
}
