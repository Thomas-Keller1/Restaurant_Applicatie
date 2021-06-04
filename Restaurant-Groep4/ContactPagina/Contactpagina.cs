using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Restaurant_Groep4.Contactpagina
{
    public class Contactpagina
    {

        /*static void Main(string[] args)
        {
            Console.WriteLine("****Contact pagina****");
            Console.WriteLine();
            Console.WriteLine("___________________________________");
            Console.WriteLine("");
            Information CP = new Information("**Restaurant**", "contact@Restaurant.nl", "0031657484333", "11:00_00:00", "Aalscholverlaan\n 3232RR Rotterdam", "In our restaurant you will find the most delicious food. You have more than 20 options.You can also select the time you want and also the place where you would like to sit", "Common questions : 1.__How can i reserve a place ?You can do this by choosing the time you want to watch on the main page of the application,then you can choose the chair that suits you and select the payment method,after that you will receive an email with your reservation, your code and your tafel number.2.__ Is it poossible to cancel or change the reservation?Reservation can be changed or canceled 24 hours before the reservation date.for more information, contact us :)");

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true
            };
            var jsonString = JsonSerializer.Serialize(new Information[] { CP }, options);
            Console.WriteLine(jsonString);
            File.WriteAllText("data.json", jsonString);
        }
    }

    class Information
    {*/
        public string BedrijfsNaam { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public string OpeningsTijden { get; set; }
        public string Locatie { get; set; }
        public string OverOns { get; set; }
        public string KlantenService { get; set; }

        public Contactpagina(string bedrijfsname, string email, string telefoonnummer, string openingstijden, string locatie, string overons, string klantenservice)
        {
            BedrijfsNaam = bedrijfsname;
            Email = email;
            TelefoonNummer = telefoonnummer;
            OpeningsTijden = openingstijden;
            Locatie = locatie;
            OverOns = overons;
            KlantenService = klantenservice;
        }
    }
}
