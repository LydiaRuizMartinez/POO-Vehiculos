namespace Practice2
{
    class Scooter : Vehicle
    {
        private const string typeOfVehicle = "Scooter";

        public Scooter() : base(typeOfVehicle)
        {
        }

        public string GetPlate()
        {
            return "No Plate";
        }
    }
}
