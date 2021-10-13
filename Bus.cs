using System;

namespace Garaget
{
    public class Bus : Vehicle 
    {
        public string Model { get; set; }
        public int Length { get; set; }

        override public void Print()
        {
            base.Print();
            Console.WriteLine($"Type: {Type}\nModel: {Model}\nPassengers: {Passengers}\n");
        }
    }
}
