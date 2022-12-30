using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Product
{
    public class CartSummaryObj
    {
        public int TotalItems { get; set; }
        public double TotalPrice { get; set; }
        public List<CartObj> CartItems { get; set; }
    }
}
