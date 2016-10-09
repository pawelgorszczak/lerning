namespace Lesson03.Core
{
    public interface IFactory
    {
        IComputer CreateComputer();
        ITablet CreateTablet();
        ISmartPhone CreateSmartPhone();
    }
}