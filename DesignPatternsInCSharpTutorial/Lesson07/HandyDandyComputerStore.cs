namespace Lesson07
{
    public class HandyDandyComputerStore
    {
        private static HandyDandyComputerStore _instance = new HandyDandyComputerStore();
        public static HandyDandyComputerStore Instance
        {
            get { return _instance; }
        }
        private HandyDandyComputerStore()
        {
            
        }
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