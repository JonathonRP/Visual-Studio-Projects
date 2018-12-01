using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public partial class RevenueReport
    {
        public string Product_Category { get; set; }
        public string Product_Name { get; set; }
        public int Product_Qty_Sold { get; set; }
        public decimal Product_Sales_Revenue { get; set; }
        public decimal Product_Sales_TotalRevenue { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<RevenueReport> GetRevenueReport()
        {
            var result = from sale in MGO_Entity.Sales
                         join sales_item in MGO_Entity.SaleItems on sale.Sale_Num equals sales_item.Sale_Num
                         join item in MGO_Entity.Items on sales_item.SKU equals item.SKU
                         join category in MGO_Entity.Categories on item.Cat_Num equals category.Cat_Num
                         group item by item.SKU into product_sales
                         select new RevenueReport()
                         {
                             Product_Category = product_sales.FirstOrDefault().Category.Cat_Description,
                             Product_Name = product_sales.FirstOrDefault().Item_Description,
                             Product_Qty_Sold = product_sales.Sum(p => p.SaleItems.FirstOrDefault().SI_Qty_Sold),
                             Product_Sales_Revenue = product_sales.FirstOrDefault().Item_Price,
                             Product_Sales_TotalRevenue = product_sales.Sum(p => p.SaleItems.FirstOrDefault().SI_Qty_Sold * p.Item_Price)
                         };

            return result;
        }
    }
}