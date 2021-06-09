using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Restaurant_Groep4.AdminPermissie
{
    public class Adminpermissie
    {
        public string GebruiksNaam { get; set; }
        public string Wachtwoord { get; set; }
        public Adminpermissie(string _gebruiksnaam, string _wachtwoord)
        {
            GebruiksNaam = _gebruiksnaam;
            Wachtwoord = _wachtwoord;
        }
    }
}
