using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COR_EX.Concretclasses
{
    public class TeamLead: ILeaveRequestHandler
    {
        public ILeaveRequestHandler NextHandler { get; set; }

        public void HandleRequest(LeaveRequest Request)
        {
            if (Request.LeaveDays <= 10)
            {
                Console.WriteLine("Please wait for TeamLead, This will take care by HR");
            }
            else
            {
                NextHandler.HandleRequest(Request);
            }
        }
    }
}
