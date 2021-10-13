using System;

namespace Garaget
{
    public class UserInterface
    {
        Garage<Vehicle> myGarage = new Garage<Vehicle>() { Capacity = 10 };
        public void Menu() //Daniel
        {
            Console.WriteLine("Welcome to your garage!\n\nChoose an option:\n");
            bool stop = true;
            do
            {
                MenuAlternatives();
                int input = MenuInputHandler();
                switch (input)
                {
                    case 1:
                        myGarage.ListVehicle();
                            break;
                    case 2:
                        myGarage.AddVehicle();
                        break;
                    case 3:
                        myGarage.RemoveVehicle();
                        break;
                    case 4:
                        Vehicle vehicle = myGarage.SearchVehicle();
                        MenuSearchNullReferenceHandler(vehicle);
                        break;
                    case 5:
                        myGarage.ListTypeVehicle();
                        break;
                    case 6:
                        myGarage.Save();
                        break;
                    case 7:
                        myGarage.Load();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Press any key to exit...");
                        stop = false;
                        break;
                }
            } while (stop == true);
        }
        public void MenuAlternatives() //Daniel
        {
            Console.WriteLine
                    ("-----------------------------\n" +
                    "1. Show contents of garage\n" +
                    "2. Add vehicle\n" +
                    "3. Remove vehicle\n" +
                    "4. Search vehicle\n" +
                    "5. Show vehicle\n" +
                    "6. Save garage\n" +
                    "7. Load garage\n" +
                    "8. Exit program\n" +
                    "-----------------------------");
        }
        public void MenuSearchNullReferenceHandler(Vehicle vehicleObject) //Daniel
        {
            if (vehicleObject == null)
            {
                Console.Clear();
                Console.WriteLine("Vehicle not found. Make sure you use the correct format (ABC123).\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Vehicle found:\n");
                vehicleObject.Print();
            }
        }
        public int MenuInputHandler() //Daniel
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
    }
}
