using PrivateCatering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateCatering.ViewModel
{
    public class ConfigurationViewModel : BaseViewModel
    {
        private DbSettings dbSettings = DbSettings.Get();
        public DbSettings DbSettings
        {
            get => dbSettings;
            set
            {
                dbSettings = value;
                OnPropertyChanged(nameof(DbSettings));
            }
        } 
    }
}
