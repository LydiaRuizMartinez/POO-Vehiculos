namespace Practice2
{
    class City
    {
        private PoliceStation policeStation;
        private List<string> taxiLicenses;   

        public City()
        {
            policeStation = new PoliceStation();
            taxiLicenses = new List<string>();
        }

        public void RegisterTaxi(string license)
        {
            if (!taxiLicenses.Contains(license))
            {
                taxiLicenses.Add(license);
                Console.WriteLine($"Taxi with plate {license}: Created.");
            }
            else
            {
                Console.WriteLine($"Taxi license {license} is already registered.");
            }
        }

        public void RemoveTaxiLicense(string license)
        {
            if (taxiLicenses.Contains(license))
            {
                taxiLicenses.Remove(license);
                Console.WriteLine($"Taxi license {license} removed.");
            }
            else
            {
                Console.WriteLine($"Taxi license {license} not found.");
            }
        }

        public void RegisterPoliceCar(PoliceCar policeCar)
        {
            policeStation.RegisterPoliceCar(policeCar);
        }

        public void TriggerPoliceAlert(Vehicle offender)
        {
            policeStation.TriggerAlert(offender);
        }

        public void PrintTaxiLicenses()
        {
            Console.WriteLine("Registered Taxi Licenses:");
            foreach (string license in taxiLicenses)
            {
                Console.WriteLine(license);
            }
        }
    }
}
