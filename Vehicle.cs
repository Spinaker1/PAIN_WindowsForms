using System;
namespace Cars
{
    public class Vehicle
    {
        public String carMake { get; set; }
        public int topSpeed { get; set; }
        public String date { get; set; }
        public VehicleType type { get; set; }

        public Vehicle(String carMake, int topSpeed, String date, VehicleType type)
        {
            this.carMake = carMake;
            this.topSpeed = topSpeed;
            this.date = date;
            this.type = type;
        }
    }
}
