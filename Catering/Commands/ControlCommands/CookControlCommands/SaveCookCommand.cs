using Catering.Core;
using Catering.Core.Domain.Entities;
using Catering.Enums;
using Catering.Helpers;
using Catering.Mappers;
using Catering.Models;
using Catering.ViewModel.ControlViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Commands.ControlCommands.CookControlCommands
{
    public class SaveCookCommand : BaseCookCommand
    {
        public SaveCookCommand(CookViewModel viewModel): base(viewModel) { }

        public override void Execute(object parameter)
        {
            if(viewModel.CurrentSituation == (int)Situation.Normal)
            {
                viewModel.CurrentSituation = (int)Situation.Add;
            }
            else if(viewModel.CurrentSituation == (int)Situation.Selected)
            {
                viewModel.CurrentSituation = (int)Situation.Edit;
            }
            else
            {
                if (viewModel.CurrentModel.IsValid())
                {
                    CookMapper mapper = new CookMapper();
                    Cook cook = mapper.Map(viewModel.CurrentModel);
                    cook.Creator = Kernel.CurrentUser;
                    cook.LastModifiedDate = DateTime.Now;

                    if (viewModel.CurrentSituation == (int)Situation.Add)
                    {
                        int id = DB.CookRepository.Add(cook);
                        viewModel.CurrentModel.Id = id;
                        viewModel.CurrentModel.No = viewModel.AllModels.Count + 1;
                        viewModel.AllModels.Add(viewModel.CurrentModel.Clone());
                        viewModel.Cooks.Add(viewModel.CurrentModel);
                        MessageBox.Show(UIMessages.SuccessedMessage);
                    }
                    else if (viewModel.CurrentSituation == (int)Situation.Edit)
                    {
                        if (DB.CookRepository.Update(cook))
                        {
                            CookModel model = viewModel.AllModels.FirstOrDefault(x => x.Id == viewModel.SelectedModel.Id);
                            int index = viewModel.AllModels.IndexOf(model);
                            viewModel.AllModels[index] = viewModel.CurrentModel.Clone();
                            viewModel.Cooks = new ObservableCollection<CookModel>(viewModel.AllModels);

                            MessageBox.Show(UIMessages.SuccessedMessage);
                        }
                    }

                    viewModel.SelectedModel = null;
                    viewModel.CurrentModel = new CookModel();
                    viewModel.CurrentSituation = (int)Situation.Normal;
                }
                else
                {
                    MessageBox.Show(UIMessages.ErrorMessage, "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
