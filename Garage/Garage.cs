namespace Garage1_0
{
    public class Garage
    {
        private Vehicle[] vehicles;

        public int Capacity
        {
            get { return vehicles.Length; }         
        }


        public Garage(int capacity)
        {
            vehicles = new Vehicle[capacity];
        }



    }
}