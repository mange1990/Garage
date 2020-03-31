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
            this.capacity = capacity;
            vehicles = new Vehicle[capacity];
        }



    }
}