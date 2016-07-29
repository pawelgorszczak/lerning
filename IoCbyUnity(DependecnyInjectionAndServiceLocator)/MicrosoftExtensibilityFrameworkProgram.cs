using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IoCbyUnity_DependecnyInjectionAndServiceLocator_.Loger;

namespace IoCbyUnity_DependecnyInjectionAndServiceLocator_
{
    /// <summary>
    /// Rejestrator
    /// </summary>
    [Export(typeof(ILogger))]
    public class MefLogger : ILogger
    {
        /// <summary>
        /// Zapisanie logu
        /// </summary>
        public void WriteLog()
        {
            Console.WriteLine("Log Writed by MEF");
        }
    }
    public class MicrosoftExtensibilityFrameworkProgram
    {
        /// <summary>
        /// Pobiera lub ustawia obiekt zapisujący
        /// </summary>
        [Import]
        public ILogger Writer { get; set; }

        public void Run()
        {
            //najpierw budujemy katalog
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            //tworzenie pojemnika wykorzystującego katalog
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            //uzycie uzyskanej wlasciwosci
            Writer.WriteLog();
        }
    }
}
