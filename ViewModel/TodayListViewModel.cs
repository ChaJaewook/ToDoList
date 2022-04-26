using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Util;
using ToDoList.ViewModel;
using ToDoList.View.SubForm;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ToDoList.ViewModel
{
    public class TodayListViewModel:NotifyChanged
    {
        #region 변수정리
        string _query;
        AcsDBManager manager = new AcsDBManager();
        DataSet result = null;
        #endregion

        #region Binding 변수정리
        private ObservableCollection<ItemsControl> checkList=new ObservableCollection<ItemsControl>();
        public ObservableCollection<ItemsControl> CheckList
        {
            get
            {
                return checkList;
            }
            set
            {
                checkList = value;
                OnPropertyChanged("CheckList");
            }
        }


        #endregion


        public TodayListViewModel()
        {
            
            result = new DataSet();
            ItemsControl item = new ItemsControl();

            manager.OpenDB();

            _query = string.Format("select * from ListTable where DoDate_='{0}'",DateTime.Now.ToString("yyyy-MM-dd"));

            result=manager.Select(_query);
            if(result.Tables.Count>0)
            {
                DataTable dataTable = result.Tables[0];
                foreach (DataRow row in dataTable.Rows)
                {

                    //CheckListViewModel checkListViewModel = new CheckListViewModel(row["Title"].ToString(), row["DoDate"].ToString(), row["Check"].ToString());
                    CheckListControl chkListControl = new CheckListControl();
                    chkListControl.DataContext = new CheckListViewModel(row["Title_"].ToString(), row["DoDate_"].ToString(), row["Check_"].ToString(), row["ID_"].ToString());
                    chkListControl.Margin = new System.Windows.Thickness { Top = 10, Bottom = 10 };
                    //chkListControl.DataContext = checkListViewModel;

                    item.Items.Add(chkListControl);
                }
            }

            CheckList.Clear();
            CheckList.Add(item);
        }
    }
}
