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
            checkOut.items = new List<string>();

        }
        [TestCase("", "", TestName = "Scan Test No Items")]
        [TestCase("A", "A", TestName = "Scan Test Single Item")]
        [TestCase("A,B,A,B", "A,B,A,B", TestName = "Scan Test Multiple Items")]
        public void Scan_Tests(string Input, string ExpectedResult)
        {
            var itemArray = Input.Split(',');
            var resultArray = ExpectedResult.Split(',');
            
            foreach (string item in itemArray)
            {
                checkOut.Scan(item);
            }

            Assert.AreEqual(resultArray, checkOut.items);
        }

        [Test]
        public void CheckOut_NoItems()
        {
            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(0, Result); ;
        }
    }
}