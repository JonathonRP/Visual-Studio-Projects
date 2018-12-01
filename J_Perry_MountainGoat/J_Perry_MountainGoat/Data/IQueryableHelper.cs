using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGO.Data
{
    public static class IQueryableHelper
    {
        public static bool IsNull<T>(this IQueryable<T> query)
        {
            return (query.SingleOrDefault() == null) ? true : false;
        }
    }
}