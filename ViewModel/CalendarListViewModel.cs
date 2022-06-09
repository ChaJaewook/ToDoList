using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoList.View.SubForm;
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
            int monthAdder = 0;
            int yearAdder = 0;
            if(int.TryParse(CalendarMonth,out monthAdder))
            {
                monthAdder = int.Parse(CalendarMonth);
            }
            
            if(int.TryParse(CalendarYear,out yearAdder))
            {
                yearAdder = int.Parse(CalendarYear);
            }

            monthAdder++;

            if(monthAdder>12)
            {
                yearAdder++;
                monthAdder = 1;
            }
            if(monthAdder>1&&monthAdder<10)
            {
                CalendarMonth = monthAdder.ToString("00");
            }
            else
            {
                CalendarMonth = monthAdder.ToString();
            }
            
            CalendarYear = yearAdder.ToString();

            Load(CalendarYear, calendarMonth);

        }

        private void PrevMonthButtonExecute()
        {
            int monthAdder = 0;
            int yearAdder = 0;
            if (int.TryParse(CalendarMonth, out monthAdder))
            {
                monthAdder = int.Parse(CalendarMonth);
            }

            if (int.TryParse(CalendarYear, out yearAdder))
            {
                yearAdder = int.Parse(CalendarYear);
            }

            monthAdder--;

            if (monthAdder < 1)
            {
                yearAdder--;
                monthAdder = 12;
            }

            if (monthAdder > 1 && monthAdder < 10)
            {
                CalendarMonth = monthAdder.ToString("00");
            }
            else
            {
                CalendarMonth = monthAdder.ToString();
            }
            CalendarYear = yearAdder.ToString();
            Load(CalendarYear, calendarMonth);
        }

        #endregion

        #region Binding 변수정의
        public ObservableCollection<ItemsControl> calendarToDoList = new ObservableCollection<ItemsControl>();
        public ObservableCollection<ItemsControl> CalendarToDoList
        {
            get { return calendarToDoList; }
            set
            {
                calendarToDoList = value;
                OnPropertyChanged("CalendarToDoList");
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
            CalendarYear = DateTime.Now.ToString("yyyy");
            CalendarMonth = DateTime.Now.ToString("MM");

            Load(CalendarYear, CalendarMonth);
        }

        public void Load(string year, string month)
        {
            
            if(CalendarToDoList!=null)
            {
                CalendarToDoList.Clear();
            }

            int lastDay = DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(month));


            for (int day=1;day<=lastDay;day++)
            {
                ItemsControl item = new ItemsControl();
                CalendarDateControl calendarControl = new CalendarDateControl();
                calendarControl.DataContext = new CalendarDateViewModel(CalendarYear, CalendarMonth,day.ToString("D2"));
                item.Items.Add(calendarControl);
                calendarToDoList.Add(item);
            }

        }


    }
}
