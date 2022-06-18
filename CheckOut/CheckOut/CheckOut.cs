using System;
using System.Collections.Generic;

namespace CheckOut
{
    interface ICheckout
    {
        List<string> items { get; set; }
        void Scan(string item);
        int GetTotalPrice();
    }

    public class CheckOut : ICheckout
    {
        public List<string> items { get; set; }

        public void Scan(string item)
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
