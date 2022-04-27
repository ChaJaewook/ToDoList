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
using System.Windows;
using ToDoList.View;
using System.Windows.Navigation;

namespace ToDoList.View
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.mainFrame.Navigate(new Uri("View/TodayList.xaml", UriKind.RelativeOrAbsolute));
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void SizeButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState==WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else if(this.WindowState==WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void NavigateTodayList(object sender, RoutedEventArgs e)
        {
            this.mainFrame.Navigate(new Uri("View/TodayList.xaml", UriKind.RelativeOrAbsolute));
        }

        private void NavigateWeekendList(object sender, RoutedEventArgs e)
        {
            this.mainFrame.Navigate(new Uri("View/WeekList.xaml", UriKind.RelativeOrAbsolute));
        }

        private void NavigateCalendarList(object sender, RoutedEventArgs e)
        {
            this.mainFrame.Navigate(new Uri("View/CalendarList.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TitleBar_Click(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
