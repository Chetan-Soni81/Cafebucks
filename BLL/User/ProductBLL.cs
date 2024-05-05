using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.User;
using DAL;
using System.Data.SqlClient;

namespace BLL.User
{
    public class ProductBLL
    {
        public int PlaceOrder(OrderSummary orderSummary)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("@name", "Chetan Soni")
            };

            return 0;
        }

    }
}
