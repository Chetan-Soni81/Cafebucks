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

        public List<ProductItem> GetProductList(int length, int start)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();
            List<ProductItem> items = new List<ProductItem>();
            using (SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_show_product", new SqlParameter[]
            {
                new SqlParameter("@start", start),
                new SqlParameter("@length", length),
            }))
            {
                while (sdr.Read())
                {
                    items.Add(new ProductItem
                    {
                        Id = sdr.GetInt32(0),
                        ProductName = sdr.GetString(1),
                        Price = sdr.GetInt32(2),
                        TotalRating = sdr.GetInt32(3),
                        RatingNo = sdr.GetInt32(4),
                        Description = sdr.GetString(5),
                        Thumbnail = sdr.GetString(6),
                        Category = new Category
                        {
                            Id = sdr.GetInt32(7),
                            CategoryName = sdr.GetString(8),
                        },
                        SubCategory = new Category
                        {
                            Id = sdr.GetInt32(9),
                            CategoryName = sdr.GetString(10),
                        },
                        IsAvailable = sdr.GetBoolean(11),
                        IsActive = sdr.GetBoolean(12)

                    });

                }
            }
            return items;
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
                using (SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_display_product_to_buy", parameters))
                {
                    while (sdr.Read())
                    {
                        item.ProductName = (string)sdr["productName"];
                        item.Price = Convert.ToInt32(sdr["price"]);
                        item.TotalRating = Convert.ToInt32(sdr["totalRating"]);
                        item.RatingNo = Convert.ToInt32(sdr["ratingNo"]);
                        item.Description = (string)sdr["description"];
                        item.Thumbnail = (string)sdr["thumbnail"];
                        item.Category = new Category { CategoryName = (string)sdr["category"] };
                        item.SubCategory = new Category { CategoryName = (string)sdr["subcategory"] };

                    }
                }
            }
            catch (Exception ex)
            {
                return new ProductItem();
            }

            return item;
        }

        public void DeleteProduct(int id)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id)
            };

            dal.ExecuteNonQuery("usp_delete_product", parameters);
        }

    }
}
