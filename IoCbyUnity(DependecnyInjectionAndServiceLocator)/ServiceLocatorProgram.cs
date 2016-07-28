using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCbyUnity_DependecnyInjectionAndServiceLocator_.Loger;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace IoCbyUnity_DependecnyInjectionAndServiceLocator_
{
    /// <summary>
    /// Narzedzie do konigurowania pojemnika
    /// </summary>
    public sealed class UnityContainerConfigurator
    {
        /// <summary>
        /// Konfiguruje wystąpienie
        /// </summary>    
        public static IUnityContainer Configure()
        {
            var container = new UnityContainer()
                .RegisterType<ILogger, DataBaseLogger>()
                .RegisterType<Writer>();
            return container;
        }
    }

    public class ServiceLocatorProgram
    {
        public ServiceLocatorProgram()
        {
            //tworzenie nowego wystąpienia pojemnika Microsoft Unity
            var provider = new UnityServiceLocator(UnityContainerConfigurator.Configure());
            //przypisanie pojemnika do dostawcy lokalizatora usług
            ServiceLocator.SetLocatorProvider(() => provider);
            //ustalenie obiektów przy pomocy lokalizatora usług
            var writer = ServiceLocator.Current.GetInstance<Writer>();
            writer.Write("data x2, Service Locator");
        }
    }
}