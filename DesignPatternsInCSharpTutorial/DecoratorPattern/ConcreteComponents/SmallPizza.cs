using DecoratorPattern.Component;

namespace DecoratorPattern.ConcreteComponents
{
    public class SmallPizza : Pizza
    {
        public override double CalculateCost()
        {
            return 12.00;
        }

        public override string GetName()
        {
            return "Small Pizza";
        }
    }
}