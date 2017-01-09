﻿using InteractivePreGeneratedViews;
using referenceArchitecture.Core.Helpers;
using referenceArchitecture.repository._0.__Edmx;
using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace referenceArchitecture.ui
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Precompile views for entityframework
            var hp = DependencyResolver.Current.GetService<Ihp>();
            if (hp.getStringFromAppConfig("usingPrecompileViews") == "true")
            {
                using (var context = new ExampleDB())
                {
                    // Build route from separated commas values in app.config
                    var path = hp.getPathFromSeparatedCommaValue("preCompileViewEFInAppData");

                    InteractiveViews.SetViewCacheFactory
                    (
                        context,
                        new FileViewCacheFactory(path)
                    );
                }
            }
        }
        protected void Application_Error()
        {
            // Get excepcion and clear error
            Exception exception = Server.GetLastError();
            Server.ClearError();

            // Get controller and action from appconfig and go to that route
            var controllerAndAction = ConfigurationManager.AppSettings["controllerAndActionErrorRedirect"].Split(',');
            Response.RedirectToRoute(new
            {
                controller = controllerAndAction[0],
                action = controllerAndAction[1],
                exceptionMessage = exception.Message 
            });
        }
    }
}
