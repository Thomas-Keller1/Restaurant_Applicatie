using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Restaurant_Groep4.Contactpagina
{
    public class Contactpagina
    {

        public string BedrijfsNaam { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public string OpeningsTijden { get; set; }
        public string Locatie { get; set; }
        public string OverOns { get; set; }
        public string KlantenService { get; set; }

        public Contactpagina(string bedrijfsname, string email, string telefoonnummer, string openingstijden, string locatie, string overons, string klantenservice)
        {
            BedrijfsNaam = bedrijfsname;
            Email = email;
            TelefoonNummer = telefoonnummer;
            OpeningsTijden = openingstijden;
            Locatie = locatie;
            OverOns = overons;
            KlantenService = klantenservice;
        }
    }
}
