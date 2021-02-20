using NUnit.Framework;
using TDDCabService;
using System.Collections.Generic;
namespace TDDCabServiceTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        RideRepository rideRepository;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
            rideRepository = new RideRepository();
        }

        [Test]
        [TestCase(2,4,24)]
        [TestCase(0.1,0.1,5)]
        public void GivenTimeAndDistance_calculateFare(double distance,double time,double output)
        {
            Ride ride = new Ride(distance,time);
            Assert.AreEqual(output,invoiceGenerator.returnTotalFareForSingleRide(ride));
        }

        [Test]
        public void GivenInvalidDistance_ThrowException()
        {
            Ride ride = new Ride(-1, 1);
            InvoiceGeneratorException invoiceGeneratorException =  Assert.Throws<InvoiceGeneratorException>(() => invoiceGenerator.returnTotalFareForSingleRide(ride));
            Assert.AreEqual(invoiceGeneratorException.type, InvoiceGeneratorException.ExceptionType.INVALID_DISTANCE);
        }
        [Test]
        public void GivenInvalidTime_ThrowException()
        {
            Ride ride = new Ride(1, -1);
            InvoiceGeneratorException invoiceGeneratorException2 = Assert.Throws<InvoiceGeneratorException>(() => invoiceGenerator.returnTotalFareForSingleRide(ride));
            Assert.AreEqual(invoiceGeneratorException2.type, InvoiceGeneratorException.ExceptionType.INVALID_TIME);
        }
        [Test]
        public void GivenListOfRides_GenerateInvoice()
        {
            Ride ride1 = new Ride(1, 1);
            Ride ride2 = new Ride(2, 1);
            Ride ride3 = new Ride(1, 1);
            List<Ride> rides = new List<Ride>();
            rides.Add(ride1);
            rides.Add(ride2);
            rides.Add(ride3);
            Assert.AreEqual(43.0d,invoiceGenerator.returnTotalFareForMultipleRides(rides));
            Assert.AreEqual(14.333333333333334d, invoiceGenerator.averagePerRide);
            Assert.AreEqual(3, invoiceGenerator.numberOfRides);
        }
        [Test]
        public void GivenValidUserId_GenerateInvoice()
        {
            Ride ride1 = new Ride(1, 1);
            Ride ride2 = new Ride(2, 1);
            Ride ride3 = new Ride(1, 1);
            rideRepository.AddToRideRepository("Dipesh", ride1);
            rideRepository.AddToRideRepository("Dipesh", ride2);
            rideRepository.AddToRideRepository("Dipesh", ride3);
            Assert.AreEqual(43.0d, invoiceGenerator.returnTotalFareForMultipleRides(rideRepository.returnListByUserId("Dipesh")));
            Assert.AreEqual(14.333333333333334d, invoiceGenerator.averagePerRide);
            Assert.AreEqual(3, invoiceGenerator.numberOfRides);
        }
        [Test]
        public void GivenInValidUserId_GenerateInvoice()
        {
            Ride ride1 = new Ride(1, 1);
            Ride ride2 = new Ride(2, 1);
            Ride ride3 = new Ride(1, 1);
            rideRepository.AddToRideRepository("Dipesh", ride1);
            rideRepository.AddToRideRepository("Dipesh", ride2);
            rideRepository.AddToRideRepository("Dipesh", ride3);
            var Exception = Assert.Throws<InvoiceGeneratorException>(() => invoiceGenerator.returnTotalFareForMultipleRides(rideRepository.returnListByUserId("Dhanesh")));
            Assert.AreEqual(Exception.type, InvoiceGeneratorException.ExceptionType.INVALID_USER_ID);
        }

    }
}