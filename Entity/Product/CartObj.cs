using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Product
{
    public class CartObj
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Thumbnail { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
