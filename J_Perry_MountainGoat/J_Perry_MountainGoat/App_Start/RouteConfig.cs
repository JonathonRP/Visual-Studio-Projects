using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.Resolvers;

namespace MGO
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings
            {
                AutoRedirectMode = RedirectMode.Temporary
            };

            routes.EnableFriendlyUrls(settings, new UrlFriendlyResolver());

            //map custom moutain goat outfitters data static routes
            routes.MapPageRoute("", "", "~/Default.aspx");
            routes.MapPageRoute("ProductData", "Data/Product", "~/Data/ProductData.aspx");
            routes.MapPageRoute("CustomerInfo", "Customer/Info", "~/Data/CustomerInfo.aspx");
            routes.MapPageRoute("CustomerPurchases", "Customer/Purchases", "~/Data/CustomerPurchases.aspx");
            routes.MapPageRoute("EmployeeInfo", "Employee/Info", "~/Data/Manager/EmployeeInfo.aspx");
            routes.MapPageRoute("EmployeePurchases", "Employee/Purchases", "~/Data/Manager/EmployeePurchases.aspx");

            routes.MapPageRoute("CommissionsReport", "Report/Commission", "~/Report/Manager/Commission.aspx");
            routes.MapPageRoute("CutomerReport", "Report/Customer", "~/Report/Customer.aspx");
            routes.MapPageRoute("EmployeeReport", "Report/Employee", "~/Report/Manager/Employee.aspx");
            routes.MapPageRoute("ProductReport", "Report/Product", "~/Report/Product.aspx");
            routes.MapPageRoute("RevenueReport", "Report/Revenue", "~/Report/Manager/Revenue.aspx");
            routes.MapPageRoute("CategoryRevenueReport", "Report/Revenue/Category", "~/Report/Manager/CategoryRevenue.aspx");
            routes.MapPageRoute("ProductSalesReport", "Report/Sales/Product", "~/Report/Manager/ProductSales.aspx");
            routes.MapPageRoute("EmployeeSalesReport", "Report/Sales/Employee", "~/Report/Manager/EmployeeSales.aspx");
            routes.MapPageRoute("TrendReport", "Report/Trend", "~/Report/Manager/Trend.aspx");
        }
    }

    public class UrlFriendlyResolver : WebFormsFriendlyUrlResolver
    {
        protected override bool IsMobileExtension(HttpContextBase httpContext, string extension)
        {
            return false;
        }

        public override string ConvertToFriendlyUrl(string path)
        {
            string friendly_url = "";

            if (path.Contains("ProductData", StringComparison.CurrentCultureIgnoreCase)
                || path.Contains("CustomerInfo", StringComparison.CurrentCultureIgnoreCase)
                || path.Contains("CustomerPurchases", StringComparison.CurrentCultureIgnoreCase)
                || path.Contains("EmployeeInfo", StringComparison.CurrentCultureIgnoreCase)
                || path.Contains("EmployeePurchases", StringComparison.CurrentCultureIgnoreCase))
            {
                if (path.Contains("Data/Manager", StringComparison.CurrentCultureIgnoreCase))
                {
                    friendly_url = "~/" + path.Replace("Data/Manager", "", RegexOptions.IgnoreCase).Replace(".aspx", "", RegexOptions.IgnoreCase);
                }
                else
                {
                    friendly_url = "~/" + path.Replace("Data/", "", RegexOptions.IgnoreCase).Replace(".aspx", "", RegexOptions.IgnoreCase);
                }

                string[] url_splits = new string[] { "Product", "Info", "Purchases" };
                string url_split_on = "";

                foreach (var url_split in url_splits)
                {
                    if (path.Contains(url_split, StringComparison.CurrentCultureIgnoreCase))
                    {
                        url_split_on = url_split;
                    }
                }

                if (url_split_on.Equals("Product", StringComparison.CurrentCultureIgnoreCase))
                {
                    return string.Join("/", new[] { friendly_url.Replace("ProductData", "Data", RegexOptions.IgnoreCase), url_split_on });
                }

                return friendly_url.Insert(friendly_url.IndexOf(url_split_on, StringComparison.CurrentCultureIgnoreCase), "/");
            }
            else if (path.Contains("Commission", StringComparison.CurrentCultureIgnoreCase)
                     || path.Contains("Customer", StringComparison.CurrentCultureIgnoreCase)
                     || path.Contains("Employee", StringComparison.CurrentCultureIgnoreCase)
                     || path.Contains("Product", StringComparison.CurrentCultureIgnoreCase)
                     || path.Contains("Revenue", StringComparison.CurrentCultureIgnoreCase)
                     || path.Contains("CategoryRevenue", StringComparison.CurrentCultureIgnoreCase)
                     || path.Contains("ProductSales", StringComparison.CurrentCultureIgnoreCase)
                     || path.Contains("EmployeeSales", StringComparison.CurrentCultureIgnoreCase)
                     || path.Contains("Trend", StringComparison.CurrentCultureIgnoreCase))
            { 
                if (path.Contains("Reports/Manager", StringComparison.CurrentCultureIgnoreCase))
                {
                    friendly_url = "~/" + path.Replace("Manager/", "", RegexOptions.IgnoreCase).Replace(".aspx", "", RegexOptions.IgnoreCase);

                    if (path.Contains("Sales", StringComparison.CurrentCultureIgnoreCase))
                    {
                        friendly_url = "~/" + path.Replace("Manager/", "Sales/").Replace("Sales.aspx", "");
                    }
                    else if (path.Contains("Category", StringComparison.CurrentCultureIgnoreCase))
                    {
                        friendly_url = "~/" + path.Replace("Manager/", "Revenue/").Replace("Revenue.aspx", "");
                    }
                }
                else
                {
                    friendly_url = "~/" + path.Replace(".aspx", "", RegexOptions.IgnoreCase);
                }

                return friendly_url;
            }
            else if (path.Contains("Default", StringComparison.CurrentCultureIgnoreCase))
            {
                return "~/" + path.Replace("Default.aspx", "", RegexOptions.IgnoreCase);
            }

            return base.ConvertToFriendlyUrl(path);
        }
    }

    public static class Extension
    {
        public static bool Contains(this string text, string value, StringComparison stringComparison)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }
        public static string Replace(this string input, string search, string replacement, RegexOptions regexOptions)
        {
            return Regex.Replace(input, Regex.Escape(search), replacement.Replace("$", "$$"), regexOptions);
        }
        public static int IndexLength(this string str)
        {
            return str.Length - 1;
        }
    }
}
