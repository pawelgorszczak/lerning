namespace Lesson05.Core
{
    public class HandyDandyComputerStore
    {
        public Computer Build(ComputerBuilder builder)
        {
            builder.SetCores();
            builder.SetCpuFrequency();
            builder.SetDriveType();
            builder.SetRam();
            return builder.GetComuter();
        }
    }
}