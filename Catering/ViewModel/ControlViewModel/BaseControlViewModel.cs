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
    }
}
