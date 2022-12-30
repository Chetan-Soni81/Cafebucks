using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity.User;
using BLL.User;

namespace Cafebucks
{
    public partial class SignupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            RegistrationUserObj user = new RegistrationUserObj();
            UserBLL bll = new UserBLL();

            try
            {
                user.Username = (string)txtUsername.Text;
                user.Firstname = (string)txtFname.Text;
                user.Lastname = (string)txtLname.Text;
                user.Email = (string)txtEmail.Text;
                user.Password = (string)txtPassword.Text;
                user.MobileNo = "0000000000";

                int i = bll.RegisterUser(user);

                if(i != 0)
                {
                    Session["user"] = i;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "<script>alert('Registration Failed!!!');</script>", false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}