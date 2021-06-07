using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Inloggen;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens
{
    class AccountMaken
    {
        public static List<Account> CurrentAccountHolder = new List<Account>();

        public static void ToDispaly()
        {
            Program.display.ResizeDisplay(80, 14);
            EditAccount();
            //Program.InlogHandler.AddAccount(CurrentAccountHolder[0]);
            Program.display.AddString(0, 0, $"{new string('=', 31)}Maak een account{new string('=', 31)}");
            Program.display.AddString(0, 2, $"Uw huidige account");
            Program.display.AddString(0, 4, $"Uw gebruikersnaam: {CurrentAccountHolder[0].GebruikersNaam}");
            Program.display.AddString(0, 5, $"Uw wachtwoord: {CurrentAccountHolder[0].Wachtwoord}");
            Program.display.AddString(0, 7, $"Uw naam: {CurrentAccountHolder[0].Naam }");
            Program.display.AddString(0, 8, $"Uw e-mailaderes: {CurrentAccountHolder[0].Email}");
            Program.display.AddString(0, 9, $"Uw telefoonnummer: {CurrentAccountHolder[0].TelefoonNummer}");
            // Program.display.AddString(0, 11, $"Uw account is succesvol gemaakt.");
            Program.display.AddString(0, 13, new string('=', 80));

            Console.Write("Kloppen deze gegevens ja/nee: ");
            string ans = Console.ReadLine();
            if (ans == "ja" || ans == "Ja" || ans == "jA" || ans == "JA")
            {
                Console.WriteLine("Bedankt voor het maken van een account! Uw account is succesvol gemaakt.");
                Program.InlogHandler.AddAccount(CurrentAccountHolder[0]);
                Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            }
            else
            {
                Console.WriteLine("\nMaak de account opnieuw!\n");
                EditAccount();
            }
            //Program.display.AddControl(new Control("Terug", ScreenEnum.Login, false));
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

            Console.WriteLine("Voer uw telefoonnummer in: (beginnen met 06)");
            string telefoonNummer = Console.ReadLine();

            CurrentAccountHolder.Add(new Account(gebruikersnaam, wachtwoord, naam, email, telefoonNummer));
            //CurrentAccountHolder[0].GebruikersNaam = gebruikersnaam;
            //CurrentAccountHolder[0].Wachtwoord = wachtwoord;
            //CurrentAccountHolder[0].Naam = naam;
            //CurrentAccountHolder[0].Email = email;
        }
    }
}