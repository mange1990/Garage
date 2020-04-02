

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage1_0
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;

        public int Capacity
        {
           get { return vehicles.Length; }      

        }


        public int CountVehicle { get; private set; } = 0;

        public bool IsFull => CountVehicle >= Capacity;

        public Garage(int capacity)
        {
            if (capacity <= 0) throw new InvalidOperationException("Capacity must be more than zero");

            vehicles = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                if(item != null)
                   yield return item;
            }
        }

        public T GetVehicleAtIndex(int index)
        {
            return vehicles[index];
        }

        public string ListAllVehicle()
        {
            string allVehicles = "";

            int current = 1;
            foreach (var vehicle in this)
            {
                allVehicles += $"{current}: {vehicle}\n";
                current++;
            }
            return allVehicles;
        }

        internal void buildNewCapacity(int newCapacity)
        {
            T[] temp = vehicles;
            vehicles = new T[newCapacity];
            for (int i = 0; i < temp.Length; i++)
            {
                vehicles[i] = temp[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool AddVehicle(T vehicle)
        {
            if (IsFull) return false;

            vehicles[CountVehicle] = vehicle;
            CountVehicle++;
            return true;
        }

        public string ListVehicleTypeCount()
        {
            var results = this.GroupBy(i => i.GetType().Name).Select(i => new
            {
               Type = i.Key,
               Count = i.Count()
            });
          
            string vehiclesTypeCount = "";
            foreach(var result in results)
            {
                vehiclesTypeCount += $"Det finns {result.Count} {result.Type} i garaget just nu\n";
            }

            return vehiclesTypeCount;
        }

        public bool RemoveVehicle(T vehicle)
        {
            bool isRemoved = false;
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (! isRemoved) {
                    if (vehicles[i] == vehicle)
                    {
                        vehicles[i] = null;
                        CountVehicle--;
                        isRemoved = true;
                    }
                }
                else
                {
                    vehicles[i - 1] = vehicles[i];
                }
            }
 
            return isRemoved;
        }

        public T GetVehicleByRegNr(string regNr)
        {
            T vehicle = null;

            foreach (var item in this)
            {
                if (item.RegNr.ToUpper() == regNr.ToUpper())
                {
                    vehicle = item;
                    break;
                }
            }
            return vehicle;
        }
    }
}