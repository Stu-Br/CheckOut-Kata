using CheckOut;
using NUnit.Framework;
using System.Collections.Generic;

namespace CheckOut.Tests
{
    public class ScanTests
    {
        private CheckOut checkOut;

        #region TestData
        static Item itemA = new Item { SKU = "A", UnitPrice = 50 };
        static Item itemB = new Item { SKU = "B", UnitPrice = 30 };
        static Item itemC = new Item { SKU = "C", UnitPrice = 20 };
        static Item itemD = new Item { SKU = "D", UnitPrice = 15 };

        List<Item> ExpectedResults_No_Items = new List<Item>();
        List<Item> ExpectedResults_Single_Item = new List<Item> { itemA };
        List<Item> ExpectedResults_Multiple_Unique_Items = new List<Item>
            {
                itemA, itemB, itemC, itemD
            };

        List<Item> ExpectedResults_Multiple_Repeated_Items = new List<Item>
            {
                itemA, itemB, itemC, itemD, itemA, itemB, itemC, itemD
            };

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
            foreach (Item item in ExpectedResults_No_Items)
            {
                checkOut.Scan(item);
            }

            Assert.AreEqual(ExpectedResults_No_Items, checkOut.items);
        }

        [Test]
        public void Scan_Tests_Single_Item()
        {
            foreach (Item item in ExpectedResults_Single_Item)
            {
                checkOut.Scan(item);
            }

            Assert.AreEqual(ExpectedResults_Single_Item, checkOut.items);
        }

        [Test]
        public void Scan_Tests_Muliple_Unique_Items()
        {
            foreach (Item item in ExpectedResults_Multiple_Unique_Items)
            {
                checkOut.Scan(item);
            }

            Assert.AreEqual(ExpectedResults_Multiple_Unique_Items, checkOut.items);
        }

        [Test]
        public void Scan_Tests_Muliple_Repeated_Items()
        {
            foreach (Item item in ExpectedResults_Multiple_Repeated_Items)
            {
                checkOut.Scan(item);
            }

            Assert.AreEqual(ExpectedResults_Multiple_Repeated_Items, checkOut.items);
        }
    }
}