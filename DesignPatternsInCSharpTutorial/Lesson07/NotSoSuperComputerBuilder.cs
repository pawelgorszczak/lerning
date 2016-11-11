namespace Lesson07
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
