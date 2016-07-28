using System;

namespace IoCbyUnity_DependecnyInjectionAndServiceLocator_.Loger
{
    public class FileLogger : ILogger
    {
        public void WriteLog()
        {
            Console.WriteLine("I am writing log to a File");
        }
    }
}
