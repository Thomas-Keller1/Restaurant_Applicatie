using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {

    public static class Mainmenu {
        public static void ToDisplay() {

            Func<Inloggen.Account, Func<int, int>> lambda = x => (y => (x.Admin ? y + 1 : y));
            //int value = lambda(Program.CurrentAccount)(7);

            Program.display.ResizeDisplay(80, lambda(Program.CurrentAccount)(11));
            //Program.display.AddControl(new Control(""));
            Program.display.AddString(0, 0, $"{new string('=', 35)}Main menu{new string('=', 36)}");
            Program.display.AddString(0, 1, x => (x.Email == null ? $"Not logged in!" : $"Logged in with account: {x.GebruikersNaam}"), ConsoleColor.White);
            Program.display.AddString(0, 3, "1: Inloggen");
            Program.display.AddString(0, 4, "2: Reserveren");
            //Program.display.SetColor(3, 3, 13, ConsoleColor.Red);
            Program.display.AddString(0, 5, "3: Reviews");
            Program.display.AddString(0, 6, "4: Menu's");    //Menu's
            Program.display.AddString(0, 7, "5: Duurzaamheid", ConsoleColor.Green);       //Duurzaamheid
            Program.display.AddString(0, lambda(Program.CurrentAccount)(8), $"{lambda(Program.CurrentAccount)(6)}: Afsluiten"); //Afsluiten
            Program.display.AddString(0, lambda(Program.CurrentAccount)(10), new string('=', 80));
            if (Program.CurrentAccount.Admin) { Program.display.AddString(0, 8, "6: Admin manager"); }
            //Program.display.AddString(0, 10, "Al onze producten zijn afkomstig van lokale boerderijen om klimaatverandering tegen te gaan", ConsoleColor.Green);
            Program.display.AddControl(new Control("Inloggen", ScreenEnum.Login, false));
            Program.display.AddControl(new Control("Reserveren", ScreenEnum.ReserveringSchrijven, false));
            Program.display.AddControl(new Control("Reviews", ScreenEnum.Reviews, false));
            Program.display.AddControl(new Control("Menu's", ScreenEnum.Menus, false));      //Menu's
            Program.display.AddControl(new Control("Duurzaamheid", ScreenEnum.Mainmenu, false));             //Duurzaamheid
            if (Program.CurrentAccount.Admin) { Program.display.AddControl(new Control("Admin manager", ScreenEnum.AdminManager, false)); }
            Program.display.AddControl(new Control("Afsluiten", ScreenEnum.Afsluiten, false));    //Afsluiten
        }
    }
}




//0111000111001010100011001110
//"usernamekey: passwordkey"
//"usernamekey1key2: passwordkey1key2"
//"username-key: password-key"
