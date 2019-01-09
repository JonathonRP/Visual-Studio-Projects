using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public partial class EmployeeSalesReport
    {
        public string Employee_Name { get; set; }
        public float? Employee_Commission { get; set; }
        public decimal Sale_Total { get; set; }
        public DateTime Sale_Date { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<EmployeeSalesReport> GetEmployeeSalesReport()
        {
            var result = from Sale in MGO_Entity.Sales
                         join Employee in MGO_Entity.Employees on Sale.Emp_ID equals Employee.Emp_ID
                         join SalesItem in MGO_Entity.SaleItems on Sale.Sale_Num equals SalesItem.Sale_Num
                         join Item in MGO_Entity.Items on SalesItem.SKU equals Item.SKU
                         orderby Employee.Emp_FName, Employee.Emp_LName
                         select new EmployeeSalesReport()
                         {
                             Employee_Name = Employee.Emp_FName + " " + Employee.Emp_LName,
                             Employee_Commission = Employee.Emp_Commission * (float?)(SalesItem.SI_Qty_Sold * Item.Item_Price),
                             Sale_Total = SalesItem.SI_Qty_Sold * Item.Item_Price,
                             Sale_Date = Sale.S_Date                             
                         };

            return result;
        }
    }
}