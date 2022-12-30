using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity.User;
using BLL.User;
using System.Data;

namespace Cafebucks
{
    public partial class AddressPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStates();
            }
        }

        private void BindStates()
        {
            AddressBLL bll = new AddressBLL();

            DataTable dt = bll.getStates();

            dropStates.Items.Clear();

            dropStates.DataSource = dt;
            dropStates.DataBind();
            dropStates.Items.Insert(0, new ListItem("Choose...", "0"));
        }

        protected void DropState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dropStates.SelectedValue);

                AddressBLL bll = new AddressBLL();

                DataTable dt = bll.getCities(id);

                dropCities.Items.Clear();

                dropCities.DataSource = dt;
                dropCities.DataBind();
                dropCities.Items.Insert(0, new ListItem("Choose...", "0"));
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Address address = new Address();
                AddressBLL bll = new AddressBLL();

                address.Id = Convert.ToInt32(Session["User"]);
                address.FirstName = txtFirstName.Text;
                address.LastName = txtLastName.Text;
                address.House = txtBuilding.Text;
                address.Landmark = txtLandmark.Text;
                address.Street = txtStreet.Text;
                address.State = Convert.ToInt32(dropStates.SelectedValue);
                address.City = Convert.ToInt32(dropCities.SelectedValue);
                address.PIN = Convert.ToInt32(txtPinCode.Text);

                int i = bll.SaveAddress(address);

                if(i != 0)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //    protected void btnSubmit_Click(object sender, EventArgs e)
        //    {
        //        Address address = new Address();

        //        try
        //        {
        //            address.House = txtBuilding.Text;
        //            address.Street = txtStreet.Text;
        //            address.Locality = txtAddressLine2.Text;
        //            address.State = Convert.ToInt32(dropState.SelectedValue);
        //            address.City = Convert.ToInt32(dropCities.SelectedValue);
        //            address.PIN = Convert.ToInt32(txtZip.Text);

        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
    }
}