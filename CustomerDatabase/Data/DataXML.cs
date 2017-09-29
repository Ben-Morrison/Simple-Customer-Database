using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace CustomerDatabase
{
    public class DataXML : IData
    {
        private static readonly string fileName = "save.xml";
        private static readonly string fileFullPath = Application.StartupPath + @"\" + fileName;

        /// <summary>
        /// Loads Customers from an XML file
        /// </summary>
        /// <returns>Returns a List of Customers</returns>
        public List<Customer> LoadCustomers()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                if (File.Exists(fileFullPath))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fileName);

                    XmlNodeList nodes = doc.SelectSingleNode("Customers").SelectNodes("Customer");

                    foreach (XmlNode node in nodes)
                    {
                        int customerID = int.Parse(node.SelectSingleNode("CustomerID").InnerText);
                        string firstName = node.SelectSingleNode("FirstName").InnerText;
                        string lastName = node.SelectSingleNode("LastName").InnerText;
                        string email = node.SelectSingleNode("Email").InnerText;
                        string home = node.SelectSingleNode("Home").InnerText;
                        string mobile = node.SelectSingleNode("Mobile").InnerText;
                        string address = node.SelectSingleNode("Address").InnerText;
                        string state = node.SelectSingleNode("State").InnerText;
                        string postcode = node.SelectSingleNode("Postcode").InnerText;

                        Customer c = new Customer(customerID, firstName, lastName, email, home, mobile, address, state, postcode);
                        customers.Add(c);
                    }

                    return customers;
                }
                else
                    return new List<Customer>();
            }
            catch (Exception e)
            {
                Log.AddLog(LogType.Error, DateTime.Now, e.Message);
                return new List<Customer>();
            }
        }

        /// <summary>
        /// Saves the Customers to an XML file
        /// </summary>
        /// <param name="customers">The Customers to save</param>
        /// <returns>Returns true or false for success or failure</returns>
        public bool SaveCustomers(List<Customer> customers)
        {
            try
            {
                if (File.Exists(fileFullPath))
                    File.Delete(fileFullPath);

                using (XmlWriter writer = XmlWriter.Create(fileName))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Customers");

                    foreach (Customer c in customers)
                    {
                        writer.WriteStartElement("Customer");

                        writer.WriteElementString("CustomerID", c.CustomerID.ToString());
                        writer.WriteElementString("FirstName", c.FirstName);
                        writer.WriteElementString("LastName", c.LastName);
                        writer.WriteElementString("Email", c.Email);
                        writer.WriteElementString("Home", c.Home);
                        writer.WriteElementString("Mobile", c.Mobile);
                        writer.WriteElementString("Address", c.Address);
                        writer.WriteElementString("State", c.State);
                        writer.WriteElementString("Postcode", c.Postcode);

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                Log.AddLog(LogType.Error, DateTime.Now, e.Message);
                return false;
            }
        }
    }
}