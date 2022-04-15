using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoList.Util;

namespace ToDoList.ViewModel
{
    public class InfoViewModel:NotifyChanged
    {
        private string _query = "";
        AcsDBManager manager = new AcsDBManager();
        DataSet result = null;

        #region Binding 변수정리
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
                case "Del":
                    break;
                default:
                    MessageBox.Show("Div Error");
                    break;
            }
        }

        private void ModInfo(string p_uuid)
        {
            CheckContent = "수정";

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

    }
}
