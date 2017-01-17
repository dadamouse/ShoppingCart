using System;

namespace DiscountLib
{
    public class BuyTwoBook : IDiscount
    {
        public BuyTwoBook()
        {
        }

        public double getDiscount()
        {
            return 0.95;
        }
    }
}