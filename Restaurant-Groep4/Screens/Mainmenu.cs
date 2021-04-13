using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {

    class Mainmenu {

        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, 10);
            Program.display.AddString(0, 0, $"{new string('=', 35)}Main menu{new string('=', 36)}");
            Program.display.AddString(0, 2, "1: Inloggen");
            Program.display.AddString(0, 3, "2: Reserveren");
            Program.display.AddString(0, 4, "3: Reviews plaatsen");
            Program.display.AddString(0, 5, "4: Afsluiten");
            Program.display.AddString(0, 6, "5: Menu's");
            Program.display.AddString(0, 7, "6: Duurzaamheid");
            Program.display.AddString(0, 9, new string('=', 80));
            Program.display.AddControl(new Control("Inloggen", ScreenEnum.Login, false));
            Program.display.AddControl(new Control("Reserveren", ScreenEnum.Reserveren, false));
            Program.display.AddControl(new Control("Reviews", ScreenEnum.Reviews, false));
            Program.display.AddControl(new Control("Afsluiten", ScreenEnum.Afsluiten, false));
            Program.display.AddControl(new Control("Menu's", ScreenEnum.Menus, false));
            Program.display.AddControl(new Control("Duurzaamheid", ScreenEnum.Mainmenu, false));
        }
    }
}
