using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Inloggen
{
    class Account
    {
        public string GebruikersNaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }

        public Account(string _gebruikersnaam, string _wachtwoord, string _naam, string _email)
        {
            GebruikersNaam = _gebruikersnaam;
            Wachtwoord = _wachtwoord;
            Naam = _naam;
            Email = _email;
        }
    }
}