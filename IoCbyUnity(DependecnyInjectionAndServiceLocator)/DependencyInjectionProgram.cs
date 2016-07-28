using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCbyUnity_DependecnyInjectionAndServiceLocator_.Loger;
using Microsoft.Practices.Unity;

namespace IoCbyUnity_DependecnyInjectionAndServiceLocator_
{
    public class Writer
    {
        private ILogger _loger;

        /// <summary>
        /// Inicjuje nowe wystąpienie klasy <see cref="Writer"/>
        /// </summary>
        /// <param name="logger">Rejestrator</param>
        [InjectionConstructor]
        public Writer(ILogger logger)
        {
            _loger = logger;
        }

        public void Write(string text)
        {
            Console.WriteLine(text + " - adding to log");
            _loger.WriteLog();
        }
    }
    class DependencyInjectionProgram
    {
        static void Main(string[] args)
        {
            //Dependency Injection z Unity
            //Przygotowanie pojemnika
            var container = new UnityContainer();
            //Określamy, że używanym rejestratorem ma być FileLogger
            container.RegisterType<ILogger, FileLogger>();
            //i jak zainicjować nowy obiekt Writer
            container.RegisterType<Writer>();
            //Tutaj unity wie jak utworzyć nowego kontruktora
            var writerDI = container.Resolve<Writer>();
            writerDI.Write("data x, unity DI help");

            var serviceLocator = new ServiceLocatorProgram();

            
            Console.ReadKey();
        }
    }
}
