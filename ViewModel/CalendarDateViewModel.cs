﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Util;

namespace ToDoList.ViewModel
{
    public class CalendarDateViewModel:NotifyChanged
    {
        AcsDBManager manager = new AcsDBManager();
        string _query = string.Empty;
        DataSet _result = null;


        public ObservableCollection<CalendarControlData>  ToDoList{ get; set; }

        public class CalendarControlData
        {
            public string UUID;
            public string ToDoData;

        }
        #region Binding 변수정의

        /*private string todoData;
        public string ToDoData
        {
            get
            {
                return todoData;
            }
            set
            {
                todoData = value;
                OnPropertyChanged("ToDoData");
            }
        }

        private string uuid;
        public string UUID
        {
            get
            {
                return uuid;
            }
            set
            {
                uuid = value;
                OnPropertyChanged("UUID");
            }
        }*/

        private string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        #endregion

        public CalendarDateViewModel()
        {
            
        }
        public CalendarDateViewModel(string p_year, string p_month, string p_day)
        {
            manager.OpenDB();
            ToDoList = new ObservableCollection<CalendarControlData>();
            _query = string.Format("select * from ListTable where DoDate_ like '{0}'",p_year+"-"+p_month+"-"+p_day);
            
            try
            {
                _result = manager.Select(_query);
                DataTable dataTable = _result.Tables[0];

                Date = p_day;

                foreach(DataRow row in dataTable.Rows)
                {
                    ToDoList.Add(new CalendarControlData { ToDoData = row["Content_"].ToString(), UUID = row["ID_"].ToString() });
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                manager.CloseDB();
            }



        }
    }
}
