using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Reserveringen {

    public class Reservering {

        public string Naam { get; set; }
        public int Tafel { get; set; }
        public int Personnen { get; set; }
        public Date Datum { get; set; }

        public Reservering(string _naam, int _tafel, int _personnen, Date _datum) {

            Naam = _naam;
            Tafel = _tafel;
            Personnen = _personnen;
            Datum = _datum;
        }

    }
}