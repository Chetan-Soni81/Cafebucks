using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.User;
using Entity.Product;
using Entity.User;

namespace Cafebucks
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["User"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                BindCartItems();
            }
        }

        protected void BindCartItems()
        {
            CartBLL bll = new CartBLL();

            int userId = Convert.ToInt32(Session["User"]);

            try
            {
                CartSummaryObj summary = bll.GetCartItems(userId);

                repeatCartItems.DataSource = summary.CartItems;
                repeatCartItems.DataBind();

                lblCount.Text = summary.TotalItems.ToString();
                lblTotalItems.Text = summary.TotalItems.ToString();
                lblFinalPrice.Text = String.Format("{0:0.00}",summary.TotalPrice);
                lblTotalPrice.Text = String.Format("{0:0.00}",summary.TotalPrice);

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("product_id", typeof(Int32)));
            dt.Columns.Add(new DataColumn("quantity", typeof(Int32)));
            dt.Columns.Add(new DataColumn("price", typeof(Int32)));
            dt.Columns.Add(new DataColumn("user_id", typeof(Int32)));

            int totalAmount = 0;

            OrderSummary orderSummary = new OrderSummary();
            orderSummary.UserId = Convert.ToInt32(Session["User"]);

            try
            {
                foreach(RepeaterItem item in repeatCartItems.Items)
                {
                    HiddenField productID = item.FindControl("txtProductId") as HiddenField;
                    HiddenField productPrice = item.FindControl("txtProductPrice") as HiddenField;
                    TextBox productQuantity = item.FindControl("txtQuantity") as TextBox;

                    totalAmount += Convert.ToInt32(productPrice.Value) * Convert.ToInt32(productQuantity.Text);

                    DataRow dataRow = dt.NewRow();
                    dataRow["product_id"] = Convert.ToInt32(productID.Value);
                    dataRow["quantity"] = Convert.ToInt32(productPrice.Value);
                    dataRow["price"] = Convert.ToInt32(productQuantity.Text);
                    dataRow["user_id"] = Convert.ToInt32(Session["User"]);

                    dt.Rows.Add(dataRow);
                }

                orderSummary.OrderItems = dt;
                orderSummary.TotalAmount = totalAmount;
                orderSummary.PayableAmount = (int)(totalAmount * 1.18);
                orderSummary.ShippingCharge = dropShipping.SelectedIndex == 0 ? 0 : 50;


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dropShipping_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropShipping.SelectedValue == "1")
            {
                lblFinalPrice.Text = lblTotalPrice.Text;
            } else if (dropShipping.SelectedValue == "2")
            {
                lblFinalPrice.Text = String.Format("{0:0.00}", (Convert.ToDouble(lblTotalPrice.Text) + 50));
            }
        }

        protected void btnRemoveItem_Click(object sender, EventArgs e)
        {
            CartBLL bll = new CartBLL();
            
            try
            {
                LinkButton btn = sender as LinkButton;


                int cartItemId = Convert.ToInt32(btn.CommandArgument);

                int i = bll.DeleteCartItem(cartItemId);

                if(i != 0)
                {
                    BindCartItems();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;

                string[] values = btn.CommandArgument.Split(',');

                int itemId = Convert.ToInt32(values[0]);
                int quantity = Convert.ToInt32(values[1]);

                if(quantity > 1)
                {
                    ChangeCartItemQuantity(itemId, quantity - 1);
                }
            } catch (Exception ex)
            {

            }
        }

        protected void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;

                string[] values = btn.CommandArgument.Split(',');
                int itemid = Convert.ToInt32(values[0]);
                int quantity = Convert.ToInt32(values[1]);

                ChangeCartItemQuantity(itemid, quantity + 1);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void ChangeCartItemQuantity(int id, int quantity)
        {
            try
            {
                CartBLL bll = new CartBLL();

                int i = bll.UpdateCartItem(id, quantity);

                if(i != 0)
                {
                    BindCartItems();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnPlaceOrder_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CheckoutPage.aspx");
        }
    }
}