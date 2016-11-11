using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson06
{
    public class GraphicsCard : ICloneable
    {
        public decimal GpuFrequency { get; set; }
        public int AmountOfRam { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
