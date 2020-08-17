using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public class Cart
    {
        public string skuID { get; set; }
        public int items { get; set; }

        public Cart(string id, int item)
        {
            skuID = id;
            items = item;
        }
    }
}
