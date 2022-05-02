using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class WeekCheckListModel
    {
        public static List<string> uuidList=new List<string>();
        public WeekCheckListModel()
        {
            //uuidList = new List<string>();
            if(uuidList.Count>0)
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

        public List<string> GetUUIList()
        {
            return uuidList;
        }
        

    }
}
