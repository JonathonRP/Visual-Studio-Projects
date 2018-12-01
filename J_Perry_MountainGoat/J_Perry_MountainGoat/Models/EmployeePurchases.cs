using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public partial class EmployeePurchases
    {
        public string Emp_Name { get; set; }
        public string Product_Name { get; set; }
        public DateTime Purchase_Date { get; set; }
        public decimal Purchase_Total { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<EmployeePurchases> GetEmployeePurchases()
        {
            var result = from Employee in MGO_Entity.Employees
                         join Purchase in MGO_Entity.Purchases on Employee.Emp_ID equals Purchase.Emp_ID
                         join PurchasesItem in MGO_Entity.PurchaseItems on Purchase.PO_Num equals PurchasesItem.PO_Num
                         join Item in MGO_Entity.Items on PurchasesItem.SKU equals Item.SKU
                         select new EmployeePurchases()
                         {
                             Emp_Name = Employee.Emp_FName + " " + Employee.Emp_LName,
                             Product_Name = Item.Item_Description,
                             Purchase_Date = Purchase.Purchase_Date,
                             Purchase_Total = PurchasesItem.PI_Qty * Item.Item_Price
                         };

            return result;
        }
    }
}