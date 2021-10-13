using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Garaget
{
    public class Garage<T> : IEnumerable where T : Vehicle
    {
        public List<Vehicle> VehicleList;
        public int Capacity { get; set; }
        public Garage()
        {
            VehicleList = new List<Vehicle>();

            //Moped v1 = new Moped
            //{
            //    Color = "Red",
            //    Regnr = "ABC123",
            //    Wheels = 4,
            //    Type = "Moped",
            //    Model = "Yahama Aerox",
            //    Passengers = 2
            //};
            //Truck v2 = new Truck
            //{
            //    Color = "Blue",
            //    Regnr = "CBA321",
            //    Wheels = 6,
            //    Type = "Truck",
            //    Model = "Volvo",
            //    Passengers = 3
            //};
            //vehicleList.Add(v1);
            //vehicleList.Add(v2);
        }
        public void ListVehicle() //Daniel
        {
            Console.Clear();
            foreach (var v in VehicleList)
            {
                    v.Print();
            }
        }
        public void ListTypeVehicle() //Riley
        {

        }
        public void AddVehicle() //Riley
        {

        }
        public void RemoveVehicle() //Riley
        {

        }
        public Vehicle SearchVehicle() //Riley
        {
            Console.Clear();
            Console.WriteLine("Please enter a registration number: (Format: ABC123 or ABC12A)\n");

            string userInput = Console.ReadLine().ToUpper();
            foreach (var reg in VehicleList)
            {
                if (reg.Regnr == userInput)
                {
                    return reg;
                }
            }
            return null;
        }
        public void Save() //Daniel
        {
            // Serializes the objects in the vehicleList variable and saves it as a .json file.
            // The 'TypeNameHandling.All' ensures that all derived classes of 'Vehicle' can be loaded

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };
            var jsonSave = JsonConvert.SerializeObject(VehicleList, settings);
            File.WriteAllText("vehicles.json", jsonSave);
            Console.Clear();
            Console.WriteLine("Garage saved.\n");
        }
        public void Load() //Daniel
        {
            // Loads the vehicles.json file, deserializes it and stores the objects in the vehicleList variable

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            try
            {
                var jsonLoad = File.ReadAllText("vehicles.json");
                VehicleList = JsonConvert.DeserializeObject<List<Vehicle>>(jsonLoad, settings);
                Console.Clear();
                Console.WriteLine("Garage loaded.\n");
            }
            catch (FileNotFoundException)
            {
                Console.Clear();
                Console.WriteLine("Could not find savefile. Try saving first.\n");
            }
        }
        public IEnumerator GetEnumerator()
        {
            return VehicleList.GetEnumerator();
        }
    }
}
