using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Inloggen;
using Restaurant_Groep4.Menu;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens
{
    static class InlogPagina
    {
        public static void ToDisplay()
        {
            Program.display.ResizeDisplay(80, 15);
            Program.display.AddString(0, 0, $"{new string('=', 31)}Inloggen{new string('=', 31)}");
            bool admin = EditLogin();
            Console.WriteLine(admin);
            if (admin)
            {
                //Console.Clear();
                Program.display.controls.Clear();
                Program.display.AddString(0, 0, $"{new string('=', 35)}Admin Menu{new string('=', 35)}");
                Program.display.AddString(0, 2, "1: Admin Menu");
                Program.display.AddString(0, 3, "2: Admin Info");
                Program.display.AddControl(new Control("Admin menu", ScreenEnum.AdminMenu, false));
                Program.display.AddControl(new Control("Admin Info", ScreenEnum.AdminInfo, false));
                Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            }
            else
            {
                Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            }
        }

        public static bool EditLogin()
        {
            Console.WriteLine("Voer een gebruikersnaam in:");
            string gebruikersnaam = Console.ReadLine();

            Console.WriteLine("Voer een wachtwoord in:");
            string wachtwoord = Console.ReadLine();

            return Program.Inloghandler.Login(gebruikersnaam, wachtwoord);
            
        }


    }


}