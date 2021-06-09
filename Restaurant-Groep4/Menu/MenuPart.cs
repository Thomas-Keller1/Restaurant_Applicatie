using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Menu {

    public class MenuPart {                                //creating the menupart class

        public string partname { get; set; }        //create the property partname of type string
        public List<MenuItem> menuitems { get; set; }   //create the property menuitems of type List that holds instances of our menuitems class

        public MenuPart(string _name, List<MenuItem> _menuitems) {  //constructor for our menupart class
            partname = _name;                                       // setting the partname property to the argument _name of the constructor
            menuitems = _menuitems;                                 // setting the menuitems property to the argument _menuitems of the constructor
            //menuitems.Add(_menuitem);
        }
    }
}
