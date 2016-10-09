using System;
using System.Runtime.InteropServices;

namespace Lesson03.Core
{
    public class ClientAFactory : IFactory
    {
        public IComputer CreateComputer()
        {
            return new ClientAComputer();
        }

        public ISmartPhone CreateSmartPhone()
        {
            return new ClientASmartPhone();
        }

        public ITablet CreateTablet()
        {
            return new ClientATablet();
        }
    }
}