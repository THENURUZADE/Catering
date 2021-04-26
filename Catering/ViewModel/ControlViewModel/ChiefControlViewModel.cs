using Catering.Commands.ControlCommands.ChiefControlCommands;
using Catering.Enums;
using Catering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Catering.ViewModel.ControlViewModel
{
    public class ChiefControlViewModel : BaseControlViewModel
    {
        public ChiefControlViewModel()
        {
            AddCommand = new AddCommand(this);
            DeleteCommand = new DeleteCommand(this);
            RejectCommand = new RejectCommand(this);
            UpdateCommand = new UpdateCommand(this);
        }
        public override string Header => "Şeflər";
        public ChiefControlModel model = new ChiefControlModel();
        



        



    }
}
