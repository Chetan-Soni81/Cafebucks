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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
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

                repeatOrderItems.DataSource = summary.CartItems;
                repeatOrderItems.DataBind();

                lblTotalItems.Text = summary.TotalItems.ToString();
                SetGstOnLabel(summary.TotalPrice);
                lblFinalPrice.Text = String.Format("{0:0.00}", summary.TotalPrice);
                //lblTotalPayable.Text = String.Format("{0:0.00}", summary.TotalPrice);


            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetGstOnLabel(double totalpayable)
        {
            int addedGST = (int) (totalpayable * .05);

            lblAddedGst.Text = String.Format("{0:0.00}", addedGST);

            int deliveryCharges = totalpayable > 100 ? 0 : 20;

            if(deliveryCharges == 0)
            {
                lblDeliveryCharges.Text = "Free";
            } else
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

                throw;
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

        //    private void BindStates()
        //    {
        //        AddressBLL bll = new AddressBLL();

        //        DataTable dt = bll.getStates();

        //        dropState.Items.Clear();

        //        dropState.DataSource = dt;
        //        dropState.DataBind();
        //        dropState.Items.Insert(0, new ListItem("Choose...", "0"));
        //    }

        //    protected void dropState_SelectedIndexChanged(object sender, EventArgs e)
        //    {
        //        try
        //        {
        //            int id = Convert.ToInt32(dropState.SelectedValue);

        //            AddressBLL bll = new AddressBLL();

        //            DataTable dt = bll.getCities(id);

        //            dropCity.Items.Clear();

        //            dropCity.DataSource = dt;
        //            dropCity.DataBind();
        //            dropCity.Items.Insert(0, new ListItem("Choose...", "0"));
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }

        //    }

        //    protected void btnSubmit_Click(object sender, EventArgs e)
        //    {
        //        Address address = new Address();

        //        try
        //        {
        //            address.House = txtBuilding.Text;
        //            address.Street = txtStreet.Text;
        //            address.Locality = txtAddressLine2.Text;
        //            address.State = Convert.ToInt32(dropState.SelectedValue);
        //            address.City = Convert.ToInt32(dropCity.SelectedValue);
        //            address.PIN = Convert.ToInt32(txtZip.Text);

        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
    }

}