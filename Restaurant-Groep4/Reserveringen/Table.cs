using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Reserveringen {

    public struct Table {

        public bool Available {get; set;}
        public int Persons {get; private set;}

        public Table(bool _available, int _persons) {

            Available = _available;
            Persons = _persons;
        }
    }
}
