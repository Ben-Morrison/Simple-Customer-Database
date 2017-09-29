using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CustomerDatabase
{
    /// <summary>
    /// This abstract class provides a data structure for each page on a Tab Control
    /// </summary>
    public abstract class TabData
    {
        private int tabID;
        private bool modified;
        private bool edit;
        private string title;
        private TabPage tab;

        public int TabID
        {
            get { return tabID; }
            set { tabID = value; }
        }

        /// <summary>
        /// Has this Tab been modified
        /// </summary>
        public bool Modified
        {
            get { return modified; }
            set { modified = value; }
        }

        /// <summary>
        /// Should this Tab enable editing
        /// </summary>
        public bool Edit
        {
            get { return edit; }
            set
            {
                edit = value;
                if (edit)
                    this.EnableControls();
                else
                    this.DisableControls();
            }
        }

        /// <summary>
        /// The title displayed on the Tab
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// A reference to the Tab that contains this data
        /// </summary>
        public TabPage Tab
        {
            get { return tab; }
            set { tab = value; }
        }

        /// <summary>
        /// Update the title of the Tab based on the saved state
        /// </summary>
        public void updateTitle()
        {
            if (this.modified)
            {
                this.tab.Text = this.title + "*";
            }
            else
            {
                this.tab.Text = this.title;
            }
        }

        /// <summary>
        /// Event Handler for setting saved state of the tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EventNotSaved(object sender, EventArgs e)
        {
            this.modified = true;
            this.updateTitle();
        }

        /// <summary>
        /// Event Handler for changing the title of the Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void EventTitle(object sender, EventArgs e);

        /// <summary>
        /// Disable the editing controls on the Tab
        /// </summary>
        public abstract void EnableControls();

        /// <summary>
        /// Enable the editing controls on the Tab
        /// </summary>
        public abstract void DisableControls();

        /// <summary>
        /// Save the data on the Tab
        /// </summary>
        public abstract void Save(Data data);
    }
}
