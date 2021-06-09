using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Reserveringen;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {
    public static class ReserveringWriter {

        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, 1);
            //Program.display.AddString(0, 0, "Reserveren");
            //Console.Clear();
            Console.Write("Naam: ");
            string naam = Console.ReadLine();
            string tafelInput = "";
            bool first = true;
            int tafel = -1;//maak min
            while (!(int.TryParse(tafelInput, out tafel) && tafel > 0 && tafel < 16 && Program.Reserveringhandler.Tables[tafel > 0 && tafel < 16 ? tafel - 1 : 0].Available)) {

                if (!first) { Console.WriteLine("Geef een tafelnummer dat de 1 en de 16 ligt of de opgegeven tafel is niet beschikbaar");}
                Console.Write("Tafel: ");
                tafelInput = Console.ReadLine();
                first = false;
            }
            string persoonInput = "";
            int personen = -1;//maak min
            first = true;
            while (!int.TryParse(persoonInput, out personen) || personen < 1 || personen > Program.Reserveringhandler.Tables[tafel - 1].Persons) {

                if (!first) { Console.WriteLine($"Geef een aantal personen op dat minstens 1 is en maximaal {Program.Reserveringhandler.Tables[tafel - 1].Persons} is"); }
                Console.Write("Personen: ");
                persoonInput = Console.ReadLine();
                first = false;
            }
            string datumInput = "";

            DateTime HalfyearFromNow = DateTime.Now;
            HalfyearFromNow = new DateTime(HalfyearFromNow.Year + 1, HalfyearFromNow.Month, HalfyearFromNow.Day, HalfyearFromNow.Hour, HalfyearFromNow.Minute, HalfyearFromNow.Second);
            DateTime datum;
            bool firstTime = true;
            while (!DateTime.TryParse(datumInput, out datum) || DateTime.Now.CompareTo(datum) >= 0 || datum > HalfyearFromNow) {

                if (!firstTime) {

                    if (!DateTime.TryParse(datumInput, out datum))
                        Console.WriteLine("Datum klopt niet.");
                    else if (DateTime.Now.CompareTo(datum) >= 0)
                        Console.WriteLine("Voer alstublieft een datum in na vandaag.");
                }
                Console.Write("Datum (mm/dd/yyyy): ");
                datumInput = Console.ReadLine();
                firstTime = false;
            }
            Console.WriteLine($"{new string('=', 31)}Huidige reservering{new string('=', 30)}\n");
            Console.WriteLine(Program.CurrentAccount.Email == null ? $"Niet ingelogd!" : $"Ingelogd met account: {Program.CurrentAccount.GebruikersNaam}");
            Console.WriteLine($"Naam: {naam}\nTafelnummer: {tafel}\nPersonen: {personen}\nDatum (maand/dag/jaar): {datum.Month}/{datum.Day}/{datum.Year}\n");
            Console.WriteLine(new string('=', 80));
            Console.Write("Klopt deze reservering ja/nee: ");
            string ans = Console.ReadLine();
            if (ans == "ja" || ans == "Ja" || ans == "jA" || ans == "JA") {
                Console.WriteLine("Bedankt voor het reserveren! De reservering is geplaatst!");
                Program.Reserveringhandler.AddReservering(new Reservering(naam, tafel, personen, new Date(datum.Year, datum.Month, datum.Day, datum.Hour, datum.Minute)));
                Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            }
            else {
                Console.WriteLine("\nMaak de reservering opnieuw!\n");
                ReserveringWriter.ToDisplay();
            }
        }
    }
}
