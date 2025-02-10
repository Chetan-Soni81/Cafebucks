using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Product;
using System.Data;
using Entity.Product;
using System.IO;

namespace Cafebucks
{
    public partial class AdminProducts : System.Web.UI.Page
    {

        ProductBLL bll = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories(dropCategory);
                BindSubCategories(dropSubCategory);
                BindGviewProducts();
            }
        }

        protected void gviewProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int i = e.NewEditIndex;
            GridViewRow row = gviewProducts.Rows[i];

            string category = ((HiddenField)row.FindControl("hdnCategory")).Value,
                subcategory = ((HiddenField)row.FindControl("hdnSubCategory")).Value;
                
            gviewProducts.EditIndex = i;
            BindGviewProducts();

            row = gviewProducts.Rows[i];
            DropDownList ddlCat = (DropDownList)row.FindControl("ddlCategory");
            DropDownList ddlSubCat = (DropDownList)row.FindControl("ddlSubCategory");

            BindCategories(ddlCat);
            BindSubCategories(ddlSubCat);

            ddlCat.SelectedValue = category;
            ddlSubCat.SelectedValue = subcategory;
        }

        protected void gviewProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gviewProducts.EditIndex = -1;
            BindGviewProducts();
        }

        protected void gviewProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gviewProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            bll.DeleteProduct(id);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ProductItem product = new ProductItem();
                product.ProductName = txtProductName.Text.Trim();
                product.Price = Convert.ToInt32(txtPrice.Text.Trim());
                product.Description = (string)txtDescription.Text.Trim();

                string path = "";
                if (fileThumbnail.HasFiles)
                {
                    string filename = DateTime.Now.ToString("yyyymmddhhmmtt") + Path.GetFileName(fileThumbnail.FileName);
                    path = Server.MapPath("~/Uploads/Product/") + filename;
                    //file_profile.SaveAs(path);
                    product.Thumbnail = "/Uploads/Product/" + filename;
                }

                product.Category = dropCategory.SelectedIndex > 0 ? new Category { Id = Convert.ToInt32(dropCategory.SelectedValue), CategoryName = dropCategory.SelectedItem.Text.Trim() } : new Category { Id=0};
                product.SubCategory = dropCategory.SelectedIndex > 0 ? new Category { Id = Convert.ToInt32(dropCategory.SelectedValue), CategoryName = dropCategory.SelectedItem.Text.Trim() } : new Category { Id = 105 };


                int i = bll.CreateProduct(product);

                if (i != 0)
                {
                    fileThumbnail.SaveAs(path);
                    BindGviewProducts();
                }
            }
            catch
            {

            }
        }

        private void BindCategories(DropDownList dropDownList)
        {
            CategoryBLL bll = new CategoryBLL();
            using (DataTable dt = bll.GetCategories())
            {
                dropDownList.DataSource = dt;
                dropDownList.DataBind();
            }
            dropDownList.Items.Insert(0, new ListItem("---Select a Category--", ""));
        }

        private void BindSubCategories(DropDownList dropDownList)
        {
            CategoryBLL bll = new CategoryBLL();
            using (DataTable dt = bll.GetCategories())
            {
                dropDownList.DataSource = dt;
                dropDownList.DataBind();
            }
            dropDownList.Items.Insert(0, new ListItem("---Select a Sub Category--", ""));
        }

        private void BindGviewProducts()
        {
            ProductBLL bll = new ProductBLL();

            DataTable dt = bll.GetProducts();

            gviewProducts.DataSource = dt;
            gviewProducts.DataBind();
        }
    }
}