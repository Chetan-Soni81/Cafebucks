using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    class Cart
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
    }
}
