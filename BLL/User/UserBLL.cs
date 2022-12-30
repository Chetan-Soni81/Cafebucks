using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.User;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BLL.User
{
    public class UserBLL
    {
        public UserObj GetUserById(int id)
        {
            UserObj obj = new UserObj();
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("@uid", id)
            };

            try
            {
                using(SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_show_userbyid", parameters))
                {
                    while (sdr.Read())
                    {
                        obj.Id = Convert.ToInt32(sdr["userId"]);
                        obj.Firstname = (string)sdr["firstname"];
                        obj.Lastname = (string)sdr["lastname"];
                        obj.Email = (string)sdr["emailid"];
                        obj.Mobileno = (string)sdr["phoneno"];
                        obj.Username = (string)sdr["username"];

                        sdr.Read();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return obj;
        }

        public int RegisterUser(RegistrationUserObj obj)
        {
            int i;
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("@uname", obj.Username),
                new SqlParameter("@fname", obj.Firstname),
                new SqlParameter("@lname", obj.Lastname),
                new SqlParameter("@email", obj.Email),
                new SqlParameter("@phone", obj.MobileNo),
                new SqlParameter("@pwd", obj.Password),
            };

            object o = dal.ExecuteScalar("usp_register_user", parameters);

            if(o == null)
            {
                return 0;
            }

            i = Convert.ToInt32(o);

            return i;
        }

        public int LoginUser(string Username, string Password)
        {
            int i;
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("@uname", Username),
                new SqlParameter("@pwd", Password)
            };

            try
            {
                object o = dal.ExecuteScalar("usp_login_user", parameters);

                if(o == null)
                {
                    return 0;
                }

                i = Convert.ToInt32(o);
            }
            catch (Exception)
            {
                return 0;
            }


            return i;
        }
    }
}
