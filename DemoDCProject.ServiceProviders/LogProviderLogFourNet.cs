using log4net;
using System;

namespace DemoDCProject.ServiceProviders
{
    internal sealed class LogProviderLogFourNet : LogProviderBase
    {
        private readonly ILog logger;

        public LogProviderLogFourNet()
        {
            this.logger = log4net.LogManager.GetLogger(this.GetType());
        }

        protected override void LogErrorCore(string message, Exception exception)
        {
            this.logger.ErrorFormat("DemoDCProjectBusinessException Caught in Controller::  {0} {1}", exception, message);
        }
    }
}
