using System;
using System.Configuration;
using System.Web;

namespace DemoDCProject
{
    public class WebApplicationVirtualPathProvider
    {
        const char VirtualPathSeperator = '/';

        /// <summary>
        /// This Field provides the Application's Virtual Path.
        /// If the Application is Deployed as an IIS Website then this field will return a "/".
        /// If the Application is Deployed as an IIS Application (i.e. a sub folder of a Website) then
        /// this field will return the Virtual Path ending in a "/"
        /// </summary>
        private static readonly string appDomainAppVirtualPath;

        /// <summary>
        /// This Field provides the Full Path to the Physical Folder in which the application is deployed
        /// </summary>
        private static readonly string serverRootFolder = HttpRuntime.AppDomainAppPath;

        private static WebApplicationVirtualPathProvider instance = new WebApplicationVirtualPathProvider();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = "Can't use a static initializer since we need to use logic in order to initialize the appDomainAppVirtualPath member")]
        static WebApplicationVirtualPathProvider()
        {
            appDomainAppVirtualPath = HttpRuntime.AppDomainAppVirtualPath;
            if (appDomainAppVirtualPath[appDomainAppVirtualPath.Length - 1] != VirtualPathSeperator)
                appDomainAppVirtualPath += VirtualPathSeperator;
        }

        private WebApplicationVirtualPathProvider()
        {
        }

        public static WebApplicationVirtualPathProvider Instance()
        {
            return instance;
        }

        public virtual string AppDomainAppVirtualPath { get { return appDomainAppVirtualPath; } }

        public virtual string ServerRootFolder { get { return serverRootFolder; } }

        /// <summary>
        /// In this particular useage, we can't use null to determine if
        /// properties such as <see cref="JavaScriptCdn"/> have been initialized.
        /// So we use some arbitary initial value
        /// </summary>
        static string unInitializedValue = "-";

        #region JavaScripts Path Related Properties

        /// <summary>
        /// This is the "default" folder for JavaScripts.
        /// This field makes it possible to Not have to set
        /// the "JSCDN" appSetting in the web.config file
        /// Unless a real CDN is used.
        /// </summary>
        private static string javaScriptsSubFolder = "~/scripts";

        /// <summary>
        /// Backing field for the <see cref="JavaScriptCdn"/> property
        /// </summary>
        private static string javaScriptCdn = unInitializedValue;

        /// <summary>
        /// This property Gets the value of the "JSCDN" appSetting if there
        /// is one. Otherwise it will return null. The value of "JSCDN" can be
        /// a complete URL of the location of the JavaScript files or an
        /// Application Relative path such as "~/scripts" 
        /// </summary>
        private static string JavaScriptCdn
        {
            get
            {
                if (string.Equals(javaScriptCdn, unInitializedValue))
                {
                    javaScriptCdn = ConfigurationManager.AppSettings["JSCDN"];
                }

                return javaScriptCdn;
            }
        }

        /// <summary>
        /// This property Gets the Application Relative Virtual Path
        /// to use for JavaScript files. If the "JSCDN" appSetting has
        /// been defined in the web.config file (meaning you want to use
        /// a CDN to serve JavaScript Files) then it will return that path.
        /// The value of "JSCDN" can be the complete URL (CDN) of the location
        /// of the JavaScript files or an Application Relative path such as "~/scripts" 
        /// </summary>
        public virtual string JavaScriptsPath
        {
            get
            {
                if (string.IsNullOrEmpty(JavaScriptCdn))
                    return ResolveUrl(javaScriptsSubFolder);
                else
                    return ResolveUrl(JavaScriptCdn);
            }
        }

        #endregion JavaScripts Path Related Properties

        #region Images Path Related Properties

        /// <summary>
        /// This is the "default" folder for Images.
        /// This field makes it possible to Not have to set
        /// the "IMGCDN" appSetting in the web.config file
        /// Unless a real CDN is used.
        /// </summary>
        private static string imagesSubFolder = "~/content/images";

        /// <summary>
        /// Backing field for the <see cref="ImagesCdn"/> property
        /// </summary>
        private static string imagesCdn = unInitializedValue;

        /// <summary>
        /// This property Gets the value of the "IMGCDN" appSetting if there
        /// is one. Otherwise it will return null. The value of "IMGCDN" can be
        /// a complete URL of the location of the Image files or an
        /// Application Relative path such as "~/content/images"
        /// </summary>
        private static string ImagesCdn
        {
            get
            {
                if (string.Equals(imagesCdn, unInitializedValue))
                {
                    imagesCdn = ConfigurationManager.AppSettings["IMGCDN"];
                }

                return imagesCdn;
            }
        }

        /// <summary>
        /// This property Gets the Application Relative Virtual Path
        /// to use for Image files. If the "IMGCDN" appSetting has
        /// been defined in the web.config file (meaning you want to use
        /// a CDN to serve Images) then it will return that path.
        /// The value of "IMGCDN" can be the complete URL (CDN) of the location
        /// of the Image files or an Application Relative path such as "~/content/images".
        /// 
        /// </summary>
        public virtual string ImagesPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImagesCdn))
                    return ResolveUrl(imagesSubFolder);
                else
                    return ResolveUrl(ImagesCdn);
            }
        }

        #endregion Images Path Related Properties


        /// <summary>
        /// This method converts or resolves Partial URLs to Relative URLs.
        /// if the partialUrl starts with a "~/", then this method will return
        /// the Application relative path (starting with the application's root folder if any)
        /// Otherwise this method will simply prefix the partialUrl with the <see cref="appDomainAppVirtualPath"/> 
        /// </summary>
        /// <param name="partialUrl">A partial URL that may start with a "~/" to indicate relative to Application Root.</param>
        /// <returns>Returns an Application Relative URL relative to the Application's Root</returns>
        private static string ResolveUrl(string partialUrl)
        {
            if (partialUrl.StartsWith("~/", StringComparison.OrdinalIgnoreCase))
            {

                return appDomainAppVirtualPath + partialUrl.Substring(2);
            }
            else
                return appDomainAppVirtualPath + partialUrl;
        }

        /// <summary>
        /// This method returns the Website's complete URL including the http://. All the way, up to and including the AppDomainAppVirtualPath 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public string GetWebsiteRootUrl(HttpContextBase httpContext)
        {
            var url = httpContext.Request.Url.ToString();
            if (String.Compare(AppDomainAppVirtualPath, "/", StringComparison.OrdinalIgnoreCase) == 0)
                return url.Substring(0, url.IndexOf("/", 8, StringComparison.OrdinalIgnoreCase) + 1);
            else
                return url.Substring(0, url.IndexOf(AppDomainAppVirtualPath, StringComparison.OrdinalIgnoreCase) + AppDomainAppVirtualPath.Length);
        }
    }
}