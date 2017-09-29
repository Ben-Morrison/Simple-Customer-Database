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

        private static readonly string logFileName = "log.xml";
        private static readonly string logFullPath = Application.StartupPath + @"\" + logFileName;

        /// <summary>
        /// Loads Customers from an XML file
        /// </summary>
        /// <returns>Returns a List of Customers</returns>
        public List<Customer> LoadCustomers()
        {
            Log.AddLog(LogType.Event, DateTime.Now, "Loading customers from XML file");

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

                    Log.AddLog(LogType.Event, DateTime.Now, "Customers successfully loaded");
                    return customers;
                }
                else
                {
                    Log.AddLog(LogType.Warning, DateTime.Now, "No previous Log available");
                    return new List<Customer>();
                }
            }
            catch (Exception e)
            {
                Log.AddLog(LogType.Error, DateTime.Now, "Error loading customers: " + e.Message);
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
            Log.AddLog(LogType.Event, DateTime.Now, "Saving customers to XML file");

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

                Log.AddLog(LogType.Event, DateTime.Now, "Customers successfully saved");

                return true;
            }
            catch (Exception e)
            {
                Log.AddLog(LogType.Error, DateTime.Now, "Error saving customers: " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Loads the Log from an XML file
        /// </summary>
        /// <returns>Returns a List of Customers</returns>
        public void LoadLog()
        {
            try
            {
                if (File.Exists(logFullPath))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(logFileName);

                    XmlNodeList nodes = doc.SelectSingleNode("Logs").SelectNodes("Log");

                    foreach (XmlNode node in nodes)
                    {
                        string type = node.SelectSingleNode("LogType").InnerText;
                        DateTime date = Convert.ToDateTime(node.SelectSingleNode("Date").InnerText);
                        string error = node.SelectSingleNode("Error").InnerText;

                        LogType logType;

                        switch(type)
                        {
                            case "Error":
                                logType = LogType.Error;
                                break;
                            case "Warning":
                                logType = LogType.Warning;
                                break;
                            case "Event":
                                logType = LogType.Event;
                                break;
                            default:
                                logType = LogType.Error;
                                break;
                        }

                        Log.AddLog(logType, date, error);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Saves the Customers to an XML file
        /// </summary>
        /// <param name="customers">The Customers to save</param>
        /// <returns>Returns true or false for success or failure</returns>
        public void SaveLog()
        {
            Log.AddLog(LogType.Event, DateTime.Now, "Saving Log to XML file");

            try
            {
                if (File.Exists(logFullPath))
                    File.Delete(logFullPath);

                using (XmlWriter writer = XmlWriter.Create(logFileName))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Logs");

                    foreach (Log log in Log.GetLog())
                    {
                        writer.WriteStartElement("Log");

                        writer.WriteElementString("LogType", log.LogType.ToString());
                        writer.WriteElementString("Date", log.Date.ToString());
                        writer.WriteElementString("Error", log.Error);

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}