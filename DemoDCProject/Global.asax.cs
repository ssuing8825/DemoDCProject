using DemoDCProject.DomainLayer;
using DemoDCProject.DomainLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DemoDCProject
{
    public class Global : HttpApplication, IRuntimeEnvironmentIsolationService
    {
        private WebApplicationVirtualPathProvider webApplicationVirtualPathProvider;
        internal DomainFacade DomainFacade { get; private set; }

        public string AppDomainAppVirtualPath
        {
            get { return webApplicationVirtualPathProvider.AppDomainAppVirtualPath; }
        }

        public string ServerRootFolder
        {
            get { return webApplicationVirtualPathProvider.ServerRootFolder; }
        }

        public string WebsiteUrl
        {
            get { return webApplicationVirtualPathProvider.GetWebsiteRootUrl(new HttpContextWrapper(HttpContext.Current)); }
        }

        protected void Application_Start()
        {
            webApplicationVirtualPathProvider = WebApplicationVirtualPathProvider.Instance();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public override void Init()
        {
            base.Init();
            DomainFacade = new DomainFacade(this);
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
