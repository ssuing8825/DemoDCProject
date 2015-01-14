using System;

namespace DemoDCProject.ServiceProviders
{
    internal abstract class LogProviderBase
    {
        public void LogError(string message, Exception exception)
        {
            LogErrorCore(message, exception);
        }

        protected abstract void LogErrorCore(string message, Exception exception);

    }
}
