using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson06
{
    public class Computer : ICloneable
    {
        public decimal CpuFrequency { get; set; }
        public int AmountOfCores { get; set; }
        public string DriveType { get; set; }
        public int AmountOfRam { get; set; }
        public GraphicsCard Gpu { get; set; }

        public object Clone()
        {
            var clone = (Computer) MemberwiseClone();
            clone.Gpu = (GraphicsCard) Gpu.Clone();
            return clone;
        }
    }
}
