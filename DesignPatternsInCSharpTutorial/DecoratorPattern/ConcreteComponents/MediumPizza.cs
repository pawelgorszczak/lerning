using DecoratorPattern.Component;

namespace DecoratorPattern.ConcreteComponents
{
    public class MediumPizza : Pizza
    {
        public override double CalculateCost()
        {
            return 25.00;
        }

        public override string GetName()
        {
            return "Medium Pizza";
        }
    }
}