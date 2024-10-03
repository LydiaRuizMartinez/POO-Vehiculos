namespace Practice2
{
    class PoliceStation
    {
        private List<PoliceCar> policeCars;
        private bool alertActive;

        public PoliceStation()
        {
            policeCars = new List<PoliceCar>();
            alertActive = false;
        }

        public void RegisterPoliceCar(PoliceCar policeCar)
        {
            if (policeCar != null && !policeCars.Contains(policeCar))
            {
                policeCars.Add(policeCar);
                Console.WriteLine($"Police Car with plate {policeCar.GetPlate()}: Created.");
            }
            else
            {
                Console.WriteLine("Invalid police car or already registered.");
            }
        }

        public void TriggerAlert(Vehicle offender)
        {
            if (!alertActive)
            {
                alertActive = true;

                if (offender is VehicleWithPlate offenderWithPlate)
                {
                    string offenderPlate = offenderWithPlate.GetPlate();
                    Console.WriteLine($"Alert triggered for vehicle {offenderPlate}. Notifying all police cars...");
                    NotifyPoliceCars(offenderPlate);
                }
            }
            else
            {
                Console.WriteLine("Alert is already active.");
            }
        }

        private void NotifyPoliceCars(string offenderPlate)
        {
            foreach (PoliceCar policeCar in policeCars)
            {
                if (policeCar.IsPatrolling())
                {
                    Console.WriteLine($"Notifying police car with plate {policeCar.GetPlate()} to pursue vehicle with plate {offenderPlate}.");
                    policeCar.PursueVehicle(offenderPlate);
                }
            }
        }

        public void DeactivateAlert()
        {
            if (alertActive)
            {
                alertActive = false;
                Console.WriteLine("Alert deactivated.");
            }
            else
            {
                Console.WriteLine("No active alert to deactivate.");
            }
        }

        public void PrintRegisteredPoliceCars()
        {
            Console.WriteLine("Registered Police Cars:");
            foreach (PoliceCar policeCar in policeCars)
            {
                Console.WriteLine(policeCar.GetPlate());
            }
        }
    }
}
