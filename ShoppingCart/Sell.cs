using DiscountLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart
{
    public class Sell
    {
        public Dictionary<Book, int> collectProducts { get; private set; }

        public Sell()
        {
            collectProducts = new Dictionary<Book, int>();
        }

        public void AddProduct(Book book, int buyNumber)
        {
            if (book == null)
            {
                throw new ArgumentException("book cannot be null");
            }

            if (collectProducts.ContainsKey(book))
            {
                collectProducts[book] += buyNumber;
            }
            else
            {
                collectProducts.Add(book, buyNumber);
            }
        }

        public double TotalPrice()
        {
            var groupProducts = collectProducts.GroupBy(r => r.Value)
                .ToDictionary(t => t.Key, t => new
                {
                    s = t.Count(),
                    p = t.Sum(p => p.Key.sellPrice),
                }).OrderByDescending(o => o.Key).ToList();

            double total = 0;
            int tmpCount = 0;
            double tmpPrice = 0;
            foreach (var detail in groupProducts)
            {
                tmpCount = detail.Value.s + tmpCount;
                tmpPrice = detail.Value.p + tmpPrice;

                IDiscount iDiscount = GetDiscount(tmpCount);
                total += tmpPrice * iDiscount.getDiscount();
            }

            return total;
        }

        private IDiscount GetDiscount(int buyNumber)
        {
            IDiscount result = null;

            switch (buyNumber)
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

    public class Pack
    {
        public int price { get; set; }
        public int count { get; set; }
    }
    public class Book
    {
        public string name { get; set; }
        public int sellPrice { get; set; }
    }
}
