namespace Garage1_0
{
    public class Boat : Vehicle
    {
        public string FuelType { get; set; }

        public Boat(string regNr, string color, int weight, string fuelType) : base (regNr, color, 0, weight)
        {
            this.FuelType = fuelType;

        }
    }
}