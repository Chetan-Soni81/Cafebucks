using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Product;

namespace Cafebucks
{
    public partial class ProductCatelog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
                BindCategories();
            }
        }

        private void BindProducts()
        {
            ProductBLL bll = new ProductBLL();
            DataTable dt = bll.GetProducts();
            repeatProduct.DataSource = dt;
            repeatProduct.DataBind();
        }

        private void BindCategories()
        {
            CategoryBLL bll = new CategoryBLL();
            DataTable dt = bll.GetCategories();
            repeatCategories.DataSource = dt;
            repeatCategories.DataBind();
        }
    }
}