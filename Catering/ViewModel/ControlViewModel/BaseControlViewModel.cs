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
        private CurrentSituation currentSituation;

        public CurrentSituation CurrentSituation
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
