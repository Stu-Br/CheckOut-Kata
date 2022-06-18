using CheckOut;
using NUnit.Framework;
using System.Collections.Generic;

namespace CheckOut.Tests
{
    

//    SKU Unit    Price   Special Price
//A           50	    3 for 130
//B	        30	    2 for 45
//C	        20	
//D	        15	
    public class CheckoutTests
    {
        private CheckOut checkOut;

        [SetUp]
        public void Setup()
        {
            checkOut = new CheckOut();
        }
        [TestCase(new object[] {""}, new object[] { "" }, TestName = "Scan Test No Items")]
        [TestCase(new object[] { "A" }, new object[] { "A" }, TestName = "Scan Test Single Item")]
        [TestCase(new object[] { "A", "B" }, new object[] { "A", "B" }, TestName = "Scan Test Multiple Items")]
        public void Scan_Tests(List<string> Input, List<string> ExpectedResult)
        {
            Assert.AreEqual(ExpectedResult, checkOut.items);
        }

        [Test]
        public void CheckOut_NoItems()
        {
            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(0, Result); ;
        }
    }
}