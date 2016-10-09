using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson05.Core
{
    public class NotSoSuperComputerBuilder : ComputerBuilder
    {
        public override void SetCores()
        {
            _computer.AmountOfCores = 1;
        }

        public override void SetCpuFrequency()
        {
            _computer.CpuFrequency = 2.0m;
        }

        public override void SetRam()
        {
            _computer.AmountOfRam = 2;
        }

        public override void SetDriveType()
        {
            _computer.DriveType = "hdd";
        }
    }
}
