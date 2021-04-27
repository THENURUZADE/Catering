using Catering.Commands.ControlCommands.ChiefControlCommands;
using Catering.Enums;
using Catering.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ChiefControlModel model = new ChiefControlModel();
        public ChiefControlModel Model
        {
            get { return model; }
            set 
            { 
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        private ChiefControlModel selectedModel;
        public ChiefControlModel SelectedModel
        {
            get 
            { 
                return selectedModel; 
            }
            set 
            { 
                selectedModel = value;
                OnPropertyChanged(nameof(SelectedModel));
            }
        }




        private ObservableCollection<ChiefControlModel> chiefs;
        public ObservableCollection<ChiefControlModel> Chiefs
        {
            get { return chiefs; }
            set 
            { 
                chiefs = value;
                OnPropertyChanged(nameof(Chiefs));
            }
        }









    }
}
