using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Util
{
    public class Checker
    {
        public bool IsNullOrEmpty(string data)
        {
            if (data.Equals("") || data == null)
                return true;
            else
                return false;
        }
    }
}
