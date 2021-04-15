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

namespace Catering.Views.Windows
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : Window
    {
        private ConfigurationViewModel viewModel;
        public ConfigurationView(ConfigurationViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;

            if (!viewModel.DbSettings.IntegratedSecurity)
                rdbSqlServer.IsChecked = true;

            viewModel.DbSettings.Username = string.Empty;
            viewModel.DbSettings.Password = string.Empty;
        }

        private void btnConfigSave(object sender, RoutedEventArgs e)
        {
            viewModel.DbSettings.SaveConfig();

            WaitWindowView wait = new WaitWindowView();
            wait.Show();
            Close();
        }

        private void btnConfigCancel(object sender, RoutedEventArgs e)
        {
            WaitWindowView wait = new WaitWindowView();
            wait.Show();
            Close();
        }

        private void rdbChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            bool isEnabled = rdb == rdbSqlServer;
            txtPassword.IsEnabled = isEnabled;
            txtUsername.IsEnabled = isEnabled;
        }
    }
}
