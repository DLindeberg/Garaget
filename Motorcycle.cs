﻿using System;

namespace Garaget
{
    public class Motorcycle : Vehicle 
    {
        public string Model { get; set; }
        public string ExhaustBrand { get; set; }

        override public void Print()
        {
            base.Print();
            Console.WriteLine($"Model: {Model}\nExhaust brand: {ExhaustBrand}\n");
        }
    }
}
