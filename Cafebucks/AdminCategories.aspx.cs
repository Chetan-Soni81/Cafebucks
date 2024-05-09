using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entity.Product;
using BLL.Product;

namespace Cafebucks
{
    public partial class AdminCategories : System.Web.UI.Page
    {
        CategoryBLL bll = new CategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGViewCategory();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gviewCategory.EditIndex = e.NewEditIndex;
            BindGViewCategory();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gviewCategory.EditIndex = -1;
            BindGViewCategory();
        }

        protected void gviewCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gviewCategory.Rows[e.RowIndex];

            string categoryName = ((TextBox)row.FindControl("txtCategoryName")).Text.Trim();
            bool isActive = ((CheckBox)row.FindControl("chkIsActive")).Checked;
            string datakey = gviewCategory.DataKeys[e.RowIndex].Values["categoryId"].ToString();

            int i = bll.UpdateCategory(new Category
            {
                Id = Convert.ToInt32(datakey),
                CategoryName = categoryName,
                isActive = isActive
            });

            gviewCategory.EditIndex = -1;
            BindGViewCategory();
        }

        protected void gviewCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gviewCategory.DataKeys[e.RowIndex].Values["categoryId"]);

            int i = bll.DeleteCategory(id);

            gviewCategory.EditIndex = -1;
            BindGViewCategory();
        }

        protected void BindGViewCategory()
        {

            DataTable dt = bll.GetCategories();

            gviewCategory.DataSource = dt;
            gviewCategory.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string category = txtCategory.Text.Trim();

                if (category.Length == 0) return;

                int i = bll.AddCategory(category);

                if(i==0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Cannot create category')</script>", false);
                    return;
                }

                BindGViewCategory();
            }
            catch (Exception)
            {

            }
        }
    }
}