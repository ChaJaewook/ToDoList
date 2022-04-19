using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoList.Util;
using ToDoList.View;
using ToDoList.View.SubForm;
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

        private ICommand delCheckListCommand;
        public ICommand DelCheckListCommand
        {
            get
            {
                return (this.delCheckListCommand) ?? (this.delCheckListCommand = new DelegateCommand(DelCheckListExecute));
            }
        }

        private ICommand modCheckListCommand;
        public ICommand ModCheckListCommand
        {
            get
            {
                return (this.modCheckListCommand) ?? (this.modCheckListCommand = new DelegateCommand(ModCheckListExecute));
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
            _query = String.Format("update ListTable set check='T' where ID={0}", UUID);
        }

        public void DelCheckListExecute()
        {
            /*InfoWindow infoWindow =new InfoWindow() ;
            InfoViewModel infoViewModel=    new InfoViewModel("Del", UUID);

            infoWindow.DataContext = infoViewModel;
            infoWindow.ShowDialog();*/

            if(MessageBox.Show("등록하기겠습니까?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                manager.OpenDB();
                _query = String.Format("delete *from ListTable where ID='{0}'", UUID);
                if (manager.Query(_query))
                    MessageBox.Show("삭제완료");

                manager.CloseDB();
              
            }

        }

        public void ModCheckListExecute()
        {
            InfoWindow infoWindow = new InfoWindow();
            InfoViewModel infoViewModel = new InfoViewModel("Mod", UUID);

            infoWindow.DataContext = infoViewModel;
            infoWindow.ShowDialog();
        }
    }
}
