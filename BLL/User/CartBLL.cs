using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity.Product;
using DAL;

namespace BLL.User
{
    public class CartBLL
    {
        public CartSummaryObj GetCartItems(int userId)
        {
            CartSummaryObj summaryObj = new CartSummaryObj
            {
                TotalItems = 0,
                TotalPrice = 0,
                CartItems = new List<CartObj>()
            };

            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("@user", userId)
            };

            try
            {
                using (SqlDataReader sdr = dal.SelectRecordsByDataReader("usp_show_cartitems", parameters))
                {
                    while (sdr.Read())
                    {
                        summaryObj.CartItems.Add(
                                new CartObj
                                {
                                    Id = Convert.ToInt32(sdr["cartId"]),
                                    UserId = userId,
                                    ProductId = Convert.ToInt32(sdr["productId"]),
                                    ProductName = (string)sdr["productName"],
                                    ProductPrice = Convert.ToInt32(sdr["product_price"]),
                                    CategoryId= Convert.ToInt32(sdr["category"]),
                                    CategoryName = (string)sdr["categoryName"],
                                    Thumbnail = (string)sdr["thumbnail"],
                                    Price = Convert.ToDouble(sdr["price"]),
                                    Quantity = Convert.ToInt32(sdr["quantity"]),
                                    AddedTime = Convert.ToDateTime(sdr["addedDate"])
                                }
                        );

                        summaryObj.TotalItems++;
                        summaryObj.TotalPrice += Convert.ToDouble(sdr["price"]);
                    }
                }
            }
            catch (Exception)
            {
                return new CartSummaryObj();
            }

            return summaryObj;
        }

        public int DeleteCartItem(int itemId)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();
            int i;
            SqlParameter[] parameters =
            {
                new SqlParameter("@cartitem", itemId)
            };

            try
            {
                i = dal.ExecuteNonQuery("usp_delete_cart", parameters);
            }
            catch (Exception)
            {
                return 0;
            }

            return i;
        }

        public int AddItemToCart(CartObj obj)
        {
            DataAccessLayer2 dal = new DataAccessLayer2();

            SqlParameter[] parameters =
            {
                new SqlParameter("@item", obj.ProductId),
                new SqlParameter("@user", obj.UserId),
                new SqlParameter("@count", obj.Quantity),
            };

            int i;

            try
            {
                object o = dal.ExecuteScalar("usp_add_to_cart", parameters);

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

        public int UpdateCartItem(int itemid, int quantity)
        {
            int i = 0;

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", itemid),
                new SqlParameter("@quantity", quantity)
            };

            DataAccessLayer2 dal = new DataAccessLayer2();

            try
            {
                i = dal.ExecuteNonQuery("usp_change_cartitem_quantity", parameters);
            }
            catch (Exception)
            {
                return 0;
            }

            return i;
        }
    }


}
