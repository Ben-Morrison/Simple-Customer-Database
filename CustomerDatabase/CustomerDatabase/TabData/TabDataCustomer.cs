using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CustomerDatabase
{
    public class TabDataCustomer : TabData
    {
        public Customer customer;

        public TextBox TxtID = new TextBox();
        public TextBox TxtFirstName = new TextBox();
        public TextBox TxtLastName = new TextBox();
        public TextBox TxtEmail = new TextBox();
        public TextBox TxtHome = new TextBox();
        public TextBox TxtMobile = new TextBox();
        public TextBox TxtAddress = new TextBox();
        public TextBox TxtState = new TextBox();
        public TextBox TxtPostcode = new TextBox();

        public override void EventTitle(object sender, EventArgs e)
        {
            this.Title = TxtFirstName.Text + " " + TxtLastName.Text;
            this.Modified = true;
            this.EventNotSaved(sender, e);
        }

        public override void EnableControls()
        {
            this.TxtFirstName.ReadOnly = false;
            this.TxtLastName.ReadOnly = false;
            this.TxtEmail.ReadOnly = false;
            this.TxtHome.ReadOnly = false;
            this.TxtMobile.ReadOnly = false;
            this.TxtAddress.ReadOnly = false;
            this.TxtState.ReadOnly = false;
            this.TxtPostcode.ReadOnly = false;
        }

        public override void DisableControls()
        {
            this.TxtFirstName.ReadOnly = true;
            this.TxtLastName.ReadOnly = true;
            this.TxtEmail.ReadOnly = true;
            this.TxtHome.ReadOnly = true;
            this.TxtMobile.ReadOnly = true;
            this.TxtAddress.ReadOnly = true;
            this.TxtState.ReadOnly = true;
            this.TxtPostcode.ReadOnly = true;
        }

        public override void Save(Data data)
        {
            if (TxtFirstName.Text.Trim().Equals("") || TxtLastName.Text.Trim().Equals(""))
            {
                MessageBox.Show("The First Name or Last Name fields cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool exists;

                if (FormMain.customers.IndexOf(customer) == -1)
                    exists = false;
                else
                    exists = true;

                customer.FirstName = TxtFirstName.Text;
                customer.LastName = TxtLastName.Text;
                customer.Email = TxtEmail.Text;
                customer.Home = TxtHome.Text;
                customer.Mobile = TxtMobile.Text;
                customer.Address = TxtAddress.Text;
                customer.State = TxtState.Text;
                customer.Postcode = TxtPostcode.Text;

                Modified = false;
                Tab.Text = Title;

                if (!exists)
                    FormMain.customers.Add(customer);

                data.SaveCustomers(FormMain.customers);
            }
        }
    }
}
