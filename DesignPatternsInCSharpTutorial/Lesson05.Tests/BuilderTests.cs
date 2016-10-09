using System;
using Lesson05.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lesson05.Tests
{
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void SuperComputer()
        {
            var computer = new Computer
            {
                AmountOfCores = 64,
                AmountOfRam = 256,
                CpuFrequency = 3.4m,
                DriveType = "sdd"
            };

            var store = new HandyDandyComputerStore();
            var builder = new SuperComputerBuilder();

            builder.SetCores();
            builder.SetCpuFrequency();
            builder.SetRam();
            builder.SetDriveType();

            var superComputer = store.Build(builder);
            
            Assert.AreEqual(computer.AmountOfRam, superComputer.AmountOfRam);
            Assert.AreEqual(computer.AmountOfCores, superComputer.AmountOfCores);
            Assert.AreEqual(computer.CpuFrequency, superComputer.CpuFrequency);
            Assert.AreEqual(computer.DriveType, superComputer.DriveType);
        }
        [TestMethod]
        public void NoSoSuperComputer()
        {
            var computer = new Computer
            {
                AmountOfCores = 1,
                AmountOfRam = 2,
                CpuFrequency = 2.0m,
                DriveType = "hdd"
            };

            var store = new HandyDandyComputerStore();
            var builder = new NotSoSuperComputerBuilder();

            builder.SetCores();
            builder.SetCpuFrequency();
            builder.SetRam();
            builder.SetDriveType();

            var superComputer = store.Build(builder);

            Assert.AreEqual(computer.AmountOfRam, superComputer.AmountOfRam);
            Assert.AreEqual(computer.AmountOfCores, superComputer.AmountOfCores);
            Assert.AreEqual(computer.CpuFrequency, superComputer.CpuFrequency);
            Assert.AreEqual(computer.DriveType, superComputer.DriveType);
        }

    }
}
