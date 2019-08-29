﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAndClose.Lab
{
    /*The problem is if we add a new customer type we need to go and add one more “IF” condition in the 
     * “getDiscount” function, in other words we need to change the customer class.
     * If we are changing the customer class again and again, we need to ensure that the previous conditions
     * with new one’s are tested again , existing client’s which are referencing this class are working properly as before.
     * Solution:- Rather than “MODIFYING” we go for “EXTENSION”. It supports "decorator pattern"
     * */
    public class Customer
    {
        private int _CustType;

        public int CustType
        {
            get { return _CustType; }
            set { _CustType = value; }
        }

        public double getDiscount(double TotalSales)
        {
            if (_CustType == 1)
            {
                return TotalSales - 100;
            }
            else
            {
                return TotalSales - 50;
            }
        }
    }

}
