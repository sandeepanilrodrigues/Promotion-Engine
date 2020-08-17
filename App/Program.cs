using PromotionEngine;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
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

            Engine promotionEngine = new Engine(unitPrices, carts);
            int sum = promotionEngine.Run();

            Console.WriteLine(sum);
            Console.ReadKey();

        }
    }
}
