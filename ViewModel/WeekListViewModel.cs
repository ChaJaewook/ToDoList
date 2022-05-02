using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoList.Util;
using ToDoList.View.SubForm;
using ToDoList.ViewModel.Command;
using ToDoList.Model;
namespace ToDoList.ViewModel
{
    public class WeekListViewModel:NotifyChanged
    {
        #region 변수
        
        AcsDBManager _manager;
        
        
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

        private ObservableCollection<ItemsControl> weekCheckList = new ObservableCollection<ItemsControl>();
        public ObservableCollection<ItemsControl> WeekCheckList
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
            //_manager = new AcsDBManager();
            
        }

        public WeekListViewModel(string p_serachDate)
        {
            _manager = new AcsDBManager();
            Load(p_serachDate);
        }

        public void Load(string p_searchDate)
        {
            ItemsControl item = new ItemsControl();
            DataSet result = new DataSet();
            string searchDate = p_searchDate;
            _manager.OpenDB();
            
            //string startDate = DateTime.Today.AddDays(Convert.ToInt32(DayOfWeek.Monday) - Convert.ToInt32(DateTime.Today.DayOfWeek)).ToString("yyyy-MM-dd");
            //string endDate= DateTime.Today.AddDays(Convert.ToInt32(DayOfWeek.Sunday) - Convert.ToInt32(DateTime.Today.DayOfWeek)).ToString("yyyy-MM-dd");

            _query = string.Format("select * from ListTable where DoDate_='{0}'", searchDate);
            result = _manager.Select(_query);

            WeekDate = searchDate;
            
            if (result.Tables.Count > 0)
            {
                DataTable dataTable = result.Tables[0];
                foreach(DataRow row in dataTable.Rows)
                {
                    /*CheckBox chekBox = new CheckBox();
                    TextBox text = new TextBox();
                    
                    text.IsReadOnly = true;
                    text.Text = row["Content_"].ToString();*/

                    WeekCheckListControl weekListControl = new WeekCheckListControl();
                    weekListControl.DataContext = new WeekCheckListViewModel(row["Content_"].ToString(), row["ID_"].ToString());
                    
                    item.Items.Add(weekListControl);

                    
                }
            }
            WeekCheckList.Clear();
            WeekCheckList.Add(item);
            _manager.CloseDB();
        }




    }
}
