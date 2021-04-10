using Catering.Core.Domain.Abstracts;
using PrivateCatering.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrivateCatering.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public IUnitOfWork DB => Kernel.DB;

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);
    }
}
