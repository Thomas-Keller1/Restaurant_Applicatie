using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {

    public static class Mainmenu {
        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, 12);
            //Program.display.AddControl(new Control(""));
            Program.display.AddString(0, 0, $"{new string('=', 31)}Welcome bij Verde!{new string('=', 31)}");
            Program.display.AddString(0, 1, "Welkom bij de applicatie van restaurant Verde. Ons naam is Italiaans voor groen, want in ons restaurant staat duurzaamheid op nummer 1!");
            Program.display.AddString(0, 4, "1: Inloggen");
            Program.display.AddString(0, 5, "2: Reserveren");
            //Program.display.SetColor(3, 3, 13, ConsoleColor.Red);
            Program.display.AddString(0, 6, "3: Reviews");
            Program.display.AddString(0, 7, "4: Menu's");    //Menu's
            Program.display.AddString(0, 8, "5: Duurzaamheid", ConsoleColor.Green);       //Duurzaamheid
            Program.display.AddString(0, 9, "6: Afsluiten"); //Afsluiten
            Program.display.AddString(0, 11, new string('=', 80));
            Program.display.AddControl(new Control("Inloggen", ScreenEnum.Login, false));
            Program.display.AddControl(new Control("Reserveren", ScreenEnum.ReserveringSchrijven, false));
            Program.display.AddControl(new Control("Reviews", ScreenEnum.Reviews, false));
            Program.display.AddControl(new Control("Menu's", ScreenEnum.Menus, false));      //Menu's
            Program.display.AddControl(new Control("Duurzaamheid", ScreenEnum.Mainmenu, false));             //Duurzaamheid
            Program.display.AddControl(new Control("Afsluiten", ScreenEnum.Afsluiten, false));    //Afsluiten
        }
    }
}
