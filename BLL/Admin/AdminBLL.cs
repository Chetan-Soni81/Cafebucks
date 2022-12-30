using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Admin;
using DAL;
using System.Data.SqlClient;

namespace BLL.Admin
{
    public class AdminBLL
    {
        public AdminModel LoginAdmin(AdminModel model)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();
            SqlParameter[] parameters =
            {
                new SqlParameter("@uname", model.Username),
                new SqlParameter("@pwd", model.Password)
            };

            try
            {

            using (SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_admin_login", parameters))
            {
                while (sdr.Read())
                {
                    model.Id = Convert.ToInt32(sdr["adminId"]);
                }
            }
            } catch
            {
                return new AdminModel();
            }

            return model;
        }
    }
}
