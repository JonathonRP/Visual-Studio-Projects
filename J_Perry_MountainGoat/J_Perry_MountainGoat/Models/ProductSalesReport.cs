using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public partial class ProductSalesReport
    {
        public string Product_Category { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Qty_Sold { get; set; }
        public decimal Product_Price { get; set; }
        public decimal Sale_Total { get; set; }
        public DateTime Sale_Date { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<ProductSalesReport> GetProductSalesReport()
        {
            var result = from Sale in MGO_Entity.Sales
                         join SalesItem in MGO_Entity.SaleItems on Sale.Sale_Num equals SalesItem.Sale_Num
                         join Item in MGO_Entity.Items on SalesItem.SKU equals Item.SKU
                         join Category in MGO_Entity.Categories on Item.Cat_Num equals Category.Cat_Num
                         group Item by Item.SKU into Products_Sold
                         select new ProductSalesReport()
                         {
                             Product_Name = Products_Sold.FirstOrDefault().Item_Description,
                             Product_Category = Products_Sold.FirstOrDefault().Category.Cat_Description,
                             Product_Qty_Sold = Products_Sold.Sum(p => p.SaleItems.FirstOrDefault().SI_Qty_Sold),
                             Product_Price = Products_Sold.FirstOrDefault().Item_Price,
                             Sale_Date = Products_Sold.FirstOrDefault().SaleItems.FirstOrDefault().Sale.S_Date,
                             Sale_Total = Products_Sold.Sum(p => p.SaleItems.FirstOrDefault().SI_Qty_Sold * p.Item_Price)
                         };

            return result;
        }
    }
}