using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;
namespace Restaurant_Groep4.Screens {
    class ContactInfo
    {
        public static void ToDisplay()
        {
            Program.display.ResizeDisplay(175, 14);
            Program.display.AddString(0, 0, $"{new string('=', 25)}Contact Pagina{new string('=', 25)}");
            Program.display.AddString(0, 2, $"Bedrijfsnaam: Verde");
            Program.display.AddString(0, 3, $"Email: contact@verde.nl");
            Program.display.AddString(0, 4, $"TelefoonNummer: 0031657484333");
            Program.display.AddString(0, 5, $"Openingstijden: 11:00_00:00");
            Program.display.AddString(0, 6, $"Locatie: Aalscholverlaan, 3232RR Rotterdam");
            Program.display.AddString(0, 7, $"OverOns: In Verde restaurant vind je het lekkerste eten. Je hebt meer dan 20 opties, je kunt ook de tijd selecteren die\n je wilt en ook de plaats waar je wilt zitten.");
            Program.display.AddString(0, 9, $"KlantenService: Veelgestelde vragen: \n.Hoe kan ik een plaats reserveren? \n.Is het mogelijk om de reservering te annuleren of te wijzigen?\n                                                      Voor meer informatie kunt u contact met ons opnemen :)");
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
        }
    }
}