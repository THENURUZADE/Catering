using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.ViewModel.WindowViewModel
{
    public abstract class BaseWindowViewModel : BaseViewModel
    {
        public Window view;
        public BaseWindowViewModel(Window view)
        {
            this.view = view;
        }
    }
}
