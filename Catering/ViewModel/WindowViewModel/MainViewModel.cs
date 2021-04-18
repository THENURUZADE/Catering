using Catering.Commands.MainViewCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.ViewModel.WindowViewModel
{
    public class MainViewModel : BaseWindowViewModel
    {
        public MainViewModel(Window view) : base(view)
        {
            ChiefCommand = new ChiefCommand(this);
        }
        public ChiefCommand ChiefCommand { get; set; }
    }
}
