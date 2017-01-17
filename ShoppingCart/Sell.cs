using DiscountLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart
{
    public class Sell
    {
        private Order order { get; set; }

        public Sell()
        {
            order = new Order();
        }

        public void addProduct(Books book, int buyNum)
        {
            try
            {
                order.add(book, buyNum);
            }
            catch (NullReferenceException e)
            {
                //null exception
                throw new Exception(e.ToString());
            }
        }

        public double totalPrice()
        {
            double total = 0;

            var count = 0;
            foreach (var detail in order.CollectProducts)
            {
                total += detail.Key.SellPrice * detail.Value;
                Console.WriteLine("Key = {0}, Value = {1}", detail.Key.SellPrice, detail.Value);

                count++;
            }

            IDiscount iDiscount = getDiscount(count);
            total = total * iDiscount.getDiscount();

            return total;
        }

        private IDiscount getDiscount(int buyNum)
        {
            IDiscount result = null;

            switch (buyNum)
            {
                default:
                case 1:
                    result = new BuyOneBook();
                    break;
                case 2:
                    result = new BuyTwoBook();
                    break;
                case 3:
                    result = new BuyThreeBook();
                    break;
                case 4:
                    result = new BuyfourBook();
                    break;
                case 5:
                    result = new BuyFiveBook();
                    break;
            }

            return result;
        }
    }

    public class Books
    {
        public string name { get; set; }
        public int SellPrice { get; set; }
    }

    public class Order
    {
        public Dictionary<Books, int> CollectProducts { get; private set; }

        public Order()
        {
            CollectProducts = new Dictionary<Books, int>();
        }

        public void add(Books book, int buyNum)
        {
            if (CollectProducts.ContainsKey(book))
            {
                CollectProducts[book] += buyNum;
            }
            else
            {
                CollectProducts.Add(book, buyNum);
            }
        }
    }
}
