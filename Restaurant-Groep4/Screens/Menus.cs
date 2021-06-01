using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {

    public static class Menus {

        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, 9);
            Program.display.AddString(0, 0, $"{new string('=', 37)}Menu's{new string('=', 37)}");
            Program.display.AddString(0, 2, "1: Ontbijtmenu");
            Program.display.AddString(0, 3, "2: Lunchmenu");
            Program.display.AddString(0, 4, "3: Dinermenu");
            Program.display.AddString(0, 5, "4: Kindermenu");
            Program.display.AddString(0, 6, "5: Drankenkaart");
            Program.display.AddString(0, 8, new string('=', 80));
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            Program.display.AddControl(new Control("Ontbijt", ScreenEnum.Ontbijtmenu, false));
            Program.display.AddControl(new Control("Lunch", ScreenEnum.Lunchmenu, false));
            Program.display.AddControl(new Control("Diner", ScreenEnum.Dinermenu, false));
            Program.display.AddControl(new Control("Kinder", ScreenEnum.Kindermenu, false));
            Program.display.AddControl(new Control("Dranken", ScreenEnum.Drankenkaart, false));
        }
    }
}
