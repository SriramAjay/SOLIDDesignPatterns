using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COR_EX.Concretclasses
{
    public class HR : ILeaveRequestHandler
    {
        public ILeaveRequestHandler NextHandler { get; set; }

        public void HandleRequest(LeaveRequest Request)
        {
            if (Request.LeaveDays > 30)
            {
                Console.WriteLine("Please wait for HR, This will take care by HR");
            }
            else {
                NextHandler.HandleRequest(Request);
            }
        }
    }
}
