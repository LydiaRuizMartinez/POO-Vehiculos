namespace Practice2
{
    abstract class VehicleWithPlate : Vehicle
    {
        private string plate;

        public VehicleWithPlate(string typeOfVehicle, string plate) : base(typeOfVehicle)
        {
            this.plate = plate;
        }

        public virtual string GetPlate()
        {
            return plate;
        }

        public void SetPlate(string plate)
        {
            this.plate = plate;
        }
    }
}
