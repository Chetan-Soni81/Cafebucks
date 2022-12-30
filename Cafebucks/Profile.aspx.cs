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
    public partial class Profile : System.Web.UI.Page
    {
        public UserBLL userBLL = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = (int) Session["user"];

            UserObj user = userBLL.GetUserById(uid);

            img_profile.ImageUrl = user.ImagePath;
            lbl_name.Text = user.Firstname + (user.Middlename.Length > 0 ? user.Middlename : "") + user.Lastname;
            lbl_username.Text = user.Username;
            lbl_gender.Text = user.Gender;
            lbl_email.Text = user.Email;
            lbl_mobileno.Text = user.Mobileno;
            
            if(user.SpeakEnglish && user.SpeakHindi)
            {
                lbl_langs.Text = "Hindi and English";
            } else
            {
                if(user.SpeakEnglish)
                {
                    lbl_langs.Text = "English";
                }

                if(user.SpeakHindi)
                {
                    lbl_langs.Text = "Hindi";
                }
            }
        }
    }
}