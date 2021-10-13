using System;

namespace Garaget
{
    public class Vehicle
    {
        public string Regnr { get; set; }
        public string Color { get; set; }
        public int Wheels { get; set; }
        virtual public void Print()
        {
            Console.WriteLine($"Regnr: {Regnr}\nColor: {Color}\nWheels: {Wheels}");
        }
    }

}
