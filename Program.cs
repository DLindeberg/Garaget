using Newtonsoft.Json;
using System;

namespace Garaget
{
    class Program
    {
        static UserInterface _userInterface = new UserInterface();
        static void Main(string[] args)
        {
            _userInterface.Menu();
            Console.ReadLine();
        }
    }
}
