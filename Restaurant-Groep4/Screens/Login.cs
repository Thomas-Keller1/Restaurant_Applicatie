using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens
{
    static class Login
    {
        public static void ToDisplay()
        {
            Program.display.ResizeDisplay(80, 9);
            Program.display.AddString(0, 0, $"{new string('=', 36)}Inloggen{new string('=', 36)}");
            Program.display.AddString(0, 2, "1: Inloggen");
            Program.display.AddString(0, 3, "2: Account aanmaken");
            Program.display.AddString(0, 8, new string('=', 80));
            Program.display.AddControl(new Control("Inloggen", ScreenEnum.Inloggen, false));
            Program.display.AddControl(new Control("Account aanmaken", ScreenEnum.AccountMaken, false));
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
        }
    }
}
