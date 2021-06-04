﻿using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Inloggen;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens
{
    static class InlogPagina
    {
        public static void ToDisplay()
        {
            Program.display.ResizeDisplay(80, 9);
            Program.display.AddString(0, 0, $"{new string('=', 31)}Inloggen{new string('=', 31)}");
            EditLogin();

            bool hi = true;

            if (hi)
            {
                Program.display.AddString(0, 2, $"U bent succesvol ingelogt.");
            }
            else if (!hi)
            {
                Program.display.AddString(0, 2, $"Uw wachtwoord komt niet overeen met uw gebruikersnaam.");
            }
            else
            {
                Program.display.AddString(0, 2, $"Uw gebruikersnaam is niet in ons systeem bekend.");
            }

            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
        }

        public static void EditLogin()
        {
            Console.WriteLine("Voer een gebruikersnaam in:");
            string gebruikersnaam = Console.ReadLine();

            Console.WriteLine("Voer een wachtwoord in:");
            string wachtwoord = Console.ReadLine();

            if (Program.Inloghandler.Login(gebruikersnaam, wachtwoord))
            {
                Console.WriteLine("succesvol ingelogd");
            }
            else
            {
                Console.WriteLine("niet ingelogd");
            }
        }
    }


}