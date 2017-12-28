using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Providers.Behavior;
using Winner.Mvc.Audit;
using Winner.Platform.MVC.Provider;

namespace Winner.User.WebAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            const string APPID = "useradmin";
            const string SECRET_KEY = "0bf66348c2fa4dd2b325d19ba2ec4778";
            const string UUID_KEY = "efa20e4ceb9d426b87510a10cea2431f";
            const string SCOPE = "basic_api";
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ProviderManager.RegisterAccountProvider(new UserAccountProvider());
            ProviderManager.RegisterRightProvider(new RightProvider());
            ProviderManager.RegisterLoginProvider(new OAuthLoginProvider(APPID, SECRET_KEY, SCOPE, UUID_KEY, null));

        }
    }
}
