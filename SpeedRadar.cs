namespace Practice2
{
    class SpeedRadar : IMessageWriter
    {
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        public List<float> SpeedHistory { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            SpeedHistory = new List<float>();
        }

        public void TriggerRadar(Vehicle vehicle)
        {
            if (vehicle is VehicleWithPlate vehicleWithPlate)
            {
                plate = vehicleWithPlate.GetPlate();
                speed = vehicle.GetSpeed();
                SpeedHistory.Add(speed);
            }
        }

        public string GetLastReading()
        {
            if (speed > legalSpeed)
            {
                return WriteMessage("Caught speeding.");
            }
            else
            {
                return WriteMessage("Driving legally.");
            }
        }

        public string WriteMessage(string customMessage)
        {
            return $"Vehicle with plate {plate} at {speed} km/h. {customMessage}";
        }
    }
}
