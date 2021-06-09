using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Reserveringen;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {
    public static class ReserveringsViewer {

        static List<Reservering> TodaysReservations = new List<Reservering>();

        public static void ToDisplay() {

            GetTodaysReservations();
            
            Program.display.ResizeDisplay(80, LinesNeeded());
            Program.display.AddString(0, 0, $"{new string('=', 18)}Staande reserveringen voor deze maand={new string('=', 18)}");
            Program.display.AddString(0, 1, x => (x.Email == null ? $"Not logged in!" : $"Logged in with account: {x.GebruikersNaam}"), ConsoleColor.White);
            int count = 3;
            int c2 = 1;

            foreach (Reservering reservering in TodaysReservations) {

                Program.display.AddString(0, count++, $"#{c2}");
                Program.display.AddString(0, count++, $"{new string('_', 80)}");
                Program.display.AddString(0, count++, $"Naam: {reservering.Naam}");
                Program.display.AddString(0, count++, $"Aantal Personen: {reservering.Personnen}");
                Program.display.AddString(0, count++, $"Tafelnummer: {reservering.Tafel}");
                Program.display.AddString(0, count++, $"Dag/maand: {reservering.Datum.Day}/{reservering.Datum.Day}");

                count++;
                c2++;
            }
            //Program.display.AddString(0, 3, "1: Reserveringen bekijken");
            Program.display.AddControl(new Control("Terug", ScreenEnum.AdminManager, false));
        }

        static void GetTodaysReservations() {

            DateTime now = DateTime.Today;
            Date Today = new Date(now.Year, now.Month, now.Day, now.Hour, now.Minute);

            foreach (Reservering reservering in Program.Reserveringhandler.Reserveringen) {

                if (reservering.Datum.Month == Today.Month && !(reservering.Datum < Today)) {

                    TodaysReservations.Add(reservering);
                }
            }   
        }

        static int LinesNeeded() {
            int count = 3;

            foreach (Reservering reservering in TodaysReservations) {

                count += 7;
            }
            return count;
        }
    }
}
