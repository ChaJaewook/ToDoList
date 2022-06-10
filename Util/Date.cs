using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Util
{
    public class Date
    {
        public int emptyDay;
        public Date()
        {
            emptyDay = -1;
        }

        public int getDayEmpty(DateTime dateData)
        {
            
            switch(dateData.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    emptyDay = 0;
                    break;
                case DayOfWeek.Monday:
                    emptyDay=1;
                    break;
                case DayOfWeek.Tuesday:
                    emptyDay = 2;
                    break;
                case DayOfWeek.Wednesday:
                    emptyDay = 3;
                    break;
                case DayOfWeek.Thursday:
                    emptyDay = 4;
                    break;
                case DayOfWeek.Friday:
                    emptyDay = 5;
                    break;
                case DayOfWeek.Saturday:
                    emptyDay = 6;
                    break;
                default:
                    emptyDay = -1;
                    break;

            }

            return emptyDay;
        }
    }
}
