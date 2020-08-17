using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public class UnitPrice
    {
        public string skuID { get; set; }
        public int price { get; set; }

        public UnitPrice(string id, int p)
        {
            skuID = id;
            price = p;
        }
    }
}
