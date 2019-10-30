using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COR_EX
{
   public interface ILeaveRequestHandler
    {
        void HandleRequest(LeaveRequest leave);
        ILeaveRequestHandler NextHandler { get; set; }
    }
}
