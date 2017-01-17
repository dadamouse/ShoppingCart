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
            var totolCollect = new Dictionary<int, Pack>();
            foreach (var detail in order.collectProducts)
            {
                //counting pack
                for (var i=0;i< detail.Value;i++)
                {
                    Pack pack = null;
                    if (totolCollect.ContainsKey(i))
                    {
                        
                        totolCollect.TryGetValue(i, out pack);
                        Console.WriteLine("Key = {0}, Value = {1}", pack.price, pack.count);
                        pack.price += detail.Key.SellPrice;
                        pack.count++;
                        totolCollect[i] = pack;
                    }
                    else
                    {
                        pack = new Pack() { price = detail.Key.SellPrice, count = 1 };
                        totolCollect.Add(i, pack);
                        Console.WriteLine("Key1 = {0}, Value = {1}", pack.price, pack.count);
                    }
                }
            }
            
            // counting discount
            for (var i = 0; i < totolCollect.Count; i++)
            {
                Console.WriteLine("KeyA = {0}, ValueA = {1}", totolCollect[i].price, totolCollect[i].count);
                IDiscount idiscount = getDiscount(totolCollect[i].count);
                total += totolCollect[i].price * idiscount.getDiscount();
                Console.WriteLine("total = {0}", total);
            }

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

    public class Pack
    {
        public int price { get; set; }
        public int count { get; set; }
    }
    public class Books
    {
        public string name { get; set; }
        public int SellPrice { get; set; }
    }

    public class Order
    {
        public Dictionary<Books, int> collectProducts { get; private set; }
        public Dictionary<int, int> pack { get; set; }

        public Order()
        {
            collectProducts = new Dictionary<Books, int>();
            pack = new Dictionary<int, int>();
        }

        public void add(Books book, int buyNum)
        {
            if (collectProducts.ContainsKey(book))
            {
                collectProducts[book] += buyNum;
            }
            else
            {
                collectProducts.Add(book, buyNum);
            }

            for (var i=0;i<buyNum;i++)
            {
                if (pack.ContainsKey(i))
                {
                    pack[i] += buyNum;
                }
                else
                {
                    pack.Add(i, buyNum);
                }
            }

        }
    }
}
