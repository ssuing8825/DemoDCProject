using DemoDCProject.DomainLayer;
using DemoDCProject.DomainLayer.Exceptions;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DemoDCProject.Controllers
{
    public class ApiControllerBase : ApiController
    {

        private readonly ILog logger;

        private DomainFacade domainFacade;
        public DomainFacade DomainFacade { get { return domainFacade ?? (domainFacade = MakeDomainFacade()); } }

        protected virtual DomainFacade MakeDomainFacade()
        {

            //IIS Caches the thread and caches the instance of the domain facade. This means that we don't recreate the 
            // domain facade over and over. It's actually cached on the same thread. Easier on GC too. 
            // Entire system is stateless. 
            return ((Global)System.Web.HttpContext.Current.ApplicationInstance).DomainFacade;
        }

        protected ApiControllerBase()
        {
            this.logger = log4net.LogManager.GetLogger(this.GetType());
        }
        
        protected ILog Logger
        {
            get { return this.logger; }
        }


        /// <summary>
        /// This method assembles an instance of a HttpResponseException such that the ReasonPhrase is the actual Exception Message
        /// and the HTTP Content is the Stack Trace. It also adds an HTTP Header called X-Exception-Type whose value is the fully qualified
        /// name of the Type of Exception. This will help calling application rehydrate an exception of the correct type and message.
        /// </summary>
        /// <param name="exception">An instance of an Exception</param>
        /// <returns>An instance of an HttpResponseException</returns>
        protected HttpResponseException ConstructHttpResponseException(string requestInfo, Exception exception)
        {
            Exception actualException = exception;
            while (actualException.InnerException != null)
            {
                actualException = actualException.InnerException;
            }

            HttpStatusCode httpStatusCode;

            // Domain Exceptions should result in a "Bad Request" rather than an "Internal Server Error"
            string requestMessageToLog = string.Format("Request message to the controler - {0}  ", requestInfo); ;
            string responseBody = string.Empty;

            if (actualException.GetType().IsSubclassOf(typeof(NotFoundException)))
            {
                httpStatusCode = HttpStatusCode.NotFound;
                this.logger.ErrorFormat("NotFoundException Caught in Controller::  {0}", requestMessageToLog);

            }
            else if (actualException.GetType().IsSubclassOf(typeof(DemoDCProjectBusinessException)))
            {
                httpStatusCode = HttpStatusCode.BadRequest;
                this.logger.ErrorFormat("DemoDCProjectBusinessException Caught in Controller::  {0} {1}", actualException, requestMessageToLog);

            }
            else
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
                responseBody = actualException.StackTrace;
                this.logger.ErrorFormat("Exception Caught in Controller::  {0} {1}", actualException, requestMessageToLog);
            }

          
            var resp = new HttpResponseMessage
            {
                Content = new StringContent(responseBody),
                StatusCode = httpStatusCode,
                ReasonPhrase = actualException.Message.Replace("\r\n", string.Empty)
            };

            resp.Headers.Add("Exception-Type", actualException.GetType().FullName);
            return new HttpResponseException(resp);
        }
    }
}