using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Product;
using Entity.Product;

namespace Cafebucks
{
    public partial class ProductCatelog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindProducts();
                BindCategories();
            }
        }

        [WebMethod]
        public static List<ProductItem> GetProducts()
        {
            try
            {
                int length = 10, start = 0;
                ProductBLL bll = new ProductBLL();
                var item = bll.GetProductList(length, start);
                return item;
            }
            catch (Exception ex)
            {
                return new List<ProductItem>();
            }
        }


        private void BindProducts()
        {
            ProductBLL bll = new ProductBLL();
            DataTable dt = bll.GetProducts();
            //repeatProduct.DataSource = dt;
            //repeatProduct.DataBind();
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