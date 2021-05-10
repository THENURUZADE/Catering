using Catering.Commands.MainViewCommands;
using System.Windows;

namespace Catering.ViewModel.WindowViewModel
{
    public class MainViewModel : BaseWindowViewModel
    {
        public MainViewModel(Window view) : base(view)
        {
            ChiefCommand = new ChiefCommand(this);
            CustomerCommand = new CustomerCommand(this);
            CategoryCommand = new CategoryCommand(this);
        }
        public ChiefCommand ChiefCommand { get; set; }
        public CustomerCommand CustomerCommand { get; set; }
        public CategoryCommand CategoryCommand { get; set; }
    }
}
