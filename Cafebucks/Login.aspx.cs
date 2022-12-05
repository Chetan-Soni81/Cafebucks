using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity.Learn;
using BLL.Learn;

namespace Cafebucks
{
    public partial class Login : System.Web.UI.Page
    {
        private UserBLL userbll;

        public Login()
        {
            userbll = new UserBLL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBTN_Click(object sender, EventArgs e)
        {
            LoginModel login = new LoginModel();

            try
            {
                login.Username = txt_username.Text;
                login.Password = txt_password.Text;

                int user = userbll.LoginUser2(login);

                if(user == 0)
                {
                    lbl_result.Visible = true;
                } else
                {
                    lbl_result.Visible = false;
                    Session["User"] = user;
                    Response.Redirect("Profile.aspx");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}