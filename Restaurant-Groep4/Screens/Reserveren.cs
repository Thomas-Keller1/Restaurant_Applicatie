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
            Program.display.AddString(0, 0, $"{new string('=', 31)}Reserveringen Menu{new string('=', 31)}");
            Program.display.AddString(0, 2, "Staande Reserveringen");
            Program.display.AddString(0, 4, new string('=', 80));

            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            Program.display.AddControl(new Control("Staande Reserveringen", ScreenEnum.ReserveringViewer, false));
        }
    }
}
