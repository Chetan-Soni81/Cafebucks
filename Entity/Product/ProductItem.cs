using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Product
{
    public class ProductItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public int TotalRating { get; set; }
        public int RatingNo { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public bool isAvailable { get; set; }
        public bool isActive { get; set; }
    }
}
