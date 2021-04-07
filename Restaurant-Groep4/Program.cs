using System;
using System.Text.Json;
using System.IO;


namespace RestaurantApp
{
    class Program
    {
        class Information
        {
            public string CompanyName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string openinghours { get; set; }
            public string Location { get; set; }
            public string AboutUs { get; set; }
            public string CustomerService { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("contact page");
            Console.WriteLine();
            Console.WriteLine("___________________________________");
            Console.WriteLine("");

            var obj = new Information
            {
                CompanyName = "**Restaurant**",
                Email = "contact@Restaurant.nl",
                PhoneNumber = "0031657484333",
                openinghours = "11:00_00:00",
                Location = "Aalscholverlaan\n 3232RR Rotterdam",
                AboutUs = ".......",
                CustomerService = "xxxxxxxx"
            };
            var JsonString = System.Text.Json.JsonSerializer.Serialize(obj, new JsonSerializerOptions { });
            Console.WriteLine(JsonString);
            string s = File.ReadAllText(@"C:\Users\Lamis Al Aswad\Desktop\Json Information\Json.txt"); 
            Console.WriteLine(s);
            //File.WriteAllText(@"C:\Users\Lamis Al Aswad\Desktop\Json Information\Json.txt", JsonString);
        }
    }
}
