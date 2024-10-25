using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Console
{
    public class Company
    {
        private String CompanyName {  get; set; }
        private String OwnerName {  get; set; }
        private String OwnerId {  get; set; }
        public List<Branch> Branches { get; set; }
        private  Company(string _companyName, string _ownerName, string _ownerId)
        {
            CompanyName = _companyName;
            OwnerName = _ownerName;
            OwnerId = _ownerId;
        }
        public Company() { }
        public void CreateMyNewCompany(ref Dictionary<string, Company> registeredCompany)
        {
            Console.WriteLine("What is your company name?");
            var companyName=Console.ReadLine();
            Console.WriteLine("what is your name?");
            var ownerName=Console.ReadLine();
            var ownerId = $"{ownerName}{companyName}";
            var newCompany=new Company(companyName, ownerName, ownerId);
            registeredCompany.Add(newCompany.OwnerId, newCompany);
            Console.WriteLine("Your company is registered succesfully!!!!");
            Console.WriteLine("Would you like to create a branch for your company?Yes/No");
            var response=Console.ReadLine();
            if (response == "Yes")
            {

            }

        }
    }
}
