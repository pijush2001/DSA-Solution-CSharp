using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Console
{
    public class Branch
    {
        private string BranchId {  get; set; }
        private string BranchName { get; set; }
        private string Location {  get; set; }
        private List<Car> CarsList { get; set; }
        private List<Car> AvailableCar {  get; set; }
        private List<Car> RentedCars { get; set; }
        public Branch() { }
        public Branch(string branchId, string branchName, string location, List<Car> carsList, List<Car> availableCar, List<Car> rentedCars)
        {
            BranchId = branchId;
            BranchName = branchName;
            Location = location;
            CarsList = carsList;
            AvailableCar = availableCar;
            RentedCars = rentedCars;
        }

        public void  CreateNewBranch(ref Company company)
        {
            Console.WriteLine("What Should be your BranchName?");
            var branchName=Console.ReadLine();
            Console.WriteLine("Where Should You Open Your Branch? K for Kolkata/M for Mumbai/ D for Delhi/ B for Bangalore");
            var location=LocationList.Location[Console.ReadLine().ToUpper()];
            Console.WriteLine("Do You have any cars for this branch? Yes/No");
            var carResponse = Console.ReadLine();

            if (carResponse.ToUpper() == "YES")
            {
                Console.WriteLine("Give us some information about your cars, so that we can register those for rental service of custome");


            }
            else
            {
                Console.WriteLine("Do you want to take cars of existing lender of this location? Yes/No");
                if (Console.ReadLine().ToUpper() == "YES")
                {


                }
                else
                {
                    Console.WriteLine("Thanks for choosing Us, let me know when you want to add car in your branch!!!");
                }
            }

            

            company.Branches.Add(newBranch);
            

        }
    }
}
