using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    public class Address
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public string House { get; set; }
        public string Landmark { get; set; }
        public string Street { get; set; }
        public int PIN { get; set; }
        public int City { get; set; }
        public int State { get; set; }
    }
}
