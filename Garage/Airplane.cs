using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1_0
{
   public class Airplane : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Airplane(string regNr, string color, int wheel, int weight, int numberOfSeats) : base(regNr, color, wheel, weight)
        {
            this.NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return base.ToString() + $", Max Antal passagerare: {NumberOfSeats}";
        }

    }
}
