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

            Program.display.ResizeDisplay(80, lambda(Program.CurrentAccount)(13));
            //Program.display.AddControl(new Control(""));
            Program.display.AddString(0, 0, $"{new string('=', 31)}Welcome bij Verde!{new string('=', 31)}");
            Program.display.AddString(0, 1, "Welkom bij de applicatie van restaurant Verde. Ons naam is Italiaans voor groen, want in ons restaurant staat duurzaamheid op nummer 1!");
            Program.display.AddString(0, 3, x => (x.Email == null ? $"Niet ingelogd!" : $"Ingelogd met account: {x.GebruikersNaam}"), ConsoleColor.White);
            Program.display.AddString(0, 5, "1: Inloggen");
            Program.display.AddString(0, 6, "2: Reserveren");
            //Program.display.SetColor(3, 3, 13, ConsoleColor.Red);
            Program.display.AddString(0, 7, "3: Reviews");
            Program.display.AddString(0, 8, "4: Menu's");    //Menu's
            Program.display.AddString(0, 9, "5: Contactpagina", ConsoleColor.Green);       //Duurzaamheid
            Program.display.AddString(0, lambda(Program.CurrentAccount)(10), $"{lambda(Program.CurrentAccount)(6)}: Afsluiten"); //Afsluiten
            Program.display.AddString(0, lambda(Program.CurrentAccount)(12), new string('=', 80));
            if (Program.CurrentAccount.Admin) { Program.display.AddString(0, 8, "6: Admin manager"); }
            //Program.display.AddString(0, 10, "Al onze producten zijn afkomstig van lokale boerderijen om klimaatverandering tegen te gaan", ConsoleColor.Green);
            Program.display.AddControl(new Control("Inloggen", ScreenEnum.Login, false));
            Program.display.AddControl(new Control("Reserveren", ScreenEnum.ReserveringSchrijven, false));
            Program.display.AddControl(new Control("Reviews", ScreenEnum.Reviews, false));
            Program.display.AddControl(new Control("Menu's", ScreenEnum.Menus, false));      //Menu's
            Program.display.AddControl(new Control("Contactpagina", ScreenEnum.Contactpage, false));             //Duurzaamheid
            if (Program.CurrentAccount.Admin) { Program.display.AddControl(new Control("Admin manager", ScreenEnum.AdminManager, false)); }
            Program.display.AddControl(new Control("Afsluiten", ScreenEnum.Afsluiten, false));    //Afsluiten
        }
    }
}




//0111000111001010100011001110
//"usernamekey: passwordkey"
//"usernamekey1key2: passwordkey1key2"
//"username-key: password-key"
