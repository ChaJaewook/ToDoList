using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.ViewModel
{
    public class WeekCheckListViewModel:NotifyChanged
    {

        #region Binding 변수정리
        private bool checkBox;
        public bool CheckBox
        {
            get { return checkBox; }
            set
            {
                checkBox = value;
                OnPropertyChanged("CheckBox");
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
        #endregion
        public WeekCheckListViewModel()
        {
                
        }

        public WeekCheckListViewModel(string p_content, string p_uuid)
        {
            Content = p_content;

        }
    }
}
