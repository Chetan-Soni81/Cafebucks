using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    public class OrderItem
    {
        public int Product { set; get; }
        public int Quantity { set; get; }
        public double Price { get; set; }

    }
}
