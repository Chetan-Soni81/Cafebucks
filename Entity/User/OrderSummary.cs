using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entity.User
{
    public class OrderSummary
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public DataTable OrderItems { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public int PayableAmount { get; set; }
        public int ShippingCharge { get; set; }
    }
}
