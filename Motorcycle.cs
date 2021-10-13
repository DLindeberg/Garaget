using System;

namespace Garaget
{
    public class Motorcycle : Vehicle 
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public int Passengers { get; set; }
        override public void Print()
        {
            base.Print();
            Console.WriteLine($"Type: {Type}\nModel: {Model}\nPassengers: {Passengers}\n");
        }
    }
}
