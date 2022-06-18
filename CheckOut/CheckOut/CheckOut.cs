using System;
using System.Collections.Generic;

namespace CheckOut
{
    interface ICheckout
    {
        List<Item> items { get; set; }
        List<ItemSpecialPrice> itemSpecialPrices { get; set; }
        void Scan(Item item);
        int GetTotalPrice();
    }

    public class CheckOut : ICheckout
    {
        public List<Item> items { get; set; }
        public List<ItemSpecialPrice> itemSpecialPrices { get; set; }


        public void Scan(Item item)
        {
            try
            {
                items.Add(item);
            }
            catch (Exception ex)
            {
                // ToDo standard logging here
                throw ex;
            }

        }

        public int GetTotalPrice()
        {
            return 0;
        }
    }
}
