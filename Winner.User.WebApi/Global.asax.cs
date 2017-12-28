using Javirs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Winner.User.Api.Models.Mvc;
using Winner.WebApi.Contract;

namespace Winner.User.Api
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            VerificationManager.Register(new ApiVerification());

            ProviderContainer.Register<Facade.User.UserAccountProfile>();
            ProviderContainer.Register<Facade.User.UserOrganizationsProfile>();
            ProviderContainer.Register<Facade.User.UserAscriptionProfile>();
        }
    }
}
