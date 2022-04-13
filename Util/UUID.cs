using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Util
{
    class UUID
    {
        
        public UUID()
        {
           
        }

        public string GetUUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
