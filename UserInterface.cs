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
                Helper.MenuAlternatives();
                int input = Helper.MenuInputHandler();
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
                        int input2 = Helper.MenuSearchSubMenu();
                        if (input2 == 1)
                        {
                            Vehicle vehicle = myGarage.SearchVehicleRegnr();
                            Helper.MenuSearchNullReferenceHandler(vehicle);
                        }
                        else if (input2 == 2)
                        {
                            myGarage.SearchVehicleType();
                        }
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
    }
}
