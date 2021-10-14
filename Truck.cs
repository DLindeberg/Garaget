using System;

namespace Garaget
{
    public class Truck : Vehicle
    {
        public string Model { get; set; }
        public bool Trailer { get; set; }

        override public void Print()
        {
            base.Print();
            Console.WriteLine($"Model: {Model}\nTrailer: {Trailer}\n");
        }
    }
}
