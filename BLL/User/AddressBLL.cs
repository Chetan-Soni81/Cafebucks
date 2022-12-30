using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
using Entity.User;

namespace BLL.User
{
    public class AddressBLL
    {
        public DataTable getStates()
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            using (SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_display_state"))
            {
                using(DataTable dt = new DataTable())
                {
                    try
                    {
                        dt.Load(sdr);
                        return dt;
                    } catch(Exception ex)
                    {
                        return new DataTable();
                    }
                }
            }
        }

        public DataTable getCities(int stateid)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("stateid", stateid),
            };

            using (SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_display_city", parameters))
            {
                using (DataTable dt = new DataTable())
                {
                    try
                    {
                        dt.Load(sdr);
                        return dt;
                    } catch(Exception ex)
                    {
                        return new DataTable();
                    }
                }
            }
        }

        public int SaveAddress(Address address)
        {
            return 0;
        }
    }
}
