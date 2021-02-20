using System;
using System.Collections.Generic;
using System.Text;

namespace TDDCabService
{
    public class Ride
    {
        public double distance;
        public double time;
        public Ride(double distance, double time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
