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
        public bool Admin { get; set; }
    }
}