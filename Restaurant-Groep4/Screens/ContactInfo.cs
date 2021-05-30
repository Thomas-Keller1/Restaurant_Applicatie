using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;
using Restaurant_Groep4.Contactpagina;

namespace Restaurant_Groep4.Screens
{
    class ContactInfo
    {
        public static void ToDisplay()
        {
            Program.display.ResizeDisplay(80, 9);
            Program.display.AddString(0, 0, $"{new string('=', 25)}Contact Pagina{new string('=', 25)}");
            Program.display.AddString(0, 2, $"Bedrijfsnaam: {Program.Contactpaginahandler.ContactPagina[0].BedrijfsNaam}");
            Program.display.AddString(0, 3, $"Email: {Program.Contactpaginahandler.ContactPagina[0].Email}");
            Program.display.AddString(0, 4, $"TelefoonNummer: {Program.Contactpaginahandler.ContactPagina[0].TelefoonNummer}");
            Program.display.AddString(0, 5, $"Openingstijden: {Program.Contactpaginahandler.ContactPagina[0].OpeningsTijden}");
            Program.display.AddString(0, 6, $"Locatie: {Program.Contactpaginahandler.ContactPagina[0].Locatie}");
            Program.display.AddString(0, 7, $"OverOns: {Program.Contactpaginahandler.ContactPagina[0].OverOns}");
            Program.display.AddString(0, 8, $"KlantenService: {Program.Contactpaginahandler.ContactPagina[0].KlantenService}");

            //Program.display.AddString(0, 2, "ContactPagina");//
            Program.display.AddControl(new Control("contactpagina", ScreenEnum.ContactPagina, false));
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
        }
    }
}


