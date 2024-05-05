using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.User;

namespace Cafebucks
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            UserBLL bll = new UserBLL();

            try
            {
                string username = (string)txtUsername.Text;
                string password = (string)txtPassword.Text;

                int i = bll.LoginUser(username, password);

                if(i != 0)
                {
                    Session["User"] = i;
                    Response.Redirect("Default.aspx");
                } else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "<script>alert('Invalid Username or Password');</script>", false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}