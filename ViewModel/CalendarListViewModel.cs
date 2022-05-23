using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToDoList.ViewModel
{
    public class CalendarListViewModel:NotifyChanged
    {
        /*public ObservableCollection<ItemsControl> calendarList = new ObservableCollection<ItemsControl>();
        public ObservableCollection<ItemsControl> CalendarList
        {
            get { return calendarList; }
            set
            {
                calendarList = value;
                OnPropertyChanged("ThisWeekList");
            }
        }*/
        public CalendarListViewModel()
        {

            Load();
        }

        public void Load()
        {

        }
    }
}
