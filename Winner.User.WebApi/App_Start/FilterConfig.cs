using System.Web;
using System.Web.Mvc;
using Winner.User.Api.Models.Mvc;

namespace Winner.User.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomizeHandleErrorAttribute());
        }
    }
}
