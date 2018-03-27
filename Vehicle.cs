using System;
namespace WindowsFormsApp1
{
    public class Vehicle
    {
        public String carMake { get; set; }
        public int topSpeed { get; set; }
        public DateTime date { get; set; }
        public VehicleType type { get; set; }

        public Vehicle(String carMake, int topSpeed, DateTime date, VehicleType type)
        {
            this.carMake = carMake;
            this.topSpeed = topSpeed;
            this.date = date;
            this.type = type;
        }

        public void SetValues(String carMake, int topSpeed, DateTime date, VehicleType type)
        {
            this.carMake = carMake;
            this.topSpeed = topSpeed;
            this.date = date;
            this.type = type;
        }
    }
}
