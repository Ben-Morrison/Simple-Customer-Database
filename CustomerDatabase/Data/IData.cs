using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerDatabase
{
    public interface IData
    {
        List<Customer> LoadCustomers();
        bool SaveCustomers(List<Customer> customers);
    }
}
