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

        #region TestData

        static Item itemA = new Item { SKU = "A", UnitPrice = 50 };
        static Item itemB = new Item { SKU = "B", UnitPrice = 30 };
        static Item itemC = new Item { SKU = "C", UnitPrice = 20 };
        static Item itemD = new Item { SKU = "D", UnitPrice = 15 };

        static ItemSpecialPrice itemSpecialPriceA = new ItemSpecialPrice { SKU = "A", Quantity = 3, Price = 130 };
        static ItemSpecialPrice itemSpecialPriceA_Single = new ItemSpecialPrice { SKU = "A", Quantity = 1, Price = 25 };
        static ItemSpecialPrice itemSpecialPriceB = new ItemSpecialPrice { SKU = "B", Quantity = 2, Price = 45 };
        

        List<Item> ItemsNo_Items = new List<Item>();
        List<Item> Items_Single_Item = new List<Item> { itemA };
        List<Item> Items_Multiple_Unique_Items = new List<Item>{ itemA, itemB, itemC, itemD };
        List<Item> Items_Multiple_Repeated_Items = new List<Item>{ itemA, itemA, itemB, itemC, itemD, itemA, itemB, itemC, itemD };
        List<Item> Items_Multiple_Repeated_Items_Extra = new List<Item> { itemA, itemB, itemB, itemC, itemD, itemA, itemA, itemA, itemB, itemC, itemA, itemB, itemD, itemB };

        List<ItemSpecialPrice> specialPrices_Empty = new List<ItemSpecialPrice>();
        List<ItemSpecialPrice> specialPrices_A_B = new List<ItemSpecialPrice> { itemSpecialPriceA, itemSpecialPriceB };
        List<ItemSpecialPrice> specialPrices_A_Single_B = new List<ItemSpecialPrice> { itemSpecialPriceA_Single, itemSpecialPriceB };

        #endregion TestData

        [SetUp]
        public void Setup()
        {
            checkOut = new CheckOut();
        }

        [Test]
        public void CheckOut_NoItems()
        {
            checkOut.items = ItemsNo_Items;
            checkOut.itemSpecialPrices = specialPrices_Empty;
            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(0, Result); ;
        }

        [Test]
        public void CheckOut_Single_Item_Standard()
        {
            checkOut.items = Items_Single_Item;
            checkOut.itemSpecialPrices = specialPrices_Empty;

            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(50, Result); ;
        }

        [Test]
        public void CheckOut_Single_Item_Special()
        {
            checkOut.items = Items_Single_Item;
            checkOut.itemSpecialPrices = specialPrices_A_Single_B;

            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(25, Result); ;
        }

        [Test]
        public void CheckOut_Mutiple_Unique_Items_Standard()
        {
            checkOut.items = Items_Multiple_Unique_Items;
            checkOut.itemSpecialPrices = specialPrices_Empty;

            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(115, Result); ;
        }

        [Test]
        public void CheckOut_Mutiple_Unique_Items_Mixed()
        {
            checkOut.items = Items_Multiple_Unique_Items;
            checkOut.itemSpecialPrices = specialPrices_A_Single_B;

            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(90, Result); ;
        }

        [Test]
        public void CheckOut_Mutiple_Repeated_Items_Standard()
        {
            checkOut.items = Items_Multiple_Repeated_Items;
            checkOut.itemSpecialPrices = specialPrices_Empty;

            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(280, Result); ;
        }

        [Test]
        public void CheckOut_Mutiple_Repeated_Items_Special_Exact()
        {
            checkOut.items = Items_Multiple_Repeated_Items;
            checkOut.itemSpecialPrices = specialPrices_A_B;

            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(245, Result); ;
        }

        [Test]
        public void CheckOut_Mutiple_Repeated_Items_Special_Extra()
        {
            checkOut.items = Items_Multiple_Repeated_Items_Extra;
            checkOut.itemSpecialPrices = specialPrices_A_B;

            int Result = checkOut.GetTotalPrice();
            Assert.AreEqual(420, Result); ;
        }
    }
}