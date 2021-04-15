using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void MainViewLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            Button btn = (Button)sender;
            Grid currentGrid;

            switch (btn.Name)
            {
                case nameof(btnInfo):
                    currentGrid = grdInfo;
                    break;
                case nameof(btnScore):
                    currentGrid = grdScore;
                    break;
                case nameof(btnOperation):
                    currentGrid = grdOperation;
                    break;
                default:
                    return;
            }

            StackPanel stackPanel = (StackPanel)currentGrid.Children[0];
            if (currentGrid.Height == 0)
            {
                doubleAnimation.To = stackPanel.Children.Count * 40;
            }
            else
            {
                doubleAnimation.To = 0;
            }
            CircleEase crcEase = new CircleEase()
            {
                EasingMode = EasingMode.EaseOut
            };

            doubleAnimation.EasingFunction = crcEase;
            doubleAnimation.Duration = TimeSpan.FromMilliseconds(stackPanel.Children.Count * 150);
            currentGrid.BeginAnimation(HeightProperty, doubleAnimation);
        }

        private void btnResizeClick(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            CircleEase crcEase = new CircleEase() { EasingMode = EasingMode.EaseOut };

            if (wrpMenuBar.Width == 0)
            {
                doubleAnimation.To = 140;
                btnResize.Content = "<";
            }
            else
            {
                doubleAnimation.To = 0;
                btnResize.Content = ">";
            }

            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            doubleAnimation.EasingFunction = crcEase;

            wrpMenuBar.BeginAnimation(WidthProperty, doubleAnimation);
        }
    }
}
