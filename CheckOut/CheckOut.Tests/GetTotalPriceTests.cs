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
    public class GetTotalPriceTests
    {
        private CheckOut checkOut;

        [SetUp]
        public void Setup()
        {
            checkOut = new CheckOut();
            checkOut.items = new List<Item>();
            checkOut.itemSpecialPrices = new List<ItemSpecialPrice>();
        }

        [Test]
        public void CheckOut_NoItems()
        {
            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(0, Result); ;
        }
    }
}