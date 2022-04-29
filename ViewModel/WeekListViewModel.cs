using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ToDoList.Util;
namespace ToDoList.ViewModel
{
    public class WeekListViewModel:NotifyChanged
    {
        #region 변수
        AcsDBManager _manager;
        DataSet _result;
        string _query = string.Empty;
        #endregion
        #region Binding 변수정리
        private string weekDate;
        public string WeekDate
        {
            get { return weekDate; }
            set
            {
                weekDate = value;
                OnPropertyChanged("WeekDate");
            }
        }

        private ObservableCollection<TextBlock> weekCheckList = new ObservableCollection<TextBlock>();
        public ObservableCollection<TextBlock> WeekCheckList
        {
            get
            {
                return weekCheckList;
            }
            set
            {
                weekCheckList = value;
                OnPropertyChanged("WeekCheckList");
            }
        }



        #endregion
        public WeekListViewModel()
        {
            _manager = new AcsDBManager();
            
        }

        public void Load()
        {
            _result = new DataSet();
            _manager.OpenDB();
            string startDate = DateTime.Today.AddDays(Convert.ToInt32(DayOfWeek.Monday) - Convert.ToInt32(DateTime.Today.DayOfWeek)).ToString("yyyy-MM-dd");
            string endDate= DateTime.Today.AddDays(Convert.ToInt32(DayOfWeek.Sunday) - Convert.ToInt32(DateTime.Today.DayOfWeek)).ToString("yyyy-MM-dd");

            _query = string.Format("select * from ListTable BETWEEN '{0}' and '{1} orderby DoDate_'", startDate, endDate);
            _result = _manager.Select(_query);
            /*for(int i=0;i<7;i++)
            {
                string searchDate = startDate.AddDays(i).ToString("yyyy-MM-dd");
                _query=string.Format("select * from where")


            }*/
            _manager.CloseDB();
        }
    }
}
