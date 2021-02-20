using NUnit.Framework;
using TDDCabService;
namespace TDDCabServiceTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
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
    }
}