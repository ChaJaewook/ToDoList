using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.ViewModel.Command;
using ToDoList.View;
using System.Windows.Input;
using ToDoList.View.SubForm;

namespace ToDoList.ViewModel
{
    public class MainViewModel:NotifyChanged
    {
        public ICommand addInfoCommand;
        public ICommand AddInfoCommand
        {
            get
            {
                return (this.addInfoCommand) ?? (this.addInfoCommand =new DelegateCommand(AddInfoCommandExecute));
            }
        }
        public MainViewModel()
        {
            
        }

        private void AddInfoCommandExecute()
        {
            InfoWindow infoWindow = new InfoWindow();
            InfoViewModel infoViewModel = new InfoViewModel("Insert","");
            infoWindow.DataContext = infoViewModel;

            infoWindow.ShowDialog();

        }
    }
}
