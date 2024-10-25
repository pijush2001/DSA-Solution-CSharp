using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Console
{
    public class Car
    {
        private string CarId {  get; set; }
        private string CarName { get; set; }
        private CarType CarType { get; set; }
        private int NumberOfSeat {  get; set; } 
        private decimal PricePerHour {  get; set; }

        public void RegisterNewCar(ref Company<string,Branch>)
        {
            var car = new Car();
            Console.WriteLine("What is your car name?");
            car.CarName=Console.ReadLine();
            Console.WriteLine("What type of Car is it? \n press 0 for Sedan,1 for SUV or 2 for Hatchback");
            car.CarType=CarType.Sedan;
            
            Console.WriteLine("How many seats in the car?");
            car.NumberOfSeat=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the base price per hour");
            car.PricePerHour=Convert.ToDecimal(Console.ReadLine()); 

            


        }

    }
}
public enum CarType
{
    
    Sedan,
    SUV,
    Hatchback

}
