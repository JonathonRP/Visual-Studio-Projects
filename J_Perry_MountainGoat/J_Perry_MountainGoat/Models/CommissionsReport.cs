using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public partial class CommissionsReport
    {
        public string Employee_Name { get; set; }
        public float? Employee_Commission { get; set; }
        public int Employee_Qty_Sold { get; set; }
        public decimal Employee_Sales { get; set; }
        public float? Employee_Commission_Total { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<CommissionsReport> GetCommissionsReport()
        {
            var result = from sale in MGO_Entity.Sales
                         join employee in MGO_Entity.Employees on sale.Emp_ID equals employee.Emp_ID
                         join salesItem in MGO_Entity.SaleItems on sale.Sale_Num equals salesItem.Sale_Num
                         join item in MGO_Entity.Items on salesItem.SKU equals item.SKU
                         group sale by sale.Emp_ID into employee_sales
                         select new CommissionsReport()
                         {
                             Employee_Name = employee_sales.FirstOrDefault().Employee.Emp_FName + " " + employee_sales.FirstOrDefault().Employee.Emp_LName,
                             Employee_Commission = employee_sales.FirstOrDefault().Employee.Emp_Commission,
                             Employee_Qty_Sold = employee_sales.Count(),
                             Employee_Sales = employee_sales.Sum(s => s.SaleItems.FirstOrDefault().SI_Qty_Sold * s.SaleItems.FirstOrDefault().Item.Item_Price),
                             Employee_Commission_Total = (float?)employee_sales.Sum(s => s.SaleItems.FirstOrDefault().SI_Qty_Sold * s.SaleItems.FirstOrDefault().Item.Item_Price) * employee_sales.FirstOrDefault().Employee.Emp_Commission
                         };

            return result;
        }
    }
}