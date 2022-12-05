using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    class Address
    {
        public int Id { get; set; }
        public string House { get; set; }
        public string Street { get; set; }
        public string Locality { get; set; }
        public int PIN { get; set; }
        public int Cty { get; set; }
        public int State { get; set; }
    }
}
