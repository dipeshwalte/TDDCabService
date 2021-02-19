using System;
using System.Collections.Generic;
using System.Text;

namespace TDDCabService
{
    class InvoiceGenerator
    {
        readonly int pricePerKilometer = 10;
        readonly int pricePerMinute = 1;
        readonly int minimumFare = 5;
        public double returnTotalFare(double distance, double time)
        {
            return Math.Max(minimumFare , distance * pricePerKilometer + time * pricePerMinute);
        }
    }
}
