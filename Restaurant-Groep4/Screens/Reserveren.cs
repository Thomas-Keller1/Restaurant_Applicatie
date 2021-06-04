using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Reserveringen;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens
{
    class Reserveren
    {
        public static void ToDisplay()
        {
            Program.display.ResizeDisplay(80, 10);
            //Program.display.AddString(0, 0, "Reserveren");
            Console.Clear();
            Console.Write("Naam: ");
            string naam = Console.ReadLine();
            string tafelInput = "";
            int tafel = -1;
            while (!int.TryParse(tafelInput, out tafel) || tafel <= 0 || tafel > 66)
            {
                Console.Write("Tafel: ");
                tafelInput = Console.ReadLine();
            }
            string persoonInput = "";
            int personen = -1;
            while (!int.TryParse(persoonInput, out personen) || personen < 0 || personen > 66)
            {
                Console.Write("Personen: ");
                persoonInput = Console.ReadLine();
            }
            string datumInput = "";
            DateTime datum;
            bool firstTime = true;
            while (!DateTime.TryParse(datumInput, out datum) || DateTime.Now.CompareTo(datum) >= 0)
            {
                if (!firstTime)
                {
                    if (!DateTime.TryParse(datumInput, out datum))
                        Console.WriteLine("Datum klopt niet.");
                    else if (DateTime.Now.CompareTo(datum) >= 0)
                        Console.WriteLine("Voer alstublieft een datum in na vandaag.");
                }
                Console.Write("Datum (mm/dd/yyyy): ");
                datumInput = Console.ReadLine();
                firstTime = false;
            }
            Program.Reserveringhandler.AddReservering(new Reservering(naam, tafel, personen, datum));
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
        }
    }
}
