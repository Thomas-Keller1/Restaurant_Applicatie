using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using Restaurant_Groep4.Reserveringen;

namespace Restaurant_Groep4.Screens
{
    class ReserveringViewer {

        private static int OnPage = 1;
        private static int ReserveringenPerPage = 5;
        private static int PageCount = CalculatePageCount();

        public static void ToDisplay() {
            Program.display.ResizeDisplay(80, 9);
            int CurrentY = 0;
            int count = 0;
            int Total = 0;
            Program.display.AddString(0, CurrentY, $"{new string('=', 35)}maand{new string('=', 36)}");
            CurrentY += 2;
            foreach (Reservering reservering in Program.Reserveringhandler.Reservering)
            {
                if (count < (OnPage * ReserveringenPerPage) && count >= ((OnPage - 1) * ReserveringenPerPage)) {

                    Program.display.AddString(0, CurrentY, $"#{Total + 1}:");
                    CurrentY++;
                    Program.display.AddString(0, CurrentY, $"Op naam van: {reservering.Naam}");
                    CurrentY++;
                    Program.display.AddString(0, CurrentY, $"Tafel: {reservering.Tafel}");
                    CurrentY++;
                    Program.display.AddString(0, CurrentY, $"Aantal personen: {reservering.Personnen}");
                    CurrentY++;
                    Program.display.AddString(0, CurrentY, $"Datum: {reservering.Datum}");
                    CurrentY++;
                    Total++;
                }
                if (Total >= ReserveringenPerPage) { break; }
                Total++;
            }
            Program.display.AddString(0, CurrentY + 1, new string('=', 80));
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            if (OnPage > 1) {
                Program.display.AddControl(new Control("Vorige pagina", ScreenEnum.Mainmenu, true));
            }
            if (OnPage < PageCount) {
                Program.display.AddControl(new Control("Volgende pagina", ScreenEnum.Menus, true));
            }
            PageCount = CalculatePageCount();
        }

        private static int CalculatePageCount()
        {

            int count = Program.Reviewhandler.Reviews.Count / ReserveringenPerPage;
            if (Program.Reviewhandler.Reviews.Count % ReserveringenPerPage != 0) { count++; }

            return count;
        }
    }
}
