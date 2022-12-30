using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity.Product;
using DAL;
using System.Data.SqlClient;

namespace BLL.Product
{
    public class ProductBLL
    {
        public int CreateProduct(ProductItem product)
        {
            int i = 1;
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameter =
            {
                new SqlParameter("@productname", product.ProductName),
                new SqlParameter("@price", product.Price),
                new SqlParameter("@description", product.Description),
                new SqlParameter("@image1", product.Thumbnail),
                new SqlParameter("@image2", product.Image1),
                new SqlParameter("@image3", product.Image2),
                new SqlParameter("@image4", product.Image3),
                new SqlParameter("@image5", product.Image4),
                new SqlParameter("@cate", product.Category),
                new SqlParameter("@subcate", product.SubCategory),
            };

            try
            {
                i = dal.ExecuteNonQuery("usp_create_product", parameter);
            }
            catch (Exception)
            {
                i = 0;
            }

            return i;
        }

        public DataTable GetProducts()
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            using (SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_show_product"))
            {
                using (DataTable dt = new DataTable())
                {
                    dt.Load(sdr);
                    return dt;
                }
            }
        }
        public ProductItem showProduct(int id)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id)
            };

            ProductItem item = new ProductItem();

            try
            {
                using( SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_display_product_to_buy", parameters))
                {
                    while (sdr.Read())
                    {
                        item.ProductName = (string) sdr["productName"];
                        item.Price = Convert.ToInt32(sdr["price"]);
                        item.TotalRating = Convert.ToInt32(sdr["totalRating"]);
                        item.RatingNo = Convert.ToInt32(sdr["ratingNo"]);
                        item.Description = (string)sdr["description"];
                        item.Thumbnail = (string)sdr["mainImage"];
                        item.Image1 = (string)sdr["image2"];
                        item.Image2 = (string)sdr["image3"];
                        item.Image3 = (string)sdr["image4"];
                        item.Image4 = (string)sdr["image5"];
                        item.Category = (string)sdr["category"];
                        item.SubCategory = (string)sdr["subcategory"];

                        sdr.Read();
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProductItem();
            }

            return item;
        }

    }
}
