using System.Web;
using System.Web.Mvc;

namespace DiMuro.Arthur._5i.XMLReadWrite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
