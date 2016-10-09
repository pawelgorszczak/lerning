using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson03.Core;

namespace Lesson03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client (a or b): ");
            var client = Console.ReadLine();

            IFactory factory;
            if(client == "a")
                factory = new ClientAFactory();
            else if(client == "b")
                factory = new ClientBFactory();
            else
                return;
            var order = new Order();

            Console.WriteLine("How many computers");
            order.Computers = ConertToInt32(Console.ReadLine());

            Console.WriteLine("How many tablets");
            order.Tablets = ConertToInt32(Console.ReadLine());

            Console.WriteLine("How many smartphones");
            order.SmartPhones = ConertToInt32(Console.ReadLine());

            var company = new HandyDandyManufacturingCompany(factory);
            company.Produce(order);

            Console.WriteLine("Created " + company.Computers.Count() + " computers.");
            Console.WriteLine("Created " + company.Tablets.Count() + " tablets.");
            Console.WriteLine("Created " + company.SmartPhones.Count() + " phones.");

            Console.ReadLine();
        }

        private static int ConertToInt32(string intput)
        {
            if (string.IsNullOrWhiteSpace(intput))
                return 0;
            return Int32.Parse(intput);
        }
    }
}
