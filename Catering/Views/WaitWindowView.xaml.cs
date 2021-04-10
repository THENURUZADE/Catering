using Catering.Core;
using Catering.Core.Domain.Factories;
using Catering.Core.Enums;
using Catering.Models;
using Catering.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Catering.Views
{
    /// <summary>
    /// Interaction logic for WaitWindowView.xaml
    /// </summary>
    public partial class WaitWindowView : Window
    {
        public WaitWindowView()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            firstPanel.Visibility = Visibility.Visible;
            secondPanel.Visibility = Visibility.Hidden;

            //TODO
            //ADD crypt and decrypt algorithms to SecurityHelper

            //DbSettings dbSettings = DbSettings.Get();
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = dbSettings.DbSource;
            //builder.InitialCatalog = dbSettings.DbName;
            //builder.IntegratedSecurity = dbSettings.IntegratedSecurity;
            //if (!dbSettings.IntegratedSecurity)
            //{
            //    builder.UserID = dbSettings.Username;
            //    builder.Password = dbSettings.Password;
            //}
            //string conStr = builder.ConnectionString;

            DbSettings dbSettings = DbSettings.Get();
            Kernel.DB = DbFactory.Create(ServerType.SqlServer, dbSettings.GetConnectionString());

            _ = Task.Run(() => { CheckServer(); });




        }
        private async void CheckServer()
        {
            if (Kernel.DB.CheckServer())
            {
                await Task.Delay(3000);
                Dispatcher.Invoke(() =>
                {
                    LoginViewModel viewModel = new LoginViewModel();
                    LoginView loginView = new LoginView();
                    loginView.DataContext = viewModel;
                    loginView.Show();
                    Close();
                });

            }
            else
            {
                await Task.Delay(3000);
                Dispatcher.Invoke(() =>
                {
                    firstPanel.Visibility = Visibility.Hidden;
                    secondPanel.Visibility = Visibility.Visible;
                });
            }
        }

        private void ChangeButtonClick(object sender, RoutedEventArgs e)
        {
            ConfigurationViewModel configurationViewModel = new ConfigurationViewModel();
            ConfigurationView configurationView = new ConfigurationView(configurationViewModel);
            configurationView.DataContext = configurationViewModel;
            configurationView.Show();
            Close();
        }

    }
}
