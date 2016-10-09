using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03.Core
{
    public class HandyDandyManufacturingCompany
    {
        private readonly IFactory _factory;
        private readonly List<IComputer> _computers;
        private readonly List<ITablet> _tablets;
        private readonly List<ISmartPhone> _smartPhones;

        public IEnumerable<IComputer> Computers { get { return _computers.ToArray(); } }
        public IEnumerable<ITablet> Tablets { get { return _tablets.ToArray(); } }
        public IEnumerable<ISmartPhone> SmartPhones { get { return _smartPhones.ToArray(); } }


        public HandyDandyManufacturingCompany(IFactory factory)
        {
            _factory = factory;
            _computers = new List<IComputer>();
            _tablets = new List<ITablet>();
            _smartPhones = new List<ISmartPhone>();
        }

        public void Produce(Order order)
        {
            CreateComputers(order.Computers);
            CreateSmartphones(order.SmartPhones);
            CreateTablets(order.Tablets);
        }

        private void CreateComputers(int count)
        {
            while (_computers.Count < count)
            {
                _computers.Add(_factory.CreateComputer());
            }
        }
        private void CreateSmartphones(int count)
        {
            while (_smartPhones.Count < count)
            {
                _smartPhones.Add(_factory.CreateSmartPhone());
            }
        }
        private void CreateTablets(int count)
        {
            while (_tablets.Count < count)
            {
                _tablets.Add(_factory.CreateTablet());
            }
        }
    }
}
