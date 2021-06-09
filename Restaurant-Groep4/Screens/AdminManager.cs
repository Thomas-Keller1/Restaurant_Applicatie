using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {
    public static class AdminManager {

        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, 6);
            Program.display.AddString(0, 0, $"{new string('=', 33)}Admin Manager={new string('=', 33)}");
            Program.display.AddString(0, 1, x => (x.Email == null ? $"Niet ingelogd!" : $"Ingelogd met account: {x.GebruikersNaam}"), ConsoleColor.White);
            Program.display.AddString(0, 3, "2: Reserveringen bekijken");
            Program.display.AddString(0, 4, "3: Prijzen aanpassen");
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            Program.display.AddControl(new Control("Reserveringen", ScreenEnum.ReserveringViewer, false));
            Program.display.AddControl(new Control("Prijzen Aanpassen", ScreenEnum.PrijsAanpasser, false));

        }
    }
}
