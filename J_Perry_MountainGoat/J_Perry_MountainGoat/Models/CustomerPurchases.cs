using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public partial class CustomerPurchases
    {
        public string Customer_Name { get; set; }
        public string Product_Name { get; set; }
        public DateTime Purchase_Date { get; set; }
        public decimal Sale_Total { get; set; }
        public string Employee_Name { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<CustomerPurchases> GetCustomerPurchases()
        {
            var result = from Customer in MGO_Entity.Customers
                         join Sale in MGO_Entity.Sales on Customer.Cust_ID equals Sale.Cust_ID
                         join Employee in MGO_Entity.Employees on Sale.Emp_ID equals Employee.Emp_ID
                         join SalesItem in MGO_Entity.SaleItems on Sale.Sale_Num equals SalesItem.Sale_Num
                         join Item in MGO_Entity.Items on SalesItem.SKU equals Item.SKU
                         select new CustomerPurchases()
                         {
                             Customer_Name = Customer.Cust_FName + " " + Customer.Cust_LName,
                             Product_Name = Item.Item_Description,
                             Purchase_Date = Sale.S_Date,
                             Sale_Total = SalesItem.SI_Qty_Sold * Item.Item_Price,
                             Employee_Name = Employee.Emp_FName + " " + Employee.Emp_LName
                         };

            return result;
        }
    }
}