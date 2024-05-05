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

        }

        protected void gviewCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void BindGViewCategory()
        {
            CategoryBLL bll = new CategoryBLL();

            DataTable dt = bll.GetCategories();

            gviewCategory.DataSource = dt;
            gviewCategory.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CategoryBLL bll = new CategoryBLL();
            try
            {
                string category = txtCategory.Text;

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