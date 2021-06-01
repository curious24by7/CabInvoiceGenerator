using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void GivenDistanceAndTime_ShouldReturn_TotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenMultipleRide_ShouldReturn_InvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }
        [Test]
        public void GivenMultipleRide_ShouldReturn_TotalNoRides_Fare_AverageFarePerRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 3) };
            InvoiceSummary enhancedSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedEnhancedSummary = new InvoiceSummary(2, 30);
            Assert.AreEqual(expectedEnhancedSummary, enhancedSummary);
        }
    }
}
