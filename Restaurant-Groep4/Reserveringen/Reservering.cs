using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Reserveringen {

    public class Reservering {

        public string Naam { get; set; }
        public int Tafel { get; set; }
        public int Personen { get; set; }
        public DateTime Datum { get; set; }

        public Reservering(string _naam, int _tafel, int _personen, DateTime _datum) {

            Naam = _naam;
            Tafel = _tafel;
            Personen = _personen;
            Datum = _datum;
        }

    }
}