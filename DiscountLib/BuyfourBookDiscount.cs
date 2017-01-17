using System;

namespace DiscountLib
{
    public class BuyfourBook : IDiscount
    {
        public BuyfourBook()
        {
        }

        public double getDiscount()
        {
            return 0.8;
        }
    }
}