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
using ToDoList.ViewModel;

namespace ToDoList.View.SubForm
{
    /// <summary>
    /// InfoWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
            InfoViewModel infoViewModel = new InfoViewModel();
            this.DataContext = infoViewModel;
            if(infoViewModel.CloseAction==null)
            {
                infoViewModel.CloseAction = new Action(this.Close);
            }
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
