using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Reserveringen
{
    class ReserveringHandler
    {
        public List<Reservering> Reserveringen { get; set;}

        public ReserveringHandler()
        {
            Reserveringen = new List<Reservering>();
        }
    }
}
