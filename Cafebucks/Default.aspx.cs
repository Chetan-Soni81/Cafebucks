using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity.Learn;
using BLL.Learn;

namespace Cafebucks
{
    public partial class Default : System.Web.UI.Page
    {

        private UserBLL userBLL;

        public Default()
        {
            userBLL = new UserBLL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBTN_Click(object sender, EventArgs e)
        {
            RegistrationModel user = new RegistrationModel();

            try
            {
                user.Username = txt_username.Text;
                user.Firstname = txt_fname.Text;
                user.Middlename = txt_mname.Text;
                user.Lastname = txt_lname.Text;

                if( radio_gender.SelectedValue == "1")
                {
                    user.Gender = 1;
                } else if (radio_gender.SelectedValue == "2")
                {
                    user.Gender = 0;
                }

                user.Email = txt_email.Text;
                user.Mobileno = txt_mobileno.Text;
                user.Password = txt_password.Text;
                user.SpeakEnglish = check_english.Checked;
                user.SpeakHindi = check_hindi.Checked;

                string path = "";
                if (file_profile.HasFile)
                {
                    string filename = DateTime.Now.ToString("yyyymmddhhmmtt") + Path.GetFileName(file_profile.FileName);
                    path = Server.MapPath("~/Uploads/Profile/") + filename;
                    //file_profile.SaveAs(path);
                    user.ImagePath = "~/Uploads/Profile/" + filename;
                }

                int i = userBLL.RegisterUser(user);

                if (i != 0)
                {
                    file_profile.SaveAs(path);
                    Session["User"] = user;
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    result_p.Visible = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}