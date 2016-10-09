using System;

namespace Lesson05.Core
{
    public abstract class ComputerBuilder
    {
        protected readonly  Computer _computer = new Computer();
        public abstract void SetCores();
        public abstract void SetCpuFrequency();
        public abstract void SetRam();
        public abstract void SetDriveType();

        public virtual Computer GetComuter()
        {
            return _computer;
        }
    }
}