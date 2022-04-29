using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToDoList.ViewModel
{
    public class ThisWeekListViewModel:NotifyChanged
    {
        #region Binding 정의
        ObservableCollection<ItemsControl> thisWeekList = new ObservableCollection<ItemsControl>();
        ObservableCollection<ItemsControl> ThisWeekList
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
            
        }
    }
}
