using System;
using System.Collections.Generic;
using System.Text;

namespace TDDCabService
{
   public class InvoiceGenerator
    {
        public enum ServiceType
        { NORMAL_RIDE,PREMIUM_RIDE }
        readonly int pricePerKilometer;
        readonly int pricePerMinute;
        readonly int minimumFare;
        public double totalFare;
        public int numberOfRides;
        public double averagePerRide;
        public InvoiceGenerator(ServiceType type)
        {
            if (type == ServiceType.NORMAL_RIDE)
            {
                this.pricePerKilometer = 10;
                this.pricePerMinute = 1;
                this.minimumFare = 5;
            }
            else if (type == ServiceType.PREMIUM_RIDE)
            {
                this.pricePerKilometer = 15;
                this.pricePerMinute = 2;
                this.minimumFare = 20;
            }
            totalFare = 0;
            numberOfRides = 0;
        }
        /// <summary>
        /// Returns the total fare for multiple rides.
        /// </summary>
        /// <param name="rides">The rides.</param>
        /// <returns></returns>
        public double returnTotalFareForMultipleRides(List<Ride> rides)
        {
            foreach (Ride ride in rides)
            {
                totalFare += returnTotalFareForSingleRide(ride);
                numberOfRides += 1;
            }
            averagePerRide = totalFare / numberOfRides;
            return totalFare;
        }
        /// <summary>
        /// Returns the total fare for single ride.
        /// </summary>
        /// <param name="ride">The ride.</param>
        /// <returns></returns>
        /// <exception cref="InvoiceGeneratorException">
        /// Invalid distance encountered!
        /// or
        /// Invalid time encountered!
        /// </exception>
        public double returnTotalFareForSingleRide(Ride ride)
        {
           // try
           // {
                if (ride.distance < 0)
                {
                    throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_DISTANCE, "Invalid distance encountered!");
                }
                if (ride.time < 0)
                {
                    throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_TIME, "Invalid time encountered!");
                }
                return Math.Max(minimumFare, ride.distance * pricePerKilometer + ride.time * pricePerMinute);
            //}
            //catch (Exception ex)
           // {
             //   Console.WriteLine(ex.Message); 
            //}
            
        }
    }
}
