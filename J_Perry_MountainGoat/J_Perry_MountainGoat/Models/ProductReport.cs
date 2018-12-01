using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Models
{
    public partial class ProductReport
    {
        public string Product_Category { get; set; }
        public string Product_Name { get; set; }
        public decimal Product_Price { get; set; }

        static MGO_Entities MGO_Entity = new MGO_Entities();

        public static IEnumerable<ProductReport> GetProductReport()
        {
            var result = from Product in MGO_Entity.Items
                         join Category in MGO_Entity.Categories on Product.Cat_Num equals Category.Cat_Num
                         select new ProductReport()
                         {
                             Product_Category = Category.Cat_Description,
                             Product_Name = Product.Item_Description,
                             Product_Price = Product.Item_Price
                         };

            return result;
        }
    }
}