using System;

namespace DiscountLib
{
    public class BuyThreeBook : IDiscount
    {
        public BuyThreeBook()
        {
        }

        public double getDiscount()
        {
            return 0.9;
        }
    }
}