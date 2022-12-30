﻿using System;
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
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                BindCategories();
                BindSubCategories();
                BindGviewProducts();
            }
		}

        protected void gviewProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gviewProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gviewProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gviewProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductBLL bll = new ProductBLL();
            try
            {
                ProductItem product = new ProductItem();
                product.ProductName = (string) txtProductName.Text;
                product.Price = Convert.ToInt32(txtPrice.Text);
                product.Description = (string) txtDescription.Text;

                string path = "";
                if (fileThumbnail.HasFiles)
                {
                    string filename = DateTime.Now.ToString("yyyymmddhhmmtt") + Path.GetFileName(fileThumbnail.FileName);
                        path = Server.MapPath("~/Uploads/Product/") + filename;
                        //file_profile.SaveAs(path);
                        product.Thumbnail = "/Uploads/Product/" + filename;
                }

                product.Category = dropCategory.SelectedValue;
                product.SubCategory = dropSubCategory.SelectedValue;

                product.Image1 = "";
                product.Image2 = "";
                product.Image3 = "";
                product.Image4 = "";

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

        private void BindCategories()
        {
            CategoryBLL bll = new CategoryBLL();
            using (DataTable dt = bll.GetCategories())
            {
                dropCategory.DataSource = dt;
                dropCategory.DataBind();
            }
            dropCategory.Items.Insert(0, new ListItem("---Select a Category--", "0"));
        }

        private void BindSubCategories()
        {
            CategoryBLL bll = new CategoryBLL();
            using (DataTable dt = bll.GetCategories())
            {
                dropSubCategory.DataSource = dt;
                dropSubCategory.DataBind();
            }
            dropSubCategory.Items.Insert(0, new ListItem("---Select a Sub Category--", "105"));
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