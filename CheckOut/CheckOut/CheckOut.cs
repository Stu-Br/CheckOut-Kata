using System;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                int total = 0;
                var itemsGrouped = items.GroupBy(x => x.SKU);

                foreach (var itemGroup in itemsGrouped)
                {
                    var groupSpecialPrices = itemSpecialPrices.FirstOrDefault(x => x.SKU == itemGroup.Key);

                    int count = itemGroup.Count();

                    if (groupSpecialPrices != null)
                    {
                        while (count >= groupSpecialPrices.Quantity)
                        {
                            total += groupSpecialPrices.Price;
                            count -= groupSpecialPrices.Quantity;
                        }

                        if (count > 0)
                        {
                            total += count * itemGroup.First().UnitPrice;
                        }
                    }
                    else
                    {
                        total += count * itemGroup.First().UnitPrice;
                    }
                }
                return total;
            }
            catch (Exception ex)
            {
                // ToDo standard logging here
                throw ex;
            }
        }
    }
}
