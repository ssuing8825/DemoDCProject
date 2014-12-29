using DemoDCProject.DomainLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoDCProject.DomainLayer.ServiceLocator
{
    /// <summary>
    /// This class is reponsible for Resolving and thus providing the system-wide "ServiceLocator"
    /// class. By default this class will return the "Production" version of the ServiceLocator
    /// </summary>
    internal static class ServiceLocatorResolver
    {
        private static string serviceLocatorProductionTypeName = typeof(ServiceLocatorProduction).Name;

        /// <summary>
        /// This method Resolves and returns in instance of a <see cref="ServiceLocatorBase"/>. 
        /// <para>
        ///     <list type="bullet">
        ///         <item><description>Without any configuration, this method will return an instance of <see cref="ServiceLocatorProduction"/>. This is the default behavior.</description></item>
        ///         <item><description>Otherwise it will resolve based on the config file, appSettings key: serviceLocatorClassName. The value of this appSetting should be in the form: value="AssemblyFileName, FullNameOfClass"</description></item>
        ///     </list>
        /// </para>
        /// </summary>
        /// <returns>An instance of a <see cref="ServiceLocatorBase"/></returns>
        public static ServiceLocatorBase Resolve()
        {
            return ResolveFromConfigFile();
        }

        private static ServiceLocatorBase ResolveFromConfigFile()
        {
            var serviceLocatorClassName = GetServiceLocatorClassName();

            if (ServiceLocatorClassNameIsProductionVersion(serviceLocatorClassName))
                return new ServiceLocatorProduction();
            else
            {
                var tuple = ParseAssemblyNameAndClassName(serviceLocatorClassName);
                string serviceLocatorAssemblyName = tuple.Item1;
                serviceLocatorClassName = tuple.Item2;

                var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
                var files = Directory.EnumerateFiles(executingDirectory, serviceLocatorAssemblyName + ".*").Where(fname => Path.GetExtension(fname) == ".exe" || Path.GetExtension(fname) == ".dll").ToArray();
                if (files.Length == 0)
                    throw new ServiceLocatorConfigurationInvalidException("The Assembly specified in serviceLocatorClassName appConfig setting (" + serviceLocatorAssemblyName + ") in the configuration file cannot be found");

                var fullAssemblyName = files[0];
                var assembly = Assembly.LoadFile(fullAssemblyName);
                var serviceLocatorType = assembly.GetType(serviceLocatorClassName);
                if (serviceLocatorType == null)
                    throw new ServiceLocatorConfigurationInvalidException(string.Format("The serviceLocatorClassName's type: \"{0}\", found in configuration file's appSetting section was not found in the assembly specified", serviceLocatorClassName));

                return (ServiceLocatorBase)Activator.CreateInstance(serviceLocatorType);
            }
        }

        private static Tuple<string, string> ParseAssemblyNameAndClassName(string serviceLocatorClassNameConfigFileSetting)
        {
            var commaPos = serviceLocatorClassNameConfigFileSetting.IndexOf(',');

            if (commaPos == -1)
            {
                throw new ServiceLocatorConfigurationInvalidException("The appSetting: \"serviceLocatorClassName\" has an incorrect format. The value should be specificed in the format \"AssemblyFileName, FullNameOfClass\"");
            }

            var serviceLocatorAssemblyName = serviceLocatorClassNameConfigFileSetting.Substring(0, commaPos).Trim();
            var serviceLocatorClassName = serviceLocatorClassNameConfigFileSetting.Substring(commaPos + 1).Trim();
            return new Tuple<string, string>(serviceLocatorAssemblyName, serviceLocatorClassName);
        }

        private static string GetServiceLocatorClassName()
        {
            return ConfigurationManager.AppSettings["serviceLocatorClassName"];
        }

        private static bool ServiceLocatorClassNameIsProductionVersion(string serviceLocatorClassName)
        {
            return string.IsNullOrEmpty(serviceLocatorClassName) || serviceLocatorClassName == serviceLocatorProductionTypeName;
        }
    }
}
