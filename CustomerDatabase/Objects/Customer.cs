using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerDatabase
{
    public class Customer
    {
        private static readonly string db_customerid = "customerID";
        private static readonly string db_firstname = "firstName";
        private static readonly string db_lastname = "lastName";
        private static readonly string db_email = "email";
        private static readonly string db_home = "home";
        private static readonly string db_mobile = "mobile";
        private static readonly string db_address = "address";
        private static readonly string db_state = "state";
        private static readonly string db_postcode = "postcode";

        private int customerID;
        private string firstName;
        private string lastName;
        private string email;
        private string home;
        private string mobile;
        private string address;
        private string state;
        private string postcode;

        public Customer(int customerID, string firstName, string lastName, string email, string home, string mobile, string address, string state, string postcode)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.home = home;
            this.mobile = mobile;
            this.address = address;
            this.state = state;
            this.postcode = postcode;
        }

        /// <summary>
        /// Gets the Customer ID
        /// </summary>
        public int CustomerID
        {
            get { return this.customerID; }
        }

        /// <summary>
        /// Gets or sets the customers first name
        /// </summary>
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        /// <summary>
        /// Gets or sets the customers last name
        /// </summary>
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        /// <summary>
        /// Gets or sets the customers email address
        /// </summary>
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        /// <summary>
        /// Gets or sets the customers home phone number
        /// </summary>
        public string Home
        {
            get { return this.home; }
            set { this.home = value; }
        }

        /// <summary>
        /// Gets or sets the customers mobile number
        /// </summary>
        public string Mobile
        {
            get { return this.mobile; }
            set { this.mobile = value; }
        }

        /// <summary>
        /// Gets or sets the customers address
        /// </summary>
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        /// <summary>
        /// Gets or sets the customers state
        /// </summary>
        public string State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        /// <summary>
        /// Gets or sets the customers postcode
        /// </summary>
        public string Postcode
        {
            get { return this.postcode; }
            set { this.postcode = value; }
        }
    }
}
