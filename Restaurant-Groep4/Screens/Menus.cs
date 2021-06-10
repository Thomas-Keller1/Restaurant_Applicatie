using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {

    public static class Menus {

        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, 13);
            Program.display.AddString(0, 0, $"{new string('=', 37)}Menu's{new string('=', 37)}");
            Program.display.AddString(0, 1, x => (x.Email == null ? $"Niet ingelogd!" : $"Ingelogd met account: {x.GebruikersNaam}"), ConsoleColor.White);
            Program.display.AddString(0, 3, "2: Ontbijtmenu");
            Program.display.AddString(0, 4, "3: Lunchmenu");
            Program.display.AddString(0, 5, "4: Dinermenu");
            Program.display.AddString(0, 6, "5: Kindermenu");
            Program.display.AddString(0, 7, "6: Drankenkaart");
            Program.display.AddString(0, 9, "Afkortingen staan voor:");
            Program.display.AddString(0, 10, "V = vegetarisch - v = veganistisch - G = gluten");
            Program.display.AddString(0, 11, "Z = zuivel - N = noten - D = dieren");
            Program.display.AddString(0, 12, new string('=', 80));
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            Program.display.AddControl(new Control("Ontbijt", ScreenEnum.Ontbijtmenu, false));
            Program.display.AddControl(new Control("Lunch", ScreenEnum.Lunchmenu, false));
            Program.display.AddControl(new Control("Diner", ScreenEnum.Dinermenu, false));
            Program.display.AddControl(new Control("Kinder", ScreenEnum.Kindermenu, false));
            Program.display.AddControl(new Control("Dranken", ScreenEnum.Drankenkaart, false));
        }
    }
}
