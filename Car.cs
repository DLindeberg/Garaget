using System;

namespace Garaget
{
    public class Car : Vehicle
    {
        public string Model { get; set; }
        public bool Combi { get; set; }

        override public void Print()
        {
            base.Print();
            Console.WriteLine($"Model: {Model}\nCombi: {Combi}\n");
        }
    }
}
