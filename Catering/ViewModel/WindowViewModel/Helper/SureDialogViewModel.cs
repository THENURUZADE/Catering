using Catering.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.ViewModel.WindowViewModel.Helper
{
    public class SureDialogViewModel : BaseWindowViewModel
    {
        public SureDialogViewModel(Window view) : base(view) { }

        public string Message
        {
            get => UIMessages.DeleteSureMessage;
        }
    }
}
