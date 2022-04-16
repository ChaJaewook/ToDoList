using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoList.Util;
using ToDoList.ViewModel.Command;
using ToDoList.Util;

namespace ToDoList.ViewModel
{
    public class InfoViewModel:NotifyChanged
    {
        private string _query = "";
        AcsDBManager manager = new AcsDBManager();
        DataSet result = null;
        UUID getUUID = new UUID();


        #region Binding 변수정리
        private string pageTitle;
        public string PageTitle
        {
            get { return pageTitle; }
            set
            {
                pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }

        private string checkContent;
        public string CheckContent
        {
            get { return checkContent; }
            set
            {
                checkContent = value;
                OnPropertyChanged("CheckContent");
            }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        private DateTime doDate;
        public DateTime DoDate
        {
            get { return doDate; }
            set
            {
                doDate = value;
                OnPropertyChanged("DoDate");
            }
        }

        private string level;
        public string Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }

        #endregion

        #region Command 변수정리
        private ICommand checkCommand;
        public ICommand CheckCommand
        {
            get
            {
                return (this.checkCommand) ?? (this.checkCommand = new DelegateCommand(CheckCommandExecute));
            }
        }
        #endregion

        public InfoViewModel()
        {

        }

        public InfoViewModel(string p_div, string p_uuid)
        {
            manager.OpenDB();
            switch(p_div)
            {
                case "Mod":
                    ModInfo(p_uuid);
                    break;
                case "Insert":
                    InsertInfo();
                    break;
                default:
                    MessageBox.Show("Div Error");
                    break;
            }
        }

        private void ModInfo(string p_uuid)
        {
            CheckContent = "수정";
            PageTitle = "수정페이지";

            string uuid = p_uuid;
            _query = string.Format("select * from ListTable where ID='{0}'", uuid);

            result = manager.Select(_query);
            DataTable dataTable = result.Tables[0];

            DataRow row = dataTable.Rows[0];

            Title = row["Title"].ToString();
            Content = row["Content"].ToString();
            DoDate = Convert.ToDateTime(row["DoDate"].ToString());
            Level = row["Level"].ToString();
           

        }

        private void InsertInfo()
        {
            CheckContent = "추가";
            PageTitle = "추가페이지";

            Level = "3";
        }

        private void CheckCommandExecute()
        {

            /*switch(CheckContent)
            {
                case "수정":
                    _query="update "
                    break;
                case "추가":
                    _query = string.Format("insert into ListTable (ID,Title,Content,DoDate,RegDate,Level,Check) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                        getUUID.GetUUID(),Title,Content,DoDate,DateTime.Now,Level,"F");
                    break;

            }*/
        }

    }
}
