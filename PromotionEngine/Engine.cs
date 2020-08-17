using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Engine
    {
        /// <summary>
        /// Unit Prices
        /// </summary>
        private List<UnitPrice> unitPrices { get; set; }

        /// <summary>
        /// Available items
        /// </summary>
        private List<string> availableItems = new List<string> { "A", "B", "C", "D" };

        /// <summary>
        /// Carts
        /// </summary>
        private List<Cart> carts { get; set; }

        /// <summary>
        /// Promotion Quanitity A
        /// </summary>
        private const int promotionQuanittyA = 3;

        /// <summary>
        /// Promotion Amount A
        /// </summary>
        private const int promotionAmountA = 130;

        /// <summary>
        /// Promotion Quanitity B
        /// </summary>
        private const int promotionQuanittyB = 2;

        /// <summary>
        ///  Promotion Amount B
        /// </summary>
        private const int promotionAmountB = 45;

        public Engine(List<UnitPrice> units, List<Cart> cart)
        {
            carts = cart;
            unitPrices = units;

        }

        public bool VerifyUnitPriceList()
        {
            foreach(var available in availableItems)
            {
                if(!unitPrices.Exists(x=>x.skuID == available))
                {
                    return false;
                }
            }

            return true;
        }

        public int Run()
        {
          
            // result
            int sum = 0;

            if (unitPrices != null & carts != null)
            {

                if (!VerifyUnitPriceList())
                {
                    throw new Exception("Unit Price Items are missing");
                }

                // temp SKU ID C
                int itemsC = 0;

                // temp SKU ID D
                int itemsD = 0;

                foreach (Cart item in carts)
                {
                    int count = 0;
                    switch (item.skuID)
                    {
                        case "A":
                            count = item.items / promotionQuanittyA;
                            sum += item.items % promotionQuanittyA * unitPrices.Find(x => x.skuID == item.skuID).price;
                            sum += count * promotionAmountA;
                            break;
                        case "B":
                            count = item.items / promotionQuanittyB;
                            sum += item.items % promotionQuanittyB * unitPrices.Find(x => x.skuID == item.skuID).price;
                            sum += count * promotionAmountB;
                            break;
                        case "C":
                            itemsC = item.items;
                            break;
                        case "D":
                            itemsD = item.items; ;
                            break;
                    }
                }

                if (itemsC != 0 && itemsD != 0)
                {
                    // temp count 
                    int count1 = 0;

                    if (itemsC > itemsD)
                    {
                        count1 = itemsC - itemsD;
                        if (count1 != 0)
                        {
                            sum += count1 * unitPrices.Find(x => x.skuID == "C").price;
                            itemsC = itemsC - count1;
                        }
                    }
                    else
                    {
                        count1 = itemsD - itemsC;
                        if (count1 != 0)
                        {
                            sum += count1 * unitPrices.Find(x => x.skuID == "D").price;
                            itemsD = itemsD - count1;
                        }
                    }

                    sum += itemsD * 30;

                }
                else if (itemsC != 0)
                {
                    sum += itemsC * unitPrices.Find(x => x.skuID == "C").price;
                }
                else if (itemsD != 0)
                {
                    sum += itemsD * unitPrices.Find(x => x.skuID == "D").price;
                }
            }

                return sum;  
        }
    }
}
