using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoList.Model;
using ToDoList.Util;
using ToDoList.View.SubForm;
using ToDoList.ViewModel.Command;

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
        #region Command 변수정리
        public ICommand completeCommand;
        public ICommand CompleteCommand
        {
            get
            {
                return (this.completeCommand) ?? (this.completeCommand = new DelegateCommand(CompleteCommandExecute));
            }
        }



        public ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return (this.deleteCommand) ?? (this.deleteCommand = new DelegateCommand(DeleteCommandExecute));
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

        private void DeleteCommandExecute()
        {
            //throw new NotImplementedException();
            foreach (string uuid in WeekCheckListModel.uuidList)
            {
                _query = string.Format("DELETE * FROM ListTable WHERE ID_='{0}'", uuid);
                _manager.Query(_query);
            }

            _manager.CloseDB();
        }

        private void CompleteCommandExecute()
        {
            foreach (string uuid in WeekCheckListModel.uuidList)
            {
                _query = string.Format("UPDATE ListTable SET Check_='1' WEHRE ID_='{0}'", uuid);
                _manager.Query(_query);
            }
            _manager.CloseDB();
        }


    }
}
