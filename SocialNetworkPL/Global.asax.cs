﻿using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using SocialNetworkBL.Config;
using SocialNetworkPL.Windsor;

namespace SocialNetworkPL
{
    public class MvcApplication : HttpApplication
    {
        private static readonly IWindsorContainer Container = new WindsorContainer();


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootstrapContainer();
        }

        private void BootstrapContainer()
        {
            Container.Install(new BusinessLayerInstaller());
            Container.Install(new PresentationLayerInstaller());

            var controllerFactory = new WindsorControllerFactory(Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}