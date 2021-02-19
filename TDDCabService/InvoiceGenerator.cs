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
        double totalFare;
        List<Ride> rides;
        public InvoiceGenerator()
        {
            totalFare = 0;
        }
        public double returnTotalFareForMultipleRides(List<Ride> rides)
        {
            foreach (Ride ride in rides)
            {
                totalFare += returnTotalFareForSingleRide(ride);
            }
            return totalFare;
        }
        public double returnTotalFareForSingleRide(Ride ride)
        {
            return Math.Max(minimumFare , ride.distance * pricePerKilometer + ride.time * pricePerMinute);
        }
    }
}
