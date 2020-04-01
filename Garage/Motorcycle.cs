using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1_0
{
    class Motorcycle : Vehicle
    {
        public int MaxSpeed { get; set; }

        public Motorcycle(string regNr, string color, int wheel, int weight, int maxSpeed) : base(regNr, color, wheel, weight)
        {
            this.MaxSpeed = maxSpeed;
        }
    }
}
