using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity.Learn;

namespace BLL.Learn
{
    public class UserBLL
    {
        private DataAccessLayer dal;
        private DataAccessLayer2 dal2;

        public UserBLL()
        {
            dal = new DataAccessLayer();
            dal2 = new DataAccessLayer2();
        }
        public int RegisterUser(RegistrationModel user)
        {
            int i = 0;

            i = dal.ExecuteNonQuery("usp_create_user", user.Username, user.Firstname, user.Middlename, user.Lastname, user.Email, user.Mobileno, user.Password, user.Gender, user.SpeakHindi, user.SpeakEnglish, user.ImagePath);

            return i;
        }

        public int LoginUser(LoginModel login)
        {
            int user = 0;

            using (SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_login_user", login.Username, login.Password))
            {
                if (!sdr.HasRows)
                {
                    return user;
                }

                while (sdr.Read())
                {
                    user = Convert.ToInt32(sdr["userId"]);
                }

                return user;
            }
        }

        public int LoginUser2(LoginModel loginModel)
        {
            int user = 0;
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@uname", loginModel.Username),
                new SqlParameter("@pwd", loginModel.Password)
            };

            using (SqlDataReader sdr = dal2.SelectRecordsByDataReader("usp_login_user", sqlParameters))
            {
                if (!sdr.HasRows)
                {
                    return user;
                }

                while (sdr.Read())
                {
                    user = Convert.ToInt32(sdr["userId"]);
                }

                return user;
            }
        }

        public UserObj GetUserById(int uid)
        {
            UserObj user = new UserObj();

            using (SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_show_userbyid", uid))
            {
                if (!sdr.HasRows)
                {
                    return null;
                }

                while (sdr.Read())
                {
                    user.Id = Convert.ToInt32(sdr["userId"]);
                    user.Username = Convert.ToString(sdr["username"]);
                    user.Firstname = Convert.ToString(sdr["firstname"]);
                    user.Middlename = Convert.ToString(sdr["middlename"]);
                    user.Lastname = Convert.ToString(sdr["lastname"]);
                    user.Email = Convert.ToString(sdr["email"]);
                    user.Mobileno = Convert.ToString(sdr["phoneno"]);
                    user.Password = Convert.ToString(sdr["password"]);
                    user.Gender = Convert.ToString(sdr["gender"]);
                    user.SpeakEnglish = Convert.ToBoolean(sdr["speakenglish"]);
                    user.SpeakHindi = Convert.ToBoolean(sdr["speakhindi"]);
                    user.ImagePath = Convert.ToString(sdr["imagepath"]);
                }

                return user;
            }
        }
    }
}
