using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class WeekCheckListModel
    {
        static List<string> uuidList;
        public WeekCheckListModel()
        {
            uuidList.Clear();
        }

        public void checkUUID(string p_uuid)
        {
            uuidList.Add(p_uuid);
        }

        public void uncheckUUID(string p_uuid)
        {
            uuidList.Remove(p_uuid);
        }
        

    }
}
