using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COR_EX.Concretclasses
{
    public class PeojectManager:ILeaveRequestHandler
    {
        public ILeaveRequestHandler NextHandler { get; set; }

        public void HandleRequest(LeaveRequest Request)
        {
            if (Request.LeaveDays > 10 && Request.LeaveDays <=30)
            {
                Console.WriteLine("Please wait for ProjectManager, This will take care by ProjectManager");
            }
            else
            {
                NextHandler.HandleRequest(Request);
            }
        }
    }
}
