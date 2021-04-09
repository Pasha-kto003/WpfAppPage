using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp16
{
    class DB
    {
       public static Entities2 Entities2;
       public static Entities2 GetDB()
        {
            if (Entities2 == null)
                Entities2 = new Entities2();
            return Entities2;
        } 
    }
}
