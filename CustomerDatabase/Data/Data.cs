using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerDatabase
{
    public class Data
    {
        private IData data;

        public Data(IData data)
        {
            this.data = data;
        }

        public List<Customer> LoadCustomers()
        {
            return data.LoadCustomers();
        }

        public void SaveCustomers(List<Customer> c)
        {
            data.SaveCustomers(c);
        }

        public void LoadLog()
        {
            data.LoadLog();
        }

        public void SaveLog()
        {
            data.SaveLog();
        }
    }
}
