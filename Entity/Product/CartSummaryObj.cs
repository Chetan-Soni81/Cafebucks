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
        public double GstApplied { get; set; }
        public double GstCharges { get; set; }
        public double DeliveryCharges { get; set; }
        public double FinalAmount { get; set; }
    }
}
