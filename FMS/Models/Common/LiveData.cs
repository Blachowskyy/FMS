namespace FMS.Models.Common
{
    public class LiveData
    {
        public string? PositionX { get; set; }
        public string? PositionY { get; set; }
        public string? PositionR { get; set; }
        public string? BatteryVoltage { get; set; }
        public string? BatteryPercentage { get; set; }
        public string? ActualForksHeight { get; set; }
        public string? WeightOnForks {  get; set; }
        public string? CargoWeight { get; set; }
        public string? TiltAxis1 { get; set; }
        public string? TiltAxis2 { get; set; }
        public string? OverallDistanceMilimeters { get; set; }
        public string? OverallDistanceMeters { get; set; }
        public string? OverallDistanceKilometers { get; set; }
        public string? ServoAngle { get; set; }
        public string? Pwm {  get; set; }
        public string? Speed { get; set; }
        public bool BatteryCritical { get; set; }
        public bool ForksHeightLimiter { get; set; }
        public LiveData()
        {
            PositionX = "";
            PositionR = "";
            PositionY = "";
            BatteryVoltage = "";
            BatteryPercentage = "";
            ActualForksHeight = "";
            WeightOnForks = "";
            CargoWeight = "";
            TiltAxis1 = "";
            TiltAxis2 = "";
            OverallDistanceMilimeters = "";
            OverallDistanceMeters = "";
            OverallDistanceKilometers = "";
            ServoAngle = "";
            Pwm = "";
            Speed = "";
        }

    }
}
