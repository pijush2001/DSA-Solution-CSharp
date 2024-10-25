using Car_Rental_Console;

internal class Program
{
    private static void Main(string[] args)
    {
        var registeredCompany=new Dictionary<string,Company>();

        do
        {


            Console.WriteLine("Do you want to Open a Car Rental Store? Yes/No");
            var response = Console.ReadLine();
            switch (response)
            {
                
                case "Yes":
                    Company company = new Company();
                    company.CreateMyNewCompany(ref registeredCompany);

                    break;
                case "No":
                    break;
                default:
                    break;


            }
        } while (true);
       
    }
}