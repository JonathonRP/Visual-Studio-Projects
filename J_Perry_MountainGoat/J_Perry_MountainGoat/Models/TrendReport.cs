using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public class TrendReport
    {
        public string Product_Category { get; set; }
        public decimal Category_Sales_TotalRevenue { get; set; }
        public DateTime Category_Sales_Date { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<TrendReport> GetTrendReport()
        {
            var result = from sale in MGO_Entity.Sales
                         join sales_item in MGO_Entity.SaleItems on sale.Sale_Num equals sales_item.Sale_Num
                         join item in MGO_Entity.Items on sales_item.SKU equals item.SKU
                         join category in MGO_Entity.Categories on item.Cat_Num equals category.Cat_Num
                         group category by category.Cat_Num into category_sales
                         select new TrendReport()
                         {
                             Product_Category = category_sales.FirstOrDefault().Cat_Description,
                             Category_Sales_TotalRevenue = category_sales.Sum(p => p.Items.FirstOrDefault().SaleItems.FirstOrDefault().SI_Qty_Sold * p.Items.FirstOrDefault().Item_Price),
                             Category_Sales_Date = category_sales.FirstOrDefault().Items.FirstOrDefault().SaleItems.FirstOrDefault().Sale.S_Date
                         };

            return result;
        }
    }
}