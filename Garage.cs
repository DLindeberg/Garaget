using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        }

        public void ListVehicle() //Daniel
        {
            if (VehicleList == null)
            {
                Console.Clear();
                Console.WriteLine("Garage is empty.\n");
            }
            else if (VehicleList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Garage is empty.\n");
            }
            else
            {
                Console.Clear();
                foreach (var v in VehicleList)
                {
                    v.Print();
                }
            }
        }

        public void ListTypeVehicle() //Riley
        {
            Console.Clear();
            foreach (var v in VehicleList)
            {
                Console.WriteLine(v.Type);
            }
        }

        public void AddVehicle() //Riley
        {

            if (VehicleList.Count < 10)
            {
                Console.Clear();
                Console.WriteLine("Please choose one of the following: \n");
                Console.WriteLine("----------------");
                Console.WriteLine("1. Car");
                Console.WriteLine("2. Bus");
                Console.WriteLine("3. Moped");
                Console.WriteLine("4. Motorcycle");
                Console.WriteLine("5. Truck");
                Console.WriteLine("----------------");

                int input;
                while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 5)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try again...\n");
                }

                Vehicle v = null;

                Console.WriteLine("Color: ");
                string color = Console.ReadLine();

                Console.WriteLine("RegNr: ");
                string regnr = Console.ReadLine().ToUpper();
                while (VehicleList.Any(x => x.Regnr == regnr))
                {
                    Console.WriteLine("Sorry, that vehicle is already registered. Please try a different RegNr");
                    Console.Write("RegNr: ");
                    regnr = Console.ReadLine().ToUpper();
                }

                Console.WriteLine("Model: ");
                string model = Console.ReadLine();

                Console.WriteLine("Passengers: ");
                int passengers = Helper.IntValidator();


                switch (input)
                {
                    case 1:
                        Console.WriteLine("Is this a combi?");
                        var isCombi = Helper.BoolValidator();
                        v = new Car
                        {
                            Passengers = passengers,
                            Color = color,
                            Model = model,
                            Regnr = regnr,
                            Type = "Car",
                            Wheels = 4,
                            Combi = isCombi,
                        };
                        break;

                    case 2:
                        Console.WriteLine("Length (m): ");
                        int length = Helper.IntValidator();
                        v = new Bus
                        {
                            Color = color,
                            Regnr = regnr,
                            Model = model,
                            Passengers = passengers,
                            Length = length,
                            Type = "Bus",
                            Wheels = 10
                        };
                        break;

                    case 3:
                        Console.WriteLine("Is the moped trimmed?");
                        var isTrimmed = Helper.BoolValidator();
                        v = new Moped
                        {
                            Color = color,

                            Regnr = regnr,
                            Model = model,
                            Passengers = passengers,
                            Trimmed = isTrimmed,
                            Type = "Moped",
                            Wheels = 2
                        };
                        break;

                    case 4:
                        Console.WriteLine("Exhaust brand: ");
                        string exhaustbrand = Console.ReadLine();
                        v = new Motorcycle
                        {
                            Color = color,
                            Regnr = regnr,
                            Model = model,
                            Passengers = passengers,
                            ExhaustBrand = exhaustbrand,
                            Type = "Motorcycle",
                            Wheels = 2
                        };
                        break;

                    case 5:
                        Console.WriteLine("Does this truck have a trailer?");
                        var hasTrailer = Helper.BoolValidator();
                        v = new Truck
                        {
                            Color = color,
                            Regnr = regnr,
                            Model = model,
                            Passengers = passengers,
                            Trailer = hasTrailer,
                            Wheels = 10,
                            Type = "Truck"
                        };
                        break;

                    default:
                        Console.WriteLine("wat?");
                        break;
                }
                Console.Clear();
                Console.WriteLine("Vehicle successfully added!\n");
                VehicleList.Add(v);
            }
            else
            {
                Console.WriteLine("Sorry, the garage is full.\n");
            }
        }

        public void RemoveVehicle() //Riley
        {
            if (VehicleList.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Please enter a RegNr: ");
                string regnr = Console.ReadLine().ToUpper();
                while (!VehicleList.Any(x => x.Regnr == regnr))
                {
                    Console.WriteLine("Sorry, we don't have that vehicle registered, would you like to try again? (Y/N)");
                    var option = Console.ReadLine().ToUpper();
                    if (option == "Y")
                    {
                        Console.Write("Please enter a RegNr: ");
                        regnr = Console.ReadLine().ToUpper();
                    }
                    else if (option == "N")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please answer with Y or N.");
                    }
                    
                }
                Console.Clear();
                VehicleList.Remove(VehicleList.Where(x => x.Regnr == regnr).First());
                Console.WriteLine("Vehicle succesfully removed!\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There are no vehicles stored in the garage.\n");
            }
            
        }

        public Vehicle SearchVehicle() //Daniel
        {
            Console.Clear();
            Console.WriteLine("Please enter a registration number: \n");

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
