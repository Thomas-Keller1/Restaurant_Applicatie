using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Menu {

    class MenuPart {

        public string partname {get; set;}
        public List<MenuItem> menuitems {get; set;}

        public MenuPart(string _name, List<MenuItem> _menuitems) {
            partname = _name;
            menuitems = _menuitems;
            //menuitems.Add(_menuitem);
        }
    }
}
