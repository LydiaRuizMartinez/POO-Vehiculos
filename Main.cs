namespace Practice2
{
    internal class Program
    {
        static void Main()
        {
            City city = new City();
            Console.WriteLine("City created.");

            Console.WriteLine("Police station created.");

            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            city.RegisterTaxi(taxi1.GetPlate());
            city.RegisterTaxi(taxi2.GetPlate());

            PoliceCar policeCar1 = new PoliceCar("0001 CNP", new SpeedRadar());
            PoliceCar policeCar2 = new PoliceCar("0002 CNP");
            city.RegisterPoliceCar(policeCar1);
            city.RegisterPoliceCar(policeCar2);

            Console.WriteLine(policeCar1.WriteMessage("Registered in the city (with radar)."));
            Console.WriteLine(policeCar2.WriteMessage("Registered in the city (without radar)."));

            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi1);

            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);

            city.TriggerPoliceAlert(taxi1);

            policeCar2.PursueVehicle(taxi1.GetPlate());

            city.RemoveTaxiLicense(taxi1.GetPlate());
            Console.WriteLine($"Taxi with plate {taxi1.GetPlate()} has had its license removed for speeding.");

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();
            Console.ReadKey();
        }
    }
}