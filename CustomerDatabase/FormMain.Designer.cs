namespace CustomerDatabase
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripCustomers = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolNew = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolSaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolClose = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(624, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.toolStripSeparator,
            this.menuSave,
            this.menuSaveAll,
            this.toolStripSeparator3,
            this.menuClose,
            this.menuCloseAll,
            this.toolStripSeparator2,
            this.menuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // menuNew
            // 
            this.menuNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewCustomer});
            this.menuNew.Image = global::CustomerDatabase.Properties.Resources.NewDocumentHS;
            this.menuNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuNew.Name = "menuNew";
            this.menuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuNew.Size = new System.Drawing.Size(141, 22);
            this.menuNew.Text = "&New";
            // 
            // menuNewCustomer
            // 
            this.menuNewCustomer.Image = global::CustomerDatabase.Properties.Resources.NewDocumentHS;
            this.menuNewCustomer.Name = "menuNewCustomer";
            this.menuNewCustomer.Size = new System.Drawing.Size(126, 22);
            this.menuNewCustomer.Text = "Customer";
            this.menuNewCustomer.Click += new System.EventHandler(this.menuNewCustomer_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(138, 6);
            // 
            // menuSave
            // 
            this.menuSave.Image = global::CustomerDatabase.Properties.Resources.saveHS;
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(141, 22);
            this.menuSave.Text = "&Save";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuSaveAll
            // 
            this.menuSaveAll.Image = global::CustomerDatabase.Properties.Resources.SaveAllHS;
            this.menuSaveAll.Name = "menuSaveAll";
            this.menuSaveAll.Size = new System.Drawing.Size(141, 22);
            this.menuSaveAll.Text = "Save All";
            this.menuSaveAll.Click += new System.EventHandler(this.menuSaveAll_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(138, 6);
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(141, 22);
            this.menuClose.Text = "&Close";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // menuCloseAll
            // 
            this.menuCloseAll.Name = "menuCloseAll";
            this.menuCloseAll.Size = new System.Drawing.Size(141, 22);
            this.menuCloseAll.Text = "Close All";
            this.menuCloseAll.Click += new System.EventHandler(this.menuCloseAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(138, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(141, 22);
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewCustomers,
            this.menuViewStatistics,
            this.menuViewLog});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // menuViewCustomers
            // 
            this.menuViewCustomers.Name = "menuViewCustomers";
            this.menuViewCustomers.Size = new System.Drawing.Size(131, 22);
            this.menuViewCustomers.Text = "&Customers";
            this.menuViewCustomers.Click += new System.EventHandler(this.menuViewCustomers_Click);
            // 
            // menuViewStatistics
            // 
            this.menuViewStatistics.Name = "menuViewStatistics";
            this.menuViewStatistics.Size = new System.Drawing.Size(131, 22);
            this.menuViewStatistics.Text = "&Statistics";
            this.menuViewStatistics.Click += new System.EventHandler(this.menuViewStatistics_Click);
            // 
            // menuViewLog
            // 
            this.menuViewLog.Name = "menuViewLog";
            this.menuViewLog.Size = new System.Drawing.Size(131, 22);
            this.menuViewLog.Text = "&Log";
            this.menuViewLog.Click += new System.EventHandler(this.menuViewLog_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(116, 22);
            this.menuAbout.Text = "&About...";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl.Location = new System.Drawing.Point(12, 52);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(600, 355);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripCustomers});
            this.statusStrip.Location = new System.Drawing.Point(0, 420);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(624, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            // 
            // statusStripCustomers
            // 
            this.statusStripCustomers.Name = "statusStripCustomers";
            this.statusStripCustomers.Size = new System.Drawing.Size(119, 17);
            this.statusStripCustomers.Text = "statusStripCustomers";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNew,
            this.toolSave,
            this.toolSaveAll,
            this.toolClose});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(624, 25);
            this.toolStrip.TabIndex = 3;
            // 
            // toolNew
            // 
            this.toolNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNew.Image = ((System.Drawing.Image)(resources.GetObject("toolNew.Image")));
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(23, 22);
            this.toolNew.Text = "&New Customer";
            this.toolNew.Click += new System.EventHandler(this.toolNew_Click);
            // 
            // toolSave
            // 
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSave.Image = global::CustomerDatabase.Properties.Resources.saveHS;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(23, 22);
            this.toolSave.Text = "Save";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolSaveAll
            // 
            this.toolSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSaveAll.Image = global::CustomerDatabase.Properties.Resources.SaveAllHS;
            this.toolSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveAll.Name = "toolSaveAll";
            this.toolSaveAll.Size = new System.Drawing.Size(23, 22);
            this.toolSaveAll.Text = "Save All";
            this.toolSaveAll.Click += new System.EventHandler(this.toolSaveAll_Click);
            // 
            // toolClose
            // 
            this.toolClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClose.Image = global::CustomerDatabase.Properties.Resources.DeleteHS;
            this.toolClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClose.Name = "toolClose";
            this.toolClose.Size = new System.Drawing.Size(23, 22);
            this.toolClose.Text = "Close";
            this.toolClose.Click += new System.EventHandler(this.toolClose_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem menuNewCustomer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuViewCustomers;
        private System.Windows.Forms.ToolStripMenuItem menuViewStatistics;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripCustomers;
        private System.Windows.Forms.ToolStripMenuItem menuCloseAll;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolSaveAll;
        private System.Windows.Forms.ToolStripButton toolClose;
        private System.Windows.Forms.ToolStripButton toolNew;
        private System.Windows.Forms.ToolStripMenuItem menuViewLog;
    }
}

