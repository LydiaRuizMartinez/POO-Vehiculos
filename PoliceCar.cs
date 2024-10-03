namespace Practice2
{
    class PoliceCar : VehicleWithPlate, IMessageWriter
    {
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private bool isPursuing;
        private string? pursuingVehiclePlate;
        private SpeedRadar? speedRadar;

        public PoliceCar(string plate, SpeedRadar? radar = null) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            isPursuing = false;
            speedRadar = radar;
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                if (speedRadar != null)
                {
                    if (vehicle is VehicleWithPlate vehicleWithPlate)
                    {
                        speedRadar.TriggerRadar(vehicleWithPlate);
                        string measurement = speedRadar.GetLastReading();
                        Console.WriteLine(WriteMessage($"Triggered radar. Result: {measurement}"));

                        if (vehicleWithPlate.GetSpeed() > 50.0f)
                        {
                            PursueVehicle(vehicleWithPlate.GetPlate());
                        }
                    }
                }
                else
                {
                    Console.WriteLine(WriteMessage("This police car has no radar installed."));
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("The police car is not patrolling."));
            }
        }

        public void PursueVehicle(string vehiclePlate)
        {
            if (!isPursuing)
            {
                isPursuing = true;
                pursuingVehiclePlate = vehiclePlate;
                Console.WriteLine(WriteMessage($"Started pursuing vehicle with plate {vehiclePlate}."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"Already pursuing vehicle with plate {pursuingVehiclePlate}."));
            }
        }

        public void StopPursuit()
        {
            if (isPursuing)
            {
                isPursuing = false;
                Console.WriteLine(WriteMessage($"Stopped pursuing vehicle with plate {pursuingVehiclePlate}."));
                pursuingVehiclePlate = null;
            }
            else
            {
                Console.WriteLine(WriteMessage("No active pursuit to stop."));
            }
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("Started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("Already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("Stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("Was not patrolling."));
            }
        }

        public new string WriteMessage(string customMessage)
        {
            return $"Police Car with plate {GetPlate()}: {customMessage}";
        }

        public void PrintRadarHistory()
        {
            if (speedRadar != null)
            {
                Console.WriteLine(WriteMessage("Radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("This police car has no radar installed."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }
    }
}
