using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Reserveringen
{
    class Reservering
    {
        public string Naam {get; set;}
        public int Tafel {get; set;}
        public int Personen { get; set;}
        public DateTime Datum { get; set;}
    }
}
