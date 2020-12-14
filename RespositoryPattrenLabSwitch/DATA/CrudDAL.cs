using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryPattrenLabSwitch.DATA
{
   static public class CrudDAL
    {
       static public List<PS_MANUFACTURER> GETDATA() {
            using ( var Context=new SWITCHDBEntities())
            {
                return Context.PS_MANUFACTURER.ToList();
            }

            //return null;
        }
    }
}
