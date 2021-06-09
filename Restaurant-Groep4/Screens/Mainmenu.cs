using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {

    public static class Mainmenu {
        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, 10);
            Program.display.AddString(0, 0, $"{new string('=', 35)}Main menu{new string('=', 36)}");
            Program.display.AddString(0, 2, "1: Inloggen");
            Program.display.AddString(0, 3, "2: Reserveren");
            Program.display.AddString(0, 4, "3: Reviews");
            Program.display.AddString(0, 5, "4: Menu's");    //Menu's
            Program.display.AddString(0, 6, "5: Duurzaamheid", ConsoleColor.Green);       //Duurzaamheid
            //Program.display.AddString(0, 7, "6: Adminpermissie");
            Program.display.AddString(0, 7, "6: Contactpagina");
            Program.display.AddString(0, 8, "7: Afsluiten"); //Afsluiten
            Program.display.AddString(0, 10, new string('=', 80));
            Program.display.AddControl(new Control("Inloggen", ScreenEnum.Login, false));
            Program.display.AddControl(new Control("Reserveren", ScreenEnum.ReserveringSchrijven, false));
            Program.display.AddControl(new Control("Reviews", ScreenEnum.Reviews, false));
            Program.display.AddControl(new Control("Menu's", ScreenEnum.Menus, false));      //Menu's
            Program.display.AddControl(new Control("Duurzaamheid", ScreenEnum.Mainmenu, false));             //Duurzaamheid
            //Program.display.AddControl(new Control("Adminpermissie", ScreenEnum.AdminPermissie, false));
            Program.display.AddControl(new Control("Contactpagina", ScreenEnum.ContactPagina, false));
            Program.display.AddControl(new Control("Afsluiten", ScreenEnum.Afsluiten, false));    //Afsluiten
        }
    }
}
