using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Tests
{
    //1. 一到五集的哈利波特，每一本都是賣100元
    //2. 如果你從這個系列買了兩本不同的書，則會有5%的折扣
    //3. 如果你買了三本不同的書，則會有10%的折扣
    //4. 如果是四本不同的書，則會有20%的折扣
    //5. 如果你一次買了整套一到五集，恭喜你將享有25%的折扣
    //6. 需要留意的是，如果你買了四本書，其中三本不同，第四本則是重複的，
    //那麼那三本將享有10%的折扣，但重複的那一本，則仍須100元。
    //你的任務是，設計一個哈利波特的購物車，能提供最便宜的價格給這些爸爸媽媽。


    //Scenario: 第一集買了一本，其他都沒買，價格應為100*1=100元
    //Given 第一集買了 1 本
    //And 第二集買了 0 本
    //And 第三集買了 0 本
    //And 第四集買了 0 本
    //And 第五集買了 0 本
    //When 結帳
    //Then 價格應為 100 元
    [TestClass()]
    public class SellTests
    {
        //Scenario: 第一集買了一本，其他都沒買，價格應為100*1=100元
        [TestMethod()]
        public void test_buy_1_book1_price_is_100()
        {
            //arrange 
            var sell = new Sell();
            var book1 = new Book { name = "P1" , sellPrice = 100};
            var expected = 100;

            //act
            sell.AddProduct(book1, 1);
            var actual = sell.TotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }

        //Scenario: 第一集買了一本，第二集也買了一本，價格應為100*2*0.95=190
        [TestMethod()]
        public void test_第一集買了一本_第二集也買了一本_價格應為190()
        {
            //arrange 
            var sell = new Sell();
            var book1 = new Book { name = "P1", sellPrice = 100 };
            var book2 = new Book { name = "P2", sellPrice = 100 };
            var expected = 190;

            //act
            sell.AddProduct(book1, 1);
            sell.AddProduct(book2, 1);
            var actual = sell.TotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }

        //Scenario: 一二三集各買了一本，價格應為100*3*0.9=270
        [TestMethod()]
        public void test_Scenario_一二三集各買了一本_價格應為_價格應為270()
        {
            //arrange 
            var sell = new Sell();
            var book1 = new Book { name = "P1", sellPrice = 100 };
            var book2 = new Book { name = "P2", sellPrice = 100 };
            var book3 = new Book { name = "P3", sellPrice = 100 };
            var expected = 270;

            //act
            sell.AddProduct(book1, 1);
            sell.AddProduct(book2, 1);
            sell.AddProduct(book3, 1);
            var actual = sell.TotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }


        //Scenario: 一二三四集各買了一本，價格應為100*4*0.8=32s0
        [TestMethod()]
        public void test_Scenario_一二三四集各買了一本_價格應為100_320()
        {
            //arrange 
            var sell = new Sell();
            var book1 = new Book { name = "P1", sellPrice = 100 };
            var book2 = new Book { name = "P2", sellPrice = 100 };
            var book3 = new Book { name = "P3", sellPrice = 100 };
            var book4 = new Book { name = "P4", sellPrice = 100 };
            var expected = 320;

            //act
            sell.AddProduct(book1, 1);
            sell.AddProduct(book2, 1);
            sell.AddProduct(book3, 1);
            sell.AddProduct(book4, 1);
            var actual = sell.TotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }

        //Scenario: 一次買了整套，一二三四五集各買了一本，價格應為100*5*0.75=375
        [TestMethod()]
        public void test_Scenario_一次買了整套_一二三四五集各買了一本_價格應為375()
        {
            //arrange 
            var sell = new Sell();
            var book1 = new Book { name = "P1", sellPrice = 100 };
            var book2 = new Book { name = "P2", sellPrice = 100 };
            var book3 = new Book { name = "P3", sellPrice = 100 };
            var book4 = new Book { name = "P4", sellPrice = 100 };
            var book5 = new Book { name = "P5", sellPrice = 100 };
            var expected = 375;

            //act
            sell.AddProduct(book1, 1);
            sell.AddProduct(book2, 1);
            sell.AddProduct(book3, 1);
            sell.AddProduct(book4, 1);
            sell.AddProduct(book5, 1);
            var actual = sell.TotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }

        //Scenario: 一二集各買了一本，第三集買了兩本，價格應為100*3*0.9 + 100 = 370
        [TestMethod()]
        public void test_一二集各買了一本_第三集買了兩本_價格應為370()
        {
            //arrange 
            var sell = new Sell();
            var book1 = new Book { name = "P1", sellPrice = 100 };
            var book2 = new Book { name = "P2", sellPrice = 100 };
            var book3 = new Book { name = "P3", sellPrice = 100 };
            var expected = 370;

            //act
            sell.AddProduct(book1, 1);
            sell.AddProduct(book2, 1);
            sell.AddProduct(book3, 2);

            var actual = sell.TotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }

        //Scenario: 第一集買了一本，第二三集各買了兩本，價格應為100*3*0.9 + 100*2*0.95 = 460
        [TestMethod()]
        public void test_第一集買了一本_第二三集各買了兩本_價格應為_460()
        {
            //arrange 
            var sell = new Sell();
            var book1 = new Book { name = "P1", sellPrice = 100 };
            var book2 = new Book { name = "P2", sellPrice = 100 };
            var book3 = new Book { name = "P3", sellPrice = 100 };
            var expected = 460;

            //act
            sell.AddProduct(book1, 1);
            sell.AddProduct(book2, 2);
            sell.AddProduct(book3, 2);

            var actual = sell.TotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}