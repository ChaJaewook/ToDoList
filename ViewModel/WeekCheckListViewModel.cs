using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList.ViewModel
{
    public class WeekCheckListViewModel:NotifyChanged
    {

        #region  모델
        WeekCheckListModel checkModel;
        #endregion

        #region Binding 변수정리
        private bool checkBox;
        public bool CheckBox
        {
            get { return checkBox; }
            set
            {
                checkBox = value;
                OnPropertyChanged("CheckBox");
                CheckBoxState();
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
        public WeekCheckListViewModel()
        {
                
        }

        public WeekCheckListViewModel(string p_content, string p_uuid)
        {
            Content = p_content;
            UUID = p_uuid;

            //checkModel = new WeekCheckListModel();
            WeekCheckListModel.uuidList.Clear();

        }

        public void CheckBoxState()
        {
            if(CheckBox==true)
            {
                WeekCheckListModel.uuidList.Add(UUID);
                //checkModel.checkUUID(UUID);
            }
            else if(CheckBox==false)
            {
                WeekCheckListModel.uuidList.Remove(UUID);
                //checkModel.uncheckUUID(UUID);
            }
            
            /*List<string> a = checkModel.GetUUIList();*/

            /*foreach(string s in WeekCheckListModel.uuidList)
            {
                Console.WriteLine(s);
            }*/
        }
    }
}
