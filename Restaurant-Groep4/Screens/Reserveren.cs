using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens 
{
    class Reserveren {
       
        public static void ToDisplay()
        {
            Program.display.ClearDisplay();
            Program.display.AddString(0, 0, $"{new string('=', 31)}Reserveringen Menu{new string('=', 32)}");
            Program.display.AddString(0, 2, "Januari");
            Program.display.AddString(0, 3, "Februari");
            Program.display.AddString(0, 4, "Maart");
            Program.display.AddString(0, 5, "April");
            Program.display.AddString(0, 6, "Mei");
            Program.display.AddString(0, 7, "Juni");
            Program.display.AddString(0, 8, "Juli");
            Program.display.AddString(0, 9, "Augustus");
            Program.display.AddString(0, 10, "September");
            Program.display.AddString(0, 11, "Oktober");
            Program.display.AddString(0, 12, "November");
            Program.display.AddString(0, 13, "December");
            Program.display.AddString(0, 15, new string('=', 80));

            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            Program.display.AddControl(new Control("Januari", ScreenEnum.Januari, false));
            Program.display.AddControl(new Control("Februari", ScreenEnum.Februari, false));
            Program.display.AddControl(new Control("Maart", ScreenEnum.Maart, false));
            Program.display.AddControl(new Control("April", ScreenEnum.April, false));
            Program.display.AddControl(new Control("Mei", ScreenEnum.Mei, false));
            Program.display.AddControl(new Control("Juni", ScreenEnum.Juni, false));
            Program.display.AddControl(new Control("Juli", ScreenEnum.Juli, false));
            Program.display.AddControl(new Control("Augustus", ScreenEnum.Augustus, false));
            Program.display.AddControl(new Control("September", ScreenEnum.September, false));
            Program.display.AddControl(new Control("Oktober", ScreenEnum.Oktober, false));
            Program.display.AddControl(new Control("November", ScreenEnum.November, false));
            Program.display.AddControl(new Control("December", ScreenEnum.December, false));
        }
    }
}
