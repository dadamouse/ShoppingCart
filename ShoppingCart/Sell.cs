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
            double total = 0;
            var totolCollect = new Dictionary<int, Pack>();
            foreach (var detail in collectProducts)
            {
                //counting pack
                for (var i = 0; i < detail.Value; i++)
                {
                    Pack pack = null;
                    if (totolCollect.ContainsKey(i))
                    {

                        totolCollect.TryGetValue(i, out pack);
                        pack.price += detail.Key.sellPrice;
                        pack.count++;
                        totolCollect[i] = pack;
                    }
                    else
                    {
                        pack = new Pack() { price = detail.Key.sellPrice, count = 1 };
                        totolCollect.Add(i, pack);
                    }
                }
            }

            // counting discount
            for (var i = 0; i < totolCollect.Count; i++)
            {
                IDiscount iDiscount = GetDiscount(totolCollect[i].count);
                total += totolCollect[i].price * iDiscount.getDiscount();
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
