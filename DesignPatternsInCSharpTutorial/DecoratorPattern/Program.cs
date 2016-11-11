using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPattern.Component;
using DecoratorPattern.ConcreteComponents;
using DecoratorPattern.ConcreteDecorator;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza largePizza = new LargePizza();
            largePizza = new CheeseDecorator(largePizza);
            largePizza = new HamDecorator(largePizza);
            Console.WriteLine("{0:C2}",largePizza.CalculateCost());
            Console.WriteLine(largePizza.GetName());
            Console.ReadKey();
        }
    }
}
