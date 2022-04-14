using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.Util;
using ToDoList.ViewModel;
using ToDoList.ViewModel.Command;

namespace ToDoList.ViewModel
{
    class CheckListViewModel:NotifyChanged
    {

        #region 변수정리
        string _query;
        AcsDBManager manager = new AcsDBManager();
        DataSet result = null;
        #endregion

        #region Command 변수정의
        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return (this.submitCommand) ?? (this.submitCommand = new DelegateCommand(SubmitCommandExecute));
            }
        }
        #endregion
        #region Binding 변수정의
        private string checkListTitle;
        public string CheckListTitle
        {
            get
            {
                return checkListTitle;
            }
            set
            {
                checkListTitle = value;
                OnPropertyChanged("CheckListTitle");
            }
        }

        private string uuid;
        public string UUID
        {
            get { return uuid; }
            set
            {
                uuid = value;
                OnPropertyChanged("UUID");
            }
        }

        #endregion
        public CheckListViewModel()
        {

        }
        public CheckListViewModel(string p_title,string p_doDate, string p_check, string p_uuid)
        {
            CheckListTitle = p_title;
            UUID = p_uuid;
            
        }

        public void SubmitCommandExecute()
        {
            Console.WriteLine("check");
        }
    }
}
