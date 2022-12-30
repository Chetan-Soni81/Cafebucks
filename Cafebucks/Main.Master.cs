using BLL.User;
using Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cafebucks
{
    public partial class Main : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    GetUserDetails();
                    userList.Visible = true;
                    defaultList.Visible = false;
                }
            }
        }

        private void GetUserDetails()
        {
            int id = Convert.ToInt32(Session["User"]);
            UserBLL bll = new UserBLL();
            UserObj user = bll.GetUserById(id);

            txtName.Text = user.Firstname + " " + user.Lastname;
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            
            Session.Abandon();
            userList.Visible = false;
            defaultList.Visible = true;
            Response.Redirect("Home.aspx");
        }
    }
}