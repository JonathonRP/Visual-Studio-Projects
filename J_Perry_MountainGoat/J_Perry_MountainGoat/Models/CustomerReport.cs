using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public partial class CustomerReport
    {
        public string Customer_Name { get; set; }
        public string Customer_Address { get; set; }
        public string Customer_Email { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<CustomerReport> GetCustomerReport()
        {
            var result = from Customer in MGO_Entity.Customers
                         select new CustomerReport()
                         {
                             Customer_Name = Customer.Cust_FName + " " + Customer.Cust_LName,
                             Customer_Address = Customer.Cust_Street1 + " " + Customer.Cust_Street2 + " " + Customer.Cust_City
                             + ", " + Customer.Cust_State + " " + Customer.Cust_ZIP,
                             Customer_Email = Customer.Cust_EMail
                         };

            return result;
        }
    }
}