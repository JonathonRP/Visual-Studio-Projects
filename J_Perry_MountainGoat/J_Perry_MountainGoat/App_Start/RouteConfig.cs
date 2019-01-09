using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
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
            
            //map custom moutain goat outfitters page routes
            routes.AddRoutes(new [] { new Route("{resource}.axd/{*pathInfo}", new StopRoutingHandler()),
                                      new WebFormRoutes {
                                            { "Data/Product", "~/Data/ProductData.aspx" },
                                            { "Customer/Info", "~/Data/CustomerInfo.aspx" },
                                            { "Customer/Purchases", "~/Data/CustomerPurchases.aspx"},
                                            { "Employee/Info", "~/Data/Manager/EmployeeInfo.aspx" },
                                            { "Employee/Purchases", "~/Data/Manager/EmployeePurchases.aspx" },
                                            { "Report/Commission", "~/Report/Manager/Commission.aspx" },
                                            { "Report/Customer", "~/Report/Customer.aspx" },
                                            { "Report/Employee", "~/Report/Manager/Employee.aspx" },
                                            { "Report/Product", "~/Report/Product.aspx" },
                                            { "Report/Revenue", "~/Report/Manager/Revenue.aspx" },
                                            { "Report/Revenue/Category", "~/Report/Manager/CategoryRevenue.aspx" },
                                            { "Report/Sales/Product", "~/Report/Manager/ProductSales.aspx" },
                                            { "Report/Sales/Employee", "~/Report/Manager/EmployeeSales.aspx" },
                                            { "Report/Trend", "~/Report/Manager/Trend.aspx" }
                                      },
                                      new MvcRoute("{controller}/{action}/{id}", new { action = "Index", id = UrlParameter.Optional })
            });
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

    public class WebFormsConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return routeDirection == RouteDirection.IncomingRequest;
        }
    }

    public class WebFormRoutes : WebFormRoute, IDictionary<string, string>
    {
        internal List<WebFormRoute> routes;
        private readonly List<string> keys;
        private readonly List<string> values;

        public string this[string key] {
            get => routes[GetIndexOfKey(key)].VirtualPath;

            set => routes[GetIndexOfKey(key)].VirtualPath = value;
        }

        public ICollection<string> Keys => keys;

        public ICollection<string> Values => values;

        public int Count => routes.Count;

        public bool IsReadOnly => false;

        public WebFormRoutes(string url = "", string virtualPath = "~/Default.aspx") : base(url, virtualPath)
        {
            routes = new List<WebFormRoute>();
            keys = new List<string>();
            values = new List<string>();
            
            routes.Add(new WebFormRoute(url, virtualPath));
            Keys.Add(url);
            Values.Add(virtualPath);
        }

        public void Add(string url, string virtualPath)
        {
            routes.Add(new WebFormRoute(url, virtualPath));
            Keys.Add(url);
            Values.Add(virtualPath);
        }

        public void Add(KeyValuePair<string, string> item)
        {
            routes.Add(new WebFormRoute(item.Key, item.Value));
            Keys.Add(item.Key);
            Values.Add(item.Value);
        }

        public void Clear()
        {
            routes.Clear();
            Keys.Clear();
            Values.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return routes.Contains(new WebFormRoute(item.Key, item.Value));
        }

        public bool ContainsKey(string key)
        {
            return TryGetIndexOfKey(key, out int index);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            var routesDictionary = new Dictionary<string, string>();
            foreach(var key in Keys)
            {
                foreach(var value in Values)
                {
                    routesDictionary.Add(key, value);
                }
            }

            Array.Copy(routesDictionary.ToArray(), array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            var routesDictionary = new Dictionary<string, string>();
            foreach (var key in Keys)
            {
                foreach (var value in Values)
                {
                    routesDictionary.Add(key, value);
                }
            }

            foreach (KeyValuePair<string, string> route in routesDictionary)
            {
                yield return route;
            }
        }

        public bool Remove(string key)
        {
            var url = (routes[GetIndexOfKey(key)] as WebFormRoute).Url;
            var virtualPath = (routes[GetIndexOfKey(key)] as WebFormRoute).VirtualPath;

            if (routes.Remove(new WebFormRoute(url, virtualPath)))
            {
                Keys.Remove(url);
                Values.Remove(virtualPath);
                return true;
            }
            return false;
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            var url = item.Key;
            var virtualPath = item.Value;

            if (routes.Remove(new WebFormRoute(url, virtualPath)))
            {
                Keys.Remove(url);
                Values.Remove(virtualPath);
                return true;
            }
            return false;
        }

        public bool TryGetValue(string key, out string value)
        {
            if (TryGetIndexOfKey(key, out int index))
            {
                value = (routes[index] as WebFormRoute).VirtualPath;
                return true;
            }
            value = default(string);
            return false;
        }

        private bool TryGetIndexOfKey(string key, out int index)
        {
            if (routes.Find(x => (x as WebFormRoute).Url == key) != null)
            {
                index = GetIndexOfKey(key);
                return true;
            }
            index = default(int);
            return false;
        }

        private int GetIndexOfKey(string key)
        {
            return (routes.FindIndex(x => (x as WebFormRoute).Url == key));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class WebFormRoute : Route
    {
        public new string Url { get; set; }

        public string VirtualPath { get; set; }

        public WebFormRoute(string url, string virtualPath) 
            : base(url, null, new RouteValueDictionary { { "outgoing", new WebFormsConstraint() } }, new PageRouteHandler(virtualPath, true))
        {
            Url = url;
            VirtualPath = virtualPath;
        }
    }

    public class MvcRoute : Route
    {
        public MvcRoute(string url, object defaults) 
            : base(url, new RouteValueDictionary(defaults), new MvcRouteHandler())
        {
            
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
        public static void AddRoutes<T>(this ICollection<T> routes, T[] NewRoutes) where T : RouteBase
        {
            Array.ForEach(NewRoutes, route => {

                    routes.Add(route);

                    if (route.GetType() == typeof(WebFormRoutes))
                    {
                        (route as WebFormRoutes).routes.ForEach(webFormRoute => routes.Add(webFormRoute as T));
                    }
            });
        }
    }
}
