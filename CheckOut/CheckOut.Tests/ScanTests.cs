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
    public class ScanTests
    {
        private CheckOut checkOut;

        #region TestData
        Item itemA = new Item { SKU = "A", UnitPrice = "50" };
        Item itemB = new Item { SKU = "B", UnitPrice = "30" };
        Item itemC = new Item { SKU = "C", UnitPrice = "20" };
        Item itemD = new Item { SKU = "D", UnitPrice = "15" };

        #endregion TestData


        [SetUp]
        public void Setup()
        {
            checkOut = new CheckOut();
            checkOut.items = new List<Item>();

        }

        [Test]
        public void Scan_Tests_No_Items()
        {
            List<Item> ExpectedResults = new List<Item>();
           
            foreach (Item item in ExpectedResults)
            {
                checkOut.Scan(item);
            }

            Assert.AreEqual(ExpectedResults, checkOut.items);
        }

        [Test]
        public void Scan_Tests_Single_Item()
        {
            List<Item> ExpectedResults = new List<Item> { itemA };

            foreach (Item item in ExpectedResults)
            {
                checkOut.Scan(item);
            }

            Assert.AreEqual(ExpectedResults, checkOut.items);
        }

        [Test]
        public void Scan_Tests_Muliple_Unique_Items()
        {
            List<Item> ExpectedResults = new List<Item>
            {
                itemA, itemB, itemC, itemD
            };

            foreach (Item item in ExpectedResults)
            {
                checkOut.Scan(item);
            }

            Assert.AreEqual(ExpectedResults, checkOut.items);
        }

        [Test]
        public void Scan_Tests_Muliple_Repeated_Items()
        {
            List<Item> ExpectedResults = new List<Item>
            {
                itemA, itemB, itemC, itemD, itemA, itemB, itemC, itemD
            };

            foreach (Item item in ExpectedResults)
            {
                checkOut.Scan(item);
            }

            Assert.AreEqual(ExpectedResults, checkOut.items);
        }
    }
}