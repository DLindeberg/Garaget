using System;

namespace Garaget
{

    static class Helper
    {
        //Riley
        public static int IntValidator()
        {
            string data = Console.ReadLine();
            int input;
            while (!int.TryParse(data, out input))
            {
                Console.WriteLine("Sorry, that's not a valid input, please try agian..");
                data = Console.ReadLine();
            }

            return input;
        }

        //Riley
        public static bool BoolValidator()
        {
            string input = Console.ReadLine();
            while (true)
            {
                if (input.ToLower() == "yes" || input == "1")
                    return true;
                else if (input.ToLower() == "no" || input == "0")
                    return false;
                else
                {
                    Console.WriteLine("Sorry, it's either a yes or a no, or a 1 or a 0.");
                    input = Console.ReadLine();
                }
            }
        }
        public static int MenuInputHandler() //Daniel
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 8)
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please try again...\n");
                MenuAlternatives();
                
            }
            return input;
        }
        public static void MenuSearchNullReferenceHandler(Vehicle vehicleObject) //Daniel
        {
            if (vehicleObject == null)
            {
                Console.Clear();
                Console.WriteLine("Vehicle not found.\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Vehicle found:\n");
                vehicleObject.Print();
            }
        }
        public static void MenuAlternatives() //Daniel
        {
            Console.WriteLine
                    ("-----------------------------\n" +
                    "1. Show contents of garage\n" +
                    "2. Add vehicle\n" +
                    "3. Remove vehicle\n" +
                    "4. Search vehicle\n" +
                    "5. Show vehicles\n" +
                    "6. Save garage\n" +
                    "7. Load garage\n" +
                    "8. Exit program\n" +
                    "-----------------------------");
        }
        public static void AddVehicleAlternatives()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Bus");
            Console.WriteLine("3. Moped");
            Console.WriteLine("4. Motorcycle");
            Console.WriteLine("5. Truck");
            Console.WriteLine("----------------");
        }
    }
}