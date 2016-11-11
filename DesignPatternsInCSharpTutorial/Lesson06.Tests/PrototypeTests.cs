using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lesson06.Tests
{
    [TestClass]
    public class PrototypeTests
    {
        [TestMethod]
        public void MemberwiseCloneTest()
        {
            var gpu = new GraphicsCard()
            {
                AmountOfRam = 2,
                GpuFrequency = 1.1m

            };

            var computer = new Computer()
            {
                AmountOfCores = 2,
                AmountOfRam = 22,
                CpuFrequency = 22m,
                DriveType = "ssd",
                Gpu = gpu
            };
            var computer2 = (Computer)computer.Clone();

            Assert.AreNotSame(computer.AmountOfRam, computer2.AmountOfRam);
            Assert.AreNotSame(computer.AmountOfCores, computer2.AmountOfCores);
            Assert.AreNotSame(computer.CpuFrequency, computer2.CpuFrequency);
            Assert.AreSame(computer.DriveType, computer2.DriveType);
            
            Assert.AreEqual(computer.Gpu.AmountOfRam,computer2.Gpu.AmountOfRam);
            Assert.AreEqual(computer.Gpu.GpuFrequency,computer2.Gpu.GpuFrequency);

            computer.Gpu.AmountOfRam = 8;

            Assert.AreNotEqual(computer.Gpu.AmountOfRam, computer2.Gpu.AmountOfRam);
        }
    }
}
