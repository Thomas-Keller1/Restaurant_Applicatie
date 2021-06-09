using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;
using Restaurant_Groep4.AdminPermissie;

namespace Restaurant_Groep4.Screens
{
    public static class AdminInfo
    {
        //public static List<Adminpermissie> LoginAdmin = new List<Adminpermissie>();//
        public static bool Inloggen = false;
        public static void ToDisplay()
        {
            Program.display.ResizeDisplay(80, 9);
            //Program.display.AddString(0, 0, $"{new string('=', 25)}Adminpermissie{new string('=', 25)}");
            INLOGGEN();
            //Program.display.AddString(0, 2, $"Gebruiksnaam: ");

            //Program.display.AddString(0, 4, $"{LoginAdmin[0].GebruiksNaam}");//

            //Program.display.AddString(0, 6, $"Wachtwoord: ");
            //Program.display.AddString(0, 8, $"{LoginAdmin[0].Wachtwoord}");
            //Program.display.AddControl(new Control("Adminpermissie", ScreenEnum.AdminPermissie, false));//

            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            Program.display.AddControl(new Control("Admin menu", ScreenEnum.AdminMenu, false));
        }
        public static void INLOGGEN()
        {
            //string naam, wachtwoord;

            Console.WriteLine("\n\n************** Info over u ************** ");
            Console.WriteLine("\n Uw naam is : Admin");
            //naam = Console.ReadLine();

            Console.WriteLine("\n Uw wachtwoord is : Admin123!");
            //wachtwoord = Console.ReadLine();

            //Console.WriteLine("\n\n************** Info over u ************** ");
            Console.WriteLine("\n U bent een beheerder, dus u heeft meer toegang!");

            /*
            if (naam == "Admin" && wachtwoord == "Admin123!")
            {
                Console.WriteLine("U bent een beheerder, dus u heeft meer toegang!");
                Console.WriteLine("[1]prijzen aanpassen\n");
            }
            else
            {
                Console.WriteLine("U bent geen beheerder vervolgens kunt u geen veranderingen toevoegen");
            }
            */
        }
    }
}
