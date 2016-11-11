using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace Lesson07.Tests
{
    
    public class SingletonTests
    {
        [Fact]
        public void IsHandyDandyComputerStoreASingleton()
        {
            Assert.Equal(HandyDandyComputerStore.Instance, HandyDandyComputerStore.Instance);
        }
    }
}
