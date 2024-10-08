using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Product
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }
        public DateTime UploadDate { get; set; }
        public bool Active { get; set; }
    }
}
