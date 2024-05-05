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
    public partial class CheckoutPage : System.Web.UI.Page
    {
        static int userid = 0;
        UserBLL userBll = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            userid = Convert.ToInt32(Session["User"]);

            if (!IsPostBack)
            {
                BindCartItems();
                BindUserData();
            }
        }

        protected void BindCartItems()
        {
            CartBLL bll = new CartBLL();

            int userId = Convert.ToInt32(Session["User"]),
                deliveryType = Convert.ToInt32(Request.QueryString["deliveryType"]);

            try
            {
                CartSummaryObj summary = bll.GetCartItems(userId, deliveryType);

                repeatOrderItems.DataSource = summary.CartItems;
                repeatOrderItems.DataBind();

                lblTotalItems.Text = summary.TotalItems.ToString();
                lblGstRate.Text = summary.GstApplied.ToString("0.00");
                lblAddedGst.Text = summary.GstCharges.ToString("0.00");
                lblTotalPayable.Text = String.Format("{0:0.00}", summary.TotalPrice);
                lblDeliveryCharges.Text = summary.DeliveryCharges == 0 ? "Free" : String.Format("{0:0.00}", summary.DeliveryCharges);
                lblFinalPrice.Text = String.Format("{0:0.00}", summary.FinalAmount);


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SetGstOnLabel(double totalpayable)
        {
            int addedGST = (int)(totalpayable * .05);

            lblAddedGst.Text = String.Format("{0:0.00}", addedGST);

            int deliveryCharges = totalpayable > 100 ? 0 : 20;

            if (deliveryCharges == 0)
            {
                lblDeliveryCharges.Text = "Free";
            }
            else
            {
                lblDeliveryCharges.Text = "₹" + deliveryCharges;
            }

            lblTotalPayable.Text = String.Format("{0:0.00}", totalpayable + addedGST + deliveryCharges);
        }

        protected void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;

                string[] values = btn.CommandArgument.Split(',');

                int itemId = Convert.ToInt32(values[0]);
                int quantity = Convert.ToInt32(values[1]);

                if (quantity > 1)
                {
                    ChangeCartItemQuantity(itemId, quantity - 1);
                }
            }
            catch (Exception ex)
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
                Response.Write(ex.Message);
            }
        }

        private void ChangeCartItemQuantity(int id, int quantity)
        {
            try
            {
                CartBLL bll = new CartBLL();

                int i = bll.UpdateCartItem(id, quantity);

                if (i != 0)
                {
                    BindCartItems();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            CartBLL bll = new CartBLL();

            try
            {
                LinkButton btn = sender as LinkButton;


                int cartItemId = Convert.ToInt32(btn.CommandArgument);

                int i = bll.DeleteCartItem(cartItemId);

                if (i != 0)
                {
                    BindCartItems();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnPlaceOrder_Click(object sender, EventArgs e)
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
                foreach (RepeaterItem item in repeatOrderItems.Items)
                {
                    HiddenField productID = item.FindControl("lblProductId") as HiddenField;
                    HiddenField productPrice = item.FindControl("lblProductPrice") as HiddenField;
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
                orderSummary.PayableAmount = (int)(totalAmount * 1.05) + (totalAmount > 99 ? 0 : 20);
                orderSummary.ShippingCharge = totalAmount > 100 ? 0 : 20;


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnChangeAddress_Click(object sender, EventArgs e)
        {
            txtAddress.Text = lblAddress.Text;
            lblAddress.Visible = false;
            txtAddress.Visible = true;
            btnSaveAddress.Visible = true;
            BtnChangeAddress.Visible = false;
        }

        protected void btnSaveAddress_Click(object sender, EventArgs e)
        {
            lblAddress.Text = userBll.UpdateAddress(txtAddress.Text.Trim(), userid);
            lblAddress.Visible = true;
            txtAddress.Text = "";
            txtAddress.Visible = false;
            BtnChangeAddress.Visible = true;
            btnSaveAddress.Visible = false;
        }

        private void BindUserData()
        {
            UserObj user = userBll.GetUserDetails(userid);

            if (user == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            lblUsername.Text = $"{user.Firstname} {user.Lastname}";
            lblPhoneNo.Text = user.Mobileno;
            lblAddress.Text = user.Address;
        }
    }
}