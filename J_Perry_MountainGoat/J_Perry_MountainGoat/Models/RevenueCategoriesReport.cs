using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public partial class RevenueCategoriesReport
    {
        public string Product_Category { get; set; }
        public string Product_Name { get; set; }
        public int Category_Qty_Sold { get; set; }
        public decimal Category_Sales_Revenue { get; set; }
        public decimal Category_Sales_TotalRevenue { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<RevenueCategoriesReport> GetRevenueCategoriesReport()
        {
            var result = from sale in MGO_Entity.Sales
                         join sales_item in MGO_Entity.SaleItems on sale.Sale_Num equals sales_item.Sale_Num
                         join item in MGO_Entity.Items on sales_item.SKU equals item.SKU
                         join category in MGO_Entity.Categories on item.Cat_Num equals category.Cat_Num
                         group category by category.Cat_Num into category_sales
                         select new RevenueCategoriesReport()
                         {
                             Product_Category = category_sales.FirstOrDefault().Cat_Description,
                             Product_Name = category_sales.FirstOrDefault().Items.FirstOrDefault().Item_Description,
                             Category_Qty_Sold = category_sales.Sum(p => p.Items.FirstOrDefault().SaleItems.FirstOrDefault().SI_Qty_Sold),
                             Category_Sales_Revenue = category_sales.Sum(p => p.Items.FirstOrDefault().Item_Price),
                             Category_Sales_TotalRevenue = category_sales.Sum(p => p.Items.FirstOrDefault().SaleItems.FirstOrDefault().SI_Qty_Sold) * category_sales.Sum(p => p.Items.FirstOrDefault().Item_Price)
                         };

            return result;
        }
    }
}