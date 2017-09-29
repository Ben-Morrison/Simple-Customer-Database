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
    public partial class FormMain : Form
    {
        // For placing the Controls on a Tab
        private static readonly int tabPaddingTop = 10;
        private static readonly int tabPaddingLabel = 10;
        private static readonly int tabPaddingControl = 100;
        private static readonly int tabControlGap = 28;
        private static readonly int tabLabelOffset = 3;

        public static List<Customer> customers = new List<Customer>();
        private Data data = new Data(new DataXML());

        public FormMain()
        {
            InitializeComponent();

            data.LoadLog();
            
            customers = data.LoadCustomers();

            updateFileMenu();
            updateStatusStrip();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            data.SaveLog();
        }

        #region File Menu

        // File > New > Customer
        private void menuNewCustomer_Click(object sender, EventArgs e)
        {
           createTabCustomer(null, true);
           updateFileMenu();
        }

        // File > Exit
        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // File > Close
        private void menuClose_Click(object sender, EventArgs e)
        {
            TabPage tab = tabControl.TabPages[tabControl.SelectedIndex];
            closeTab(tab);
        }

        // File > Close All
        private void menuCloseAll_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl.TabPages)
            {
                changeTabIndex(tab);
                closeTab(tab);
            }
        }

        // File > Save
        private void menuSave_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count > 0)
            {
                TabPage tab = tabControl.TabPages[tabControl.SelectedIndex];
                saveTab(tab);
            }
        }

        // File > Save All
        private void menuSaveAll_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl.TabPages)
            {
                changeTabIndex(tab);
                saveTab(tab);
            }
        }

        #endregion

        #region View Menu

        // View > Customers
        private void menuViewCustomers_Click(object sender, EventArgs e)
        {
            FormCustomers form = new FormCustomers(this, customers);
            form.ShowDialog();
        }

        // View > Statistics
        private void menuViewStatistics_Click(object sender, EventArgs e)
        {
            int countCustomers = customers.Count;

            MessageBox.Show("Customers: " + countCustomers.ToString(), "Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        // View > Log
        private void menuViewLog_Click(object sender, EventArgs e)
        {
            FormLog form = new FormLog();
            form.ShowDialog();
        }

        #endregion

        #region Help Menu

        // Help > About
        private void menuAbout_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog();
        }

        #endregion

        #region Tool Strip

        private void toolNew_Click(object sender, EventArgs e)
        {
            this.menuNewCustomer_Click(sender, e);
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            this.menuSave_Click(sender, e);
        }

        private void toolSaveAll_Click(object sender, EventArgs e)
        {
            this.menuSaveAll_Click(sender, e);
        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.menuClose_Click(sender, e);
        }

        #endregion

        #region Tab Control

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFileMenu();
        }

        #endregion

        #region Functions

        /// <summary>
        /// Updates the text on the Status Strip
        /// </summary>
        private void updateStatusStrip()
        {
            statusStripCustomers.Text = "Stored Customers: " + customers.Count;
        }

        /// <summary>
        /// Disables or enabled menu and tool strip controls based on the number of tabs
        /// </summary>
        private void updateFileMenu()
        {
            if (tabControl.TabPages.Count < 1)
            {
                menuSave.Enabled = false;
                menuSaveAll.Enabled = false;
                menuClose.Enabled = false;
                menuCloseAll.Enabled = false;
                toolSave.Enabled = false;
                toolSaveAll.Enabled = false;
                toolClose.Enabled = false;
            }
            else
            {
                menuSave.Enabled = true;
                menuSaveAll.Enabled = true;
                menuClose.Enabled = true;
                menuCloseAll.Enabled = true;
                toolSave.Enabled = true;
                toolSaveAll.Enabled = true;
                toolClose.Enabled = true;
            }
        }

        /// <summary>
        /// Event for the close button on each tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void eventCloseTabButton(object sender, EventArgs e)
        {
            TabPage tab = tabControl.TabPages[tabControl.SelectedIndex];
            closeTab(tab);
        }

        /// <summary>
        /// Close a tab on a Tab Control
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="tab"></param>
        public void closeTab(TabPage tab)
        {
            TabData data = (TabData)(tab.Tag);

            bool close = false;

            if (data.Modified)
            {
                DialogResult result = MessageBox.Show("Do you want to save before closing?", "Save changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    close = saveTab(tab);
                }
                else if (result == System.Windows.Forms.DialogResult.No)
                {
                    close = true;
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    close = false;
                }
            }
            else
            {
                close = true;
            }

            if (close)
            {
                tab.Tag = null;
                tabControl.TabPages.Remove(tab);
                updateFileMenu();
            }
        }

        /// <summary>
        /// Save the data on a Tab
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="tab"></param>
        public bool saveTab(TabPage tab)
        {
            bool success = false;

            TabData tabData = (TabData)(tab.Tag);
            success = tabData.Save(data);

            updateStatusStrip();

            return success;
        }

        /// <summary>
        /// Change the currently selected tab
        /// </summary>
        /// <param name="tab">The tab you wish to have focus</param>
        public void changeTabIndex(TabPage tab)
        {
            tabControl.SelectedIndex = tabControl.TabPages.IndexOf(tab);
            TabData tabData = (TabData)(tabControl.TabPages[tabControl.SelectedIndex].Tag);

            if (tabData.Edit)
            {
                tabData.EnableControls();
            }
            else
            {
                tabData.DisableControls();
            }
        }

        /// <summary>
        /// Created a Tab for a Customer
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="c"></param>
        public void createTabCustomer(Customer c, bool edit)
        {
            // Create the tab
            TabPage tab = new TabPage();
            tabControl.TabPages.Add(tab);

            // Create the data for the tab
            TabDataCustomer tabData = new TabDataCustomer();
            tabData.TabID = tabControl.TabPages.IndexOf(tab);
            tabData.Title = "New Customer";
            tabData.Tab = tab;
            tab.Text = tabData.Title + "*";

            #region Labels

            // Create the Labels
            Label labelID = new Label();
            labelID.Location = new Point(tabPaddingLabel, tabPaddingTop + (tabControlGap * 0) + tabLabelOffset);
            labelID.Size = new System.Drawing.Size(80, 20);
            labelID.Text = "Customer ID";
            tab.Controls.Add(labelID);

            Label labelFirstName = new Label();
            labelFirstName.Location = new Point(tabPaddingLabel, tabPaddingTop + (tabControlGap * 1) + tabLabelOffset);
            labelFirstName.Size = new System.Drawing.Size(80, 20);
            labelFirstName.Text = "First Name";
            tab.Controls.Add(labelFirstName);

            Label labelLastName = new Label();
            labelLastName.Location = new Point(tabPaddingLabel, tabPaddingTop + (tabControlGap * 2) + tabLabelOffset);
            labelLastName.Size = new System.Drawing.Size(80, 20);
            labelLastName.Text = "Last Name";
            tab.Controls.Add(labelLastName);

            Label labelEmail = new Label();
            labelEmail.Location = new Point(tabPaddingLabel, tabPaddingTop + (tabControlGap * 3) + tabLabelOffset);
            labelEmail.Size = new System.Drawing.Size(80, 20);
            labelEmail.Text = "Email";
            tab.Controls.Add(labelEmail);

            Label labelHome = new Label();
            labelHome.Location = new Point(tabPaddingLabel, tabPaddingTop + (tabControlGap * 4) + tabLabelOffset);
            labelHome.Size = new System.Drawing.Size(80, 20);
            labelHome.Text = "Home Phone";
            tab.Controls.Add(labelHome);

            Label labelMobile = new Label();
            labelMobile.Location = new Point(tabPaddingLabel, tabPaddingTop + (tabControlGap * 5) + tabLabelOffset);
            labelMobile.Size = new System.Drawing.Size(80, 20);
            labelMobile.Text = "Mobile";
            tab.Controls.Add(labelMobile);

            Label labelAddress = new Label();
            labelAddress.Location = new Point(tabPaddingLabel, tabPaddingTop + (tabControlGap * 6) + tabLabelOffset);
            labelAddress.Size = new System.Drawing.Size(80, 20);
            labelAddress.Text = "Address";
            tab.Controls.Add(labelAddress);

            Label labelState = new Label();
            labelState.Location = new Point(tabPaddingLabel, tabPaddingTop + (tabControlGap * 7) + tabLabelOffset);
            labelState.Size = new System.Drawing.Size(80, 20);
            labelState.Text = "State";
            tab.Controls.Add(labelState);

            Label labelPostcode = new Label();
            labelPostcode.Location = new Point(tabPaddingLabel, tabPaddingTop + (tabControlGap * 8) + tabLabelOffset);
            labelPostcode.Size = new System.Drawing.Size(80, 20);
            labelPostcode.Text = "Postcode";
            tab.Controls.Add(labelPostcode);

            #endregion

            #region Controls

            // Create the Controls
            tabData.TxtID = new TextBox();
            tabData.TxtID.Location = new Point(tabPaddingControl, tabPaddingTop + (tabControlGap * 0));
            tabData.TxtID.Size = new System.Drawing.Size(200, 10);
            tabData.TxtID.Enabled = false;
            tab.Controls.Add(tabData.TxtID);
            tabData.TxtID.TextChanged += new EventHandler(tabData.EventNotSaved);

            tabData.TxtFirstName = new TextBox();
            tabData.TxtFirstName.Location = new Point(tabPaddingControl, tabPaddingTop + (tabControlGap * 1));
            tabData.TxtFirstName.Size = new System.Drawing.Size(200, 10);
            tab.Controls.Add(tabData.TxtFirstName);
            tabData.TxtFirstName.TextChanged += new EventHandler(tabData.EventTitle);

            tabData.TxtLastName = new TextBox();
            tabData.TxtLastName.Location = new Point(tabPaddingControl, tabPaddingTop + (tabControlGap * 2));
            tabData.TxtLastName.Size = new System.Drawing.Size(200, 10);
            tab.Controls.Add(tabData.TxtLastName);
            tabData.TxtLastName.TextChanged += new EventHandler(tabData.EventTitle);

            tabData.TxtEmail = new TextBox();
            tabData.TxtEmail.Location = new Point(tabPaddingControl, tabPaddingTop + (tabControlGap * 3));
            tabData.TxtEmail.Size = new System.Drawing.Size(200, 10);
            tab.Controls.Add(tabData.TxtEmail);
            tabData.TxtEmail.TextChanged += new EventHandler(tabData.EventNotSaved);

            tabData.TxtHome = new TextBox();
            tabData.TxtHome.Location = new Point(tabPaddingControl, tabPaddingTop + (tabControlGap * 4));
            tabData.TxtHome.Size = new System.Drawing.Size(200, 10);
            tab.Controls.Add(tabData.TxtHome);
            tabData.TxtHome.TextChanged += new EventHandler(tabData.EventNotSaved);

            tabData.TxtMobile = new TextBox();
            tabData.TxtMobile.Location = new Point(tabPaddingControl, tabPaddingTop + (tabControlGap * 5));
            tabData.TxtMobile.Size = new System.Drawing.Size(200, 10);
            tab.Controls.Add(tabData.TxtMobile);
            tabData.TxtMobile.TextChanged += new EventHandler(tabData.EventNotSaved);

            tabData.TxtAddress = new TextBox();
            tabData.TxtAddress.Location = new Point(tabPaddingControl, tabPaddingTop + (tabControlGap * 6));
            tabData.TxtAddress.Size = new System.Drawing.Size(200, 10);
            tab.Controls.Add(tabData.TxtAddress);
            tabData.TxtAddress.TextChanged += new EventHandler(tabData.EventNotSaved);

            tabData.TxtState = new TextBox();
            tabData.TxtState.Location = new Point(tabPaddingControl, tabPaddingTop + (tabControlGap * 7));
            tabData.TxtState.Size = new System.Drawing.Size(200, 10);
            tab.Controls.Add(tabData.TxtState);
            tabData.TxtState.TextChanged += new EventHandler(tabData.EventNotSaved);

            tabData.TxtPostcode = new TextBox();
            tabData.TxtPostcode.Location = new Point(tabPaddingControl, tabPaddingTop + (tabControlGap * 8));
            tabData.TxtPostcode.Size = new System.Drawing.Size(200, 10);
            tab.Controls.Add(tabData.TxtPostcode);
            tabData.TxtPostcode.TextChanged += new EventHandler(tabData.EventNotSaved);

            #endregion

            tabData.Edit = edit;

            if (c == null)
            {
                tabData.Modified = true;
                tabData.customer = new Customer(-1, "", "", "", "", "", "", "", "");
            }
            else
            {
                tabData.customer = c;

                tabData.TxtID.Text = c.CustomerID.ToString();
                tabData.TxtFirstName.Text = c.FirstName;
                tabData.TxtLastName.Text = c.LastName;
                tabData.TxtEmail.Text = c.Email;
                tabData.TxtHome.Text = c.Home;
                tabData.TxtMobile.Text = c.Mobile;
                tabData.TxtAddress.Text = c.Address;
                tabData.TxtState.Text = c.State;
                tabData.TxtPostcode.Text = c.Postcode;

                tabData.Modified = false;
                tabData.updateTitle();
            }

            tab.Tag = tabData;
            tabControl.SelectedIndex = tabControl.TabPages.IndexOf(tab);
            updateFileMenu();
        }

        /// <summary>
        /// If the given Customer is found in the tab control, change the tab index, if not found, create a new tab for the existing Customer
        /// </summary>
        /// <param name="c">The Customer to be displayed</param>
        public void viewTabCustomer(Customer c, bool edit)
        {
            bool found = false;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                TabPage tab = tabControl.TabPages[i];
                TabDataCustomer tabData = (TabDataCustomer)(tab.Tag);

                if (tabData.customer.Equals(c))
                {
                    tabData.Edit = edit;
                    changeTabIndex(tab);
                    found = true;
                }
            }
            if (!found)
            {
                createTabCustomer(c, edit);
            }
        }

        /// <summary>
        /// Deletes a Customer then saves all data
        /// </summary>
        /// <param name="c">The Customer to be deleted</param>
        public void deleteCustomer(Customer c)
        {
            string name = c.FirstName + " " + c.LastName;
            DialogResult result = MessageBox.Show("Are you sure you want to delete the customer " + name + "?", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    TabPage tab = tabControl.TabPages[i];
                    TabDataCustomer tabData = (TabDataCustomer)(tab.Tag);
                    if (tabData.customer.Equals(c))
                    {
                        closeTab(tab);
                    }
                }

                Log.AddLog(LogType.Event, DateTime.Now, "Removing Customer: " + name);
                customers.Remove(c);

                data.SaveCustomers(customers);

                updateStatusStrip();
            }
        }

        #endregion
    }
}
