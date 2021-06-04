using System;
using System.Collections.Generic;
using Restaurant_Groep4.Inloggen;
using Restaurant_Groep4.Misc;
using System.IO;
using System.Text.Json;

namespace Restaurant_Groep4.Screens
{
    class AccountMaken
    {
        public static void ToDispaly()
        {
            Program.display.ResizeDisplay(80, 9);
            EditAccount();
            //Program.InlogHandler.AddAccount(CurrentAccountHolder[0]);
            //Program.display.AddString(0, 0, $"{new string('=', 31)}Maak een account{new string('=', 31)}");
            //Program.display.AddString(0, 2, $"Uw huidige account");
            //Program.display.AddString(0, 4, $"Uw gebruikersnaam: {CurrentAccountHolder[0].GebruikersNaam}");
            //Program.display.AddString(0, 6, $"Uw wachtwoord: {CurrentAccountHolder[0].Wachtwoord}");
            //Program.display.AddString(0, 8, $"Uw naam: {CurrentAccountHolder[0].Naam }");
            //Program.display.AddString(0, 9, $"Uw e-mailaderes{CurrentAccountHolder[0].Email}");
            //Program.display.AddString(0, 10, $"Uw account is succesvol gemaakt.");
            //Program.display.AddString(0, 13, new string('=', 80));

            Program.display.AddControl(new Control("Terug", ScreenEnum.Login, false));
        }

        public static void EditAccount()
        {
            Console.WriteLine("Voer een gebruikersnaam in:");
            string gebruikersnaam = Console.ReadLine();

            Console.WriteLine("Voer een wachtwoord in:");
            string wachtwoord = Console.ReadLine();

            Console.WriteLine("Voer uw naam in:");
            string naam = Console.ReadLine();

            Console.WriteLine("Voer uw e-mailadres in:");
            string email = Console.ReadLine();

            Program.Inloghandler.AddAccount(new Account  {  GebruikersNaam = gebruikersnaam, Wachtwoord = wachtwoord, Naam = naam, Email = email, Admin = false });
        }
    }
}