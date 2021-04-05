using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }

        public int Count
        {
            get
            {
                return cars.Count;
            }
        }

        public string AddCar(Car car)
        {

            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (cars.Contains(GetCar(registrationNumber)))
            {
                cars.Remove(GetCar(registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }

            return "Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars.Where(x => x.RegistrationNumber == registrationNumber).FirstOrDefault();

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                RemoveCar(number);
            }
        }
    }
}
