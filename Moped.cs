using System;

namespace Garaget
{
    public class Moped : Vehicle
    {
         
        public string Model { get; set; }
        public bool Trimmed { get; set; }

        override public void Print()
        {
            base.Print();
            Console.WriteLine($"Model: {Model}\nTrimmed: {Trimmed}\n");
        }
    }
}
