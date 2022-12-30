using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Entity.Product;

namespace BLL.Product
{
    public class CategoryBLL
    {
        public DataTable GetCategories()
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            using (SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_show_category"))
            {
                using (DataTable dt = new DataTable())
                {
                    try
                    {
                        dt.Load(sdr);
                        return dt;
                    }
                    catch (Exception)
                    {
                        return new DataTable();
                    }
                }
            }
        }

        public int AddCategory(string category)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters = { 
                new SqlParameter("@category", category)
            };

            int i = dal.ExecuteNonQuery("usp_add_category", parameters);

            if(i != 0)
            {
                return 1;
            }

            return 0;
        }

        public int UpdateCategory(Category category)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", category.Id),
                new SqlParameter("@category", category.CategoryName),
                new SqlParameter("@active", category.isActive)
            };

            int i = dal.ExecuteNonQuery("usp_update_category", parameters);

            if (i != 0)
            {
                return 1;
            }

            return 0;
        }

        public int DeleteCategory(int id)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id)
            };

            int i = dal.ExecuteNonQuery("usp_delete_category", parameters);

            if(i != 0)
            {
                return 1;
            }

            return 0;
        }
    }
}
