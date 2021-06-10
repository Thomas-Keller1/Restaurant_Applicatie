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
            Program.display.AddString(0, 1, x => (x.Email == null ? $"Niet ingelogd!" : $"Ingelogd met account: {x.GebruikersNaam}"), ConsoleColor.White);
            Program.display.AddString(0, 3, "2: Inloggen");
            Program.display.AddString(0, 4, "3: Account maken");
            Program.display.AddString(0, 5, "4: Uitloggen");
            Program.display.AddString(0, 9, new string('=', 80));
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            Program.display.AddControl(new Control("Inloggen", ScreenEnum.Inloggen, false));
            Program.display.AddControl(new Control("Account maken", ScreenEnum.AccountMaken, false));
            Program.display.AddControl(new Control("Uitloggen", ScreenEnum.Uitloggen, false));
        }
    }
}
