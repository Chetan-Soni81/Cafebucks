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
        public Category Category { get; set; }
        public Category SubCategory { get; set; }
        public int TotalRating { get; set; }
        public int RatingNo { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
        public List<ProductImage> Images { get; set; } = new List<ProductImage>();
    }
}
