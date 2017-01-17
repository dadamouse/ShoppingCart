using System;

namespace DiscountLib
{
    public class BuyFiveBook : IDiscount
    {
        public BuyFiveBook()
        {

        }

        public double getDiscount()
        {
            return 0.75;
        }
    }
}