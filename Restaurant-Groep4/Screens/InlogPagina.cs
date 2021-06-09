using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Inloggen;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens
{
    public static class InlogPagina
    {
        public static List<Account> CurrentPersonHolder = new List<Account>();

        public static void ToDisplay()
        {
            Program.display.ResizeDisplay(80, 4);
            Program.display.AddString(0, 0, $"{new string('=', 31)}Inloggen{new string('=', 31)}");
            Program.display.AddString(0, 1, x => (x.Email == null ? $"Not logged in!" : $"Logged in with account: {x.GebruikersNaam}"), ConsoleColor.White);
            CurrentPersonHolder.Add(new Account("", "", "", "", ""));
            EditLogin();

            bool AccountExist = false;
            bool AccountDoesNotExist = true;

            foreach (Account account in Program.InlogHandler.Accounts)
            {
                
                if (CurrentPersonHolder[0].GebruikersNaam == account.GebruikersNaam)
                {

                    if (CurrentPersonHolder[0].Wachtwoord == account.Wachtwoord)
                    {
                        AccountExist = true;
                        Program.CurrentAccount = new Account(account.GebruikersNaam, account.Wachtwoord, account.Naam, account.Email, account.TelefoonNummer, account.Admin);
                        break;
                    }
                    else if (CurrentPersonHolder[0].Wachtwoord != account.Wachtwoord)
                    {

                        AccountExist = false;
                    }
                    if (CurrentPersonHolder[0].GebruikersNaam != account.GebruikersNaam)
                    {

                        AccountDoesNotExist = true;
                    }
                }
            }
            if (AccountExist)
            {
                Program.display.AddString(0, 3, $"U bent succesvol ingelogd met accountnaam {Program.CurrentAccount.GebruikersNaam}!");
            }
            else if (!AccountExist && !AccountDoesNotExist)
            {
                Program.display.AddString(0, 3, $"Uw wachtwoord komt niet overeen met uw gebruikersnaam.");
            }
            else if (AccountDoesNotExist)
            {
                Program.display.AddString(0, 3, $"Uw gebruikersnaam is niet in ons systeem bekend.");
            }
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            //Console.WriteLine($"{CurrentPersonHolder[0].GebruikersNaam}:{CurrentPersonHolder[0].Wachtwoord}");
        }

        public static void EditLogin()
        {
            Console.WriteLine("Voer uw gebruikersnaam in:");
            string gebruikersnaam = Console.ReadLine();

            Console.WriteLine("Voer uw wachtwoord in:");
            string wachtwoord = Console.ReadLine();

            CurrentPersonHolder[0].GebruikersNaam = gebruikersnaam;
            CurrentPersonHolder[0].Wachtwoord = wachtwoord;
        }
    }
}