using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using PromotionEngine.Model;

namespace PromotionEngineTest
{
    [TestClass]
    public class EngineTest
    {
        [TestMethod]
        public void UnitPriceIsNull()
        {
            // Senario A
            List<Cart> carts = new List<Cart>();
            carts.Add(new Cart("A", 6));
            carts.Add(new Cart("B", 3));
            carts.Add(new Cart("C", 1));
            carts.Add(new Cart("D", 1));

            Engine engine = new Engine(null, carts);
            int res = engine.Run();

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void CartIsNull()
        {
            // Unit Price for SKU ID'S
            List<UnitPrice> unitPrices = new List<UnitPrice>();
            unitPrices.Add(new UnitPrice("A", 50));
            unitPrices.Add(new UnitPrice("B", 30));
            unitPrices.Add(new UnitPrice("C", 20));
            unitPrices.Add(new UnitPrice("D", 15));

            Engine engine = new Engine(unitPrices, null);
            int res = engine.Run();

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void UnitPriceIsAndCartIsNull()
        {
            Engine engine = new Engine(null, null);
            int res = engine.Run();

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void CartIsEmpty()
        {
            // Unit Price for SKU ID'S
            List<UnitPrice> unitPrices = new List<UnitPrice>();
            unitPrices.Add(new UnitPrice("A", 50));
            unitPrices.Add(new UnitPrice("B", 30));
            unitPrices.Add(new UnitPrice("C", 20));
            unitPrices.Add(new UnitPrice("D", 15));

            // Senario A
            List<Cart> carts = new List<Cart>();

            Engine engine = new Engine(unitPrices, carts);
            int res = engine.Run();

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void UnitPriceCartHavingAllItems()
        {
            // Unit Price for SKU ID'S
            List<UnitPrice> unitPrices = new List<UnitPrice>();
            unitPrices.Add(new UnitPrice("A", 50));
            unitPrices.Add(new UnitPrice("B", 30));
            unitPrices.Add(new UnitPrice("C", 20));
            unitPrices.Add(new UnitPrice("D", 15));

            // Senario A
            List<Cart> carts = new List<Cart>();
            carts.Add(new Cart("A", 6));
            carts.Add(new Cart("B", 3));
            carts.Add(new Cart("C", 1));
            carts.Add(new Cart("D", 1));

            Engine engine = new Engine(unitPrices, carts);
            int res = engine.Run();

            Assert.AreEqual(res, 365);
        }

        [TestMethod]
        public void UnitPriceMissingItems()
        {
            try
            {
                // Unit Price for SKU ID'S
                List<UnitPrice> unitPrices = new List<UnitPrice>();
                unitPrices.Add(new UnitPrice("A", 50));
                unitPrices.Add(new UnitPrice("D", 15));

                // Senario A
                List<Cart> carts = new List<Cart>();
                carts.Add(new Cart("A", 6));
                carts.Add(new Cart("B", 3));
                carts.Add(new Cart("C", 1));
                carts.Add(new Cart("D", 1));

                Engine engine = new Engine(unitPrices, carts);
                int res = engine.Run();

                Assert.Fail("no exception thrown");

            }
             catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception && ex.Message == "Unit Price Items are missing");
            }
        }
    }
}
