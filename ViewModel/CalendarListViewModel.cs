using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoList.ViewModel.Command;

namespace ToDoList.ViewModel
{
    public class CalendarListViewModel:NotifyChanged
    {
        #region Command 변수정의
        private ICommand prevMonthButton;
        public ICommand PrevMonthButton
        {
            get
            {
                return (this.prevMonthButton) ?? (this.prevMonthButton = new DelegateCommand(PrevMonthButtonExecute));
            }
        }



        private ICommand nextMonthButton;
        public ICommand NextMonthButton
        {
            get
            {
                return (this.nextMonthButton) ?? (this.nextMonthButton = new DelegateCommand(NextMonthButtonExecute));
            }
        }

        private void NextMonthButtonExecute()
        {
            
        }

        private void PrevMonthButtonExecute()
        {
            
        }

        #endregion

        #region Binding 변수정의
        public ObservableCollection<ItemsControl> calendarList = new ObservableCollection<ItemsControl>();
        public ObservableCollection<ItemsControl> CalendarList
        {
            get { return calendarList; }
            set
            {
                calendarList = value;
                OnPropertyChanged("ThisWeekList");
            }
        }

        

        private string calendarYear;
        public string CalendarYear
        {
            get
            {
                return calendarYear;
            }
            set
            {
                calendarYear = value;
                OnPropertyChanged("CalendarYear");
            }
        }

        private string calendarMonth;
        public string CalendarMonth
        {
            get
            {
                return calendarMonth;
            }
            set
            {
                calendarMonth = value;
                OnPropertyChanged("CalendarMonth");
            }
        }
        #endregion

        public CalendarListViewModel()
        {

            Load();
        }

        public void Load()
        {
            CalendarYear = DateTime.Now.ToString("yyyy");
            CalendarMonth = DateTime.Now.ToString("MM");
        }


    }
}
