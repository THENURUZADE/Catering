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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Catering.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindowNewDesign.xaml
    /// </summary>
    public partial class MainViewNewDesign : Window
    {
        public MainViewNewDesign()
        {
            InitializeComponent();
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button currentBtn = (Button)sender;
            StackPanel currentStackPanel;
            switch (currentBtn.Name)
            {
                case nameof(btnInfo):
                    {
                        currentStackPanel = stpInfo;
                        break;
                    }
                case nameof(btnReport):
                    {
                        currentStackPanel = stpReport;
                        break;
                    }
                case nameof(btnOperation):
                    {
                        currentStackPanel = stpOperation;
                        break;
                    }
                default:
                    return;
            }

            DoubleAnimation doubleAnime = new DoubleAnimation();
            CircleEase crcEase = new CircleEase() { EasingMode = EasingMode.EaseOut };
            StackPanel stpCurrent = currentStackPanel;

            if (currentStackPanel.Height == 0)
            {
                doubleAnime.To = stpCurrent.Children.Count * 30;
            }
            else
            {
                doubleAnime.To = 0;
            }

            doubleAnime.EasingFunction = crcEase;
            doubleAnime.Duration = TimeSpan.FromMilliseconds(150 * stpCurrent.Children.Count);

            currentStackPanel.BeginAnimation(HeightProperty, doubleAnime);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //for (int i = 1; i < stpMenu.Children.Count; i += 2)
            //{
            //    StackPanel stpChild = (StackPanel)stpMenu.Children[i];
            //    for (int j = 0; j < stpChild.Children.Count; j++)
            //    {
            //        ((Button)stpChild.Children[j]).Width = 140;
            //        ((Button)stpChild.Children[j]).HorizontalContentAlignment = HorizontalAlignment.Left;
            //    }
            //}



            DoubleAnimation doubleAnime = new DoubleAnimation();
            CircleEase crcEase = new CircleEase() { EasingMode = EasingMode.EaseOut };

            if (stpMenu.Width == 0)
            {
                doubleAnime.To = 140;
                Grid grdMenu = (Grid)stpMenu.Parent;
                ColumnDefinition cml = grdMenu.ColumnDefinitions[0];
                cml.Width = new GridLength(140, GridUnitType.Pixel);
            }
            else
            {
                doubleAnime.To = 0;
            }

            doubleAnime.EasingFunction = crcEase;
            doubleAnime.Duration = TimeSpan.FromMilliseconds(1000);

            stpMenu.BeginAnimation(WidthProperty, doubleAnime);
        }

        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (stpMenu.Width < 150)
            //    return;
            //DoubleAnimation doubleAnime = new DoubleAnimation();
            //CircleEase crcEase = new CircleEase() { EasingMode = EasingMode.EaseOut };

            //    doubleAnime.To = ActualWidth / 7;


            //doubleAnime.EasingFunction = crcEase;
            //doubleAnime.Duration = TimeSpan.FromMilliseconds(1000);

            //stpMenu.BeginAnimation(WidthProperty, doubleAnime);
        }
    }
}
