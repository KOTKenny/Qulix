using QulixTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QulixTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected virtual void Application_Error(Object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            var ex = context.Server.GetLastError();
            //Берём последнюю ошибку из контекста и логгируем
            LogErrors.LogedError(ex);
        }
    }
}
