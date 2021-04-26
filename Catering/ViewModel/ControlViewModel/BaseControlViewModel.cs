using Catering.Commands.ControlCommands.ChiefControlCommands;
using Catering.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.ViewModel.ControlViewModel
{
    public abstract class BaseControlViewModel : BaseViewModel
    {
        public abstract string Header { get; }
        public AddCommand AddCommand { get; set; }
        public DeleteCommand DeleteCommand { get; set; }
        public RejectCommand RejectCommand { get; set; }
        public UpdateCommand UpdateCommand { get; set; }

        private int currentSituation = 1;
        public int CurrentSituation
        {
            get { return currentSituation; }
            set
            {
                currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }
    }
}
