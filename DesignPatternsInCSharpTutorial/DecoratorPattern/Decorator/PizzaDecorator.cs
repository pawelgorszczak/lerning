using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPattern.Component;

namespace DecoratorPattern.Decorator
{
    public class PizzaDecorator : Pizza
    {
        private readonly Pizza _pizza;

        public PizzaDecorator(Pizza pizza)
        {
            _pizza = pizza;
        }
        public override double CalculateCost()
        {
            return _pizza.CalculateCost();
        }

        public override string GetName()
        {
            return _pizza.GetName();
        }

    }
}
