using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przykład_Płynnego_Interfejsu
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
    }
    public interface IFluentEmployee
    {
        IFluentEmployee FirstName(string firstName);
        IFluentEmployee LastName(string lastName);
        IFluentEmployee Company(string company);
        IFluentEmployee Age(int age);
        Employee Create();
    }

    public class FluentEmployee : IFluentEmployee
    {
        private static Employee _employee;

        private static IFluentEmployee _fluent;

        public FluentEmployee()
        {
            _fluent = new FluentEmployee();
        }

        public static IFluentEmployee Init()
        {
            _employee = new Employee();
            return _fluent;
        }
        public IFluentEmployee FirstName(string firstName)
        {
            _employee.FirstName = firstName;
            return _fluent;
        }
        public IFluentEmployee LastName(string lastName)
        {
            _employee.LastName = lastName;
            return _fluent;
        }
        public IFluentEmployee Company(string company)
        {
            _employee.Company = company;
            return _fluent;
        }
        public IFluentEmployee Age(int age)
        {
            _employee.Age = age;
            return _fluent;
        }
        public Employee Create()
        {
            return _employee;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var newFluentEmployee1 = FluentEmployee
                .Init()
                .FirstName("Fluent")
                .LastName("Employee1")
                .Company("Microsoft")
                .Age(3)
                .Create();
            var newFluentEmployee2 = FluentEmployee
                .Init()
                .FirstName("Fluent2")
                .LastName("Employee2")
                .Company("Microsoft")
                .Age(3)
                .Create();
            Console.WriteLine("New Fluent Employee has been created his Name is:");
            Console.WriteLine(newFluentEmployee1.FirstName);
            Console.ReadKey();
        }
    }
}
