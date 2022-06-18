using System;
using System.Collections.Generic;

namespace CheckOut
{
    interface ICheckout
    {
        List<string> items { get; }
        void Scan(string item);
        int GetTotalPrice();
    }

    public class CheckOut : ICheckout
    {
        public List<string> items { get; }

        public void Scan(string item)
        { }

        public int GetTotalPrice()
        {
            return 0;
        }
    }
}
