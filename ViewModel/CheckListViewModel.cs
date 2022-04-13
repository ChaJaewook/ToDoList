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

        #endregion
        public CheckListViewModel()
        {

        }
        public CheckListViewModel(string p_title,string p_doDate, string p_check)
        {
            CheckListTitle = p_title;
            
        }

        public void SubmitCommandExecute()
        {

        }

        public bool CanExecuteMethod(object arg)
        {
            return true;
        }
    }
}
