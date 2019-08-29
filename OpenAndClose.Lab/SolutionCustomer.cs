using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAndClose.Lab
{
    class SolutionCustomer
    {
        public virtual double getDiscount(double TotalSales)
        {
            return TotalSales;
        }

    }
    class SilverCustomer : SolutionCustomer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 50;
        }
    }

    class goldCustomer : SilverCustomer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 100;
        }
    }
}
