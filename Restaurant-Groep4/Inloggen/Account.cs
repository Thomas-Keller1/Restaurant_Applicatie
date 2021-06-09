using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Inloggen
{
    public class Account
    {
        public string GebruikersNaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public bool Admin { get; set; }

        public Account(string _gebruikersnaam, string _wachtwoord, string _naam, string _email, string _telefoonNummer)
        {
            GebruikersNaam = _gebruikersnaam;
            Wachtwoord = _wachtwoord;
            Naam = _naam;
            Email = _email;
            TelefoonNummer = _telefoonNummer;
        }

        public Account(string _gebruikersnaam, string _wachtwoord, string _naam, string _email, string _telefoonNummer, bool _admin)
        {
            GebruikersNaam = _gebruikersnaam;
            Wachtwoord = _wachtwoord;
            Naam = _naam;
            Email = _email;
            TelefoonNummer = _telefoonNummer;
            Admin = _admin;
        }
    }
}