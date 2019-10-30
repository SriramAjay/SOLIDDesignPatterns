using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COR_EX.Concretclasses;

namespace COR_EX
{


    class Program
    {
        static void Main(string[] args)
        {
            //Pass request
            LeaveRequest Request = new LeaveRequest();
            Request.EmpName = "Ajay";
            Request.LeaveDays = 25;

            // Create oobject with Abstraction
            ILeaveRequestHandler hr = new HR();
            ILeaveRequestHandler pm = new PeojectManager();
            ILeaveRequestHandler TL = new TeamLead();
            //Define hierarchy
            TL.NextHandler = pm;
            pm.NextHandler = hr;
            hr.NextHandler = null;
            // call from low level request. If pass then it will success based on request other wise it send to next object
            TL.HandleRequest(Request);
            Console.ReadLine();
        }
    }
}
