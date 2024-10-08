using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Product;
using BLL.User;
using Entity.Product;

namespace Cafebucks
{
    public partial class BuyProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                BindProducts();
                DisplayProductItem();
            }
        }

        private void BindProducts()
        {
            BLL.Product.ProductBLL bll = new BLL.Product.ProductBLL();
            DataTable dt = bll.GetProducts();
            repeatProduct.DataSource = dt;
            repeatProduct.DataBind();
        }

        private void DisplayProductItem()
        {
            BLL.Product.ProductBLL bll = new BLL.Product.ProductBLL();
            int productId = Convert.ToInt32(Request.QueryString["product"]);
            ProductItem item = bll.showProduct(productId);

            imageProduct.ImageUrl = item.Thumbnail;
            lblCategory.Text = item.Category.CategoryName;
            lblProductName.Text = item.ProductName;
            lblOriginalPrice.Text = item.Price.ToString();

            Random rand = new Random();
            double r = rand.NextDouble();
            double pr = item.Price * ((10 * r) / 100);

            lblDiscounted.Text = String.Format("{0:00.00}",(item.Price - pr));
            lblDescription.Text = item.Description;
        }

        protected void btnAddtocart_Click(object sender, EventArgs e)
        {
            if(Session["User"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }

            CartBLL bll = new CartBLL();

            try
            {
                int count = Convert.ToInt32(txtQuantity.Text);
                int productId = Convert.ToInt32(Request.QueryString["product"]);
                int userId = Convert.ToInt32(Session["User"]);

                CartObj item = new CartObj
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = count
                };

                int i = bll.AddItemToCart(item);

                if(i == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "<script>alert('Cannot add this item to cart')</script>", false);
                } else
                {
                    btnAddtocart.Text = "Already Added";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}