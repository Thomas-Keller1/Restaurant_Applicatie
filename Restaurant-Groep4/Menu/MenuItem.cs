using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Menu {

    public class MenuItem {                        //creating a menuitem class

        public string name { get; set; }      //create the property name of type string
        public int price { get; set; }        //create the property price of type int
        public string description { get; set; }//create the property description of type string
        public bool vegetarian { get; set; }  //create the property vegetarian of type bool
        public bool vegan { get; set; }       //create the property vegan of type bool
        public bool gluten { get; set; }    //create the property gluten of type bool
        public bool zuivel { get; set; }    //create the property zuivel of type bool
        public bool noten { get; set; }     //create the property noten of type bool
        public bool dieren { get; set; }    //create the property dieren of type bool

        public MenuItem(string _name, int _price, string _description, bool _vegetarian, bool _vegan, bool _gluten, bool _zuivel, bool _noten, bool _dieren)
        { //menuitem constructor

            name = _name;                           //setting the name property to the argument _name of the constructor
            price = _price;                         //setting the price property to the argument _price of the constructor
            description = _description;             //setting the description property to the argument _description of the constructor
            vegetarian = _vegetarian;               //setting the vegetarian property to the argument _vegetarian of the constructor
            vegan = _vegan;                         //setting the vegan property to the argument _vegan of the constructor
            gluten = _gluten;                       //setting the gluten property to the argument _gluten of the constructor
            zuivel = _zuivel;                       //setting the zuivel property to the argument _zuivel of the constructor
            noten = _noten;                         //setting the noten property to the argument _noten of the constructor
            dieren = _dieren;                       //setting the dieren property to the argument _dieren of the constructor
        }
    }
}
