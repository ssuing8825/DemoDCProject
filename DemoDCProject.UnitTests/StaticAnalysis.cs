using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace DemoDCProject.UnitTests
{
    [TestClass]
    public class StaticAnalysis
    {
        [TestClass]
        public class StaticAnalysisVerifications
        {
            private static Dictionary<string, TypeInfo> allTypes;
            private static Dictionary<string, TypeInfo> publicTypes;
            private static Dictionary<string, TypeInfo> unsealedTypes;

            private static string deploymentDirectory;

            [ClassInitialize]
            public static void Initialize(TestContext context)
            {
                deploymentDirectory = context.DeploymentDirectory;

                allTypes = new Dictionary<string, TypeInfo>();
                publicTypes = new Dictionary<string, TypeInfo>();
                unsealedTypes = new Dictionary<string, TypeInfo>();

                var publicSealedTypes = new Dictionary<string, TypeInfo>();
                var nonPublicSealedTypes = new Dictionary<string, TypeInfo>();
                var staticTypes = new Dictionary<string, TypeInfo>();
                var abstractTypes = new Dictionary<string, TypeInfo>();
                var publicInterfaceTypes = new Dictionary<string, TypeInfo>();

                Assembly[] assemblies = 
            {
                Assembly.LoadFrom(@"DemoDCProject.DomainLayer.dll"),
                Assembly.LoadFrom(@"DemoDCProject.ServiceProviders.dll"),
        
            };

                foreach (var assembly in assemblies)
                {
                    foreach (var type in assembly.DefinedTypes)
                    {
                        if (type.Name.Contains("<PrivateImplementationDetails>")) continue;

                        allTypes.Add(type.Name, type);

                        if (type.IsPublic)
                        {
                            publicTypes.Add(type.Name, type);
                            if (type.IsSealed)
                                publicSealedTypes.Add(type.Name, type);
                            if (type.IsInterface)
                                publicInterfaceTypes.Add(type.Name, type);
                        }

                        if (!type.IsSealed && !type.IsInterface)
                        {
                            unsealedTypes.Add(type.Name, type);
                        }

                        if (type.IsNotPublic && type.IsSealed)
                            nonPublicSealedTypes.Add(type.Name, type);

                        if (type.IsAbstract)
                        {
                            abstractTypes.Add(type.Name, type);
                            if (type.IsSealed)
                                staticTypes.Add(type.Name, type);
                        }
                    }
                }
            }

            private IEnumerable<string> GetNamesOfTypesThatShouldBeInternalButAreNot(Dictionary<string, TypeInfo> publicTypes)
            {
                // Any types in these namespaces would need to be public
                var validPublicTypeNamespaces = new HashSet<string>
            {
                "DemoDCProject.DomainLayer.DomainModel",
                "DemoDCProject.DomainLayer.Exceptions",
              //  "Ooblx.DomainLayer.DataInterchange.Enums",
              //  "Ooblx.DomainLayer.DataInterchange.Messages",
            };

                // In addition, specifically call out individual types that should be public
                var validPublicTypes = new HashSet<string>
            {
                "DemoDCProject.DomainLayer.DomainFacade",   
               // "Ooblx.DomainLayer.Enums.UpdateEpisodeStagingOutcome",
               // "Ooblx.DomainLayer.Services.IRuntimeEnvironmentIsolationService",
            };

                var publicTypesExceptions = new List<string>();

                foreach (var kvp in publicTypes)
                {
                    var type = kvp.Value;
                    if (!validPublicTypeNamespaces.Contains(type.Namespace) && !validPublicTypes.Contains(type.FullName))
                    {
                        publicTypesExceptions.Add(type.FullName);
                    }
                }

                return publicTypesExceptions;
            }

            private IEnumerable<string> GetNamesOfTypesThatShouldbeSealdButAreNot(Dictionary<string, TypeInfo> unsealedTypes)
            {
                var validUnSealedTypes = new HashSet<string>
            {
                "Ooblx.DomainLayer.Managers.Helpers.UniqueIdProviderMemberUsername",
            };

                var unsealedTypesExceptions = new List<string>();

                foreach (var kvp in unsealedTypes)
                {
                    if (kvp.Value.IsAbstract)
                        continue;

                    var descendants = allTypes.Where(t => t.Value.IsSubclassOf(kvp.Value));
                    if (!descendants.Any())
                    {
                        unsealedTypesExceptions.Add(kvp.Value.FullName);
                    }
                }

                return unsealedTypesExceptions.Except(validUnSealedTypes);
            }


            [TestMethod]
            [TestCategory("Static Analysis")]
            public void EnsureOnlyAllowedTypesArePublic()
            {
                var publicTypesExceptions = GetNamesOfTypesThatShouldBeInternalButAreNot(publicTypes);
                var typesForMessage = string.Join("\r\n", publicTypesExceptions);
                Assert.IsFalse(publicTypesExceptions.Any(), "The Following Publically Exposed Types are not in the List of \"Permitted\" Publically Exposed Types.\r\n" + typesForMessage);
            }

            [TestMethod]
            [TestCategory("Static Analysis")]
            public void EnsureClassesAreSealed()
            {
                var unsealedTypesExceptions = GetNamesOfTypesThatShouldbeSealdButAreNot(unsealedTypes);

                var message = new StringBuilder();
                foreach (var item in unsealedTypesExceptions)
                {
                    message.Append(item + "\r\n");
                }

                Assert.IsFalse(unsealedTypesExceptions.Any(), "The Following types should be sealed but are not.\r\n" + message);
            }

            [TestMethod]
            [TestCategory("Static Analysis")]
            public void EnsurePublicMethodAreNotVirtual()
            {
                var ignoreMethodNames = new HashSet<string>
            {
                "GetHashCode",
                "Equals",
                "ToString",
                "MemberUsernameExists", // This method is in the DataFacade. Not sure why it shows up as "virtual". Probably due to implementing an interface. For now - we're ignoring this intentionally
            };

                var message = new StringBuilder();

                foreach (var kvp in allTypes)
                {
                    if (kvp.Value.IsInterface || kvp.Value.IsSubclassOf(typeof(Delegate)))
                        continue;

                    var methodsInfos = kvp.Value.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    foreach (var methodInfo in methodsInfos)
                    {
                        if ((methodInfo.IsVirtual || methodInfo.IsAbstract) && !ignoreMethodNames.Contains(methodInfo.Name))
                        {
                            message.Append("The method: " + methodInfo.Name + " in the type: " + kvp.Value + "\r\n");
                        }
                    }
                }

                if (message.Length > 0)
                {
                    Assert.Fail("The Following classes have public methods that are either virtual or abstract." + message.ToString());
                }
            }
        }
    }
}
