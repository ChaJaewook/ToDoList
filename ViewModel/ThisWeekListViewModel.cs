using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ToDoList.Util;
using ToDoList.View.SubForm;

namespace ToDoList.ViewModel
{
    public class ThisWeekListViewModel:NotifyChanged
    {
        #region 변수 정의
        AcsDBManager _manager;
        string _query = string.Empty;
        #endregion
        #region Binding 정의
        public ObservableCollection<ItemsControl> thisWeekList = new ObservableCollection<ItemsControl>();
        public ObservableCollection<ItemsControl> ThisWeekList
        {
            get { return thisWeekList; }
            set
            {
                thisWeekList = value;
                OnPropertyChanged("ThisWeekList");
            }
        }
        #endregion
        public ThisWeekListViewModel()
        {
            
            _manager = new AcsDBManager();

            _manager.OpenDB();

            DateTime startDate = DateTime.Today.AddDays(Convert.ToInt32(DayOfWeek.Monday) - Convert.ToInt32(DateTime.Today.DayOfWeek)); ;

            //item = null;
            ThisWeekList.Clear();
            for (int i = 0; i < 7; i++)
            {
                ItemsControl item = new ItemsControl();
                string searchDate = startDate.AddDays(i).ToString("yyyy-MM-dd");
                WeekListControl listControl = new WeekListControl();
                listControl.DataContext = new WeekListViewModel(searchDate);

                item.Items.Add(listControl);
                ThisWeekList.Add(item);
            }

            
            
        }
    }
}
