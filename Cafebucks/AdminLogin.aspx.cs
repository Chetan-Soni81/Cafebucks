using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity.Admin;
using BLL.Admin;

namespace Cafebucks
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AdminBLL bll = new AdminBLL();

            try
            {
                AdminModel admin = new AdminModel();
                admin.Username = (string)txtUsername.Text;
                admin.Password = (string)txtPassword.Text;

                admin = bll.LoginAdmin(admin);

                if(admin.Id != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "<script>alert('Login Successfull')</script>", false);
                } else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "<script>alert('Login Failed')</script>", false);
                }
            }
            catch
            {

            }
        }
    }
}