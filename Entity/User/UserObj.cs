using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.User
{
    public class UserObj
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }
        public string Address { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }

    }
}
