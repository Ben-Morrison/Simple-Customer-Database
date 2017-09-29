using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomerDatabase
{
    public partial class FormCustomers : Form
    {
        private FormMain form;
        private List<Customer> customers;
        private List<Customer> customerList = new List<Customer>();

        public FormCustomers(FormMain form, List<Customer> customers)
        {
            InitializeComponent();
            this.form = form;
            this.customers = customers;
        }

        #region Event Handlers

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            resetCustomers();
            updateCustomers();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(listView.SelectedIndices.Count > 0)
            {
                if (listView.SelectedIndices[0] > -1)
                    form.viewTabCustomer(customerList[listView.SelectedIndices[0]], true);

                this.Close();
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count > 0)
            {
                if (listView.SelectedIndices[0] > -1)
                    form.viewTabCustomer(customerList[listView.SelectedIndices[0]], false);

                this.Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count > 0)
            {
                if (listView.SelectedIndices[0] > -1)
                {
                    Customer c = customerList[listView.SelectedIndices[0]];
                    form.deleteCustomer(c);
                    updateCustomers();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        #endregion

        #region General Functions

        private void resetCustomers()
        {
            customerList = new List<Customer>();
            customerList = customers;
        }

        /// <summary>
        /// Updates the list of Customers
        /// </summary>
        private void updateCustomers()
        {
            listView.Items.Clear();
            for(int i = 0; i < customerList.Count; i++)
            {
                Customer c = customerList[i];
                ListViewItem item = new ListViewItem(new string[] { c.FirstName, c.LastName, c.Email, c.Home, c.Mobile, c.Address, c.State, c.Postcode });
                listView.Items.Add(item);
            }
        }

        /// <summary>
        /// Search the customers first name and last name
        /// </summary>
        /// <param name="s"></param>
        private void Search(string s)
        {
            s = s.Trim().ToLower();

            customerList = new List<Customer>();
            listView.Items.Clear();

            if (s.Equals(""))
            {
                resetCustomers();
                updateCustomers();
            }
            else
            {
                for (int i = 0; i < customers.Count; i++)
                    if (customers[i].FirstName.ToLower().Contains(s) ||
                        customers[i].LastName.ToLower().Contains(s) ||
                        customers[i].Email.ToLower().Contains(s) ||
                        customers[i].Home.ToLower().Contains(s) ||
                        customers[i].Mobile.ToLower().Contains(s) ||
                        customers[i].Address.ToLower().Contains(s))
                            customerList.Add(customers[i]);

                updateCustomers();
            }
        }

        #endregion
    }
}
