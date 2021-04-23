using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Menu {

    class MenuItem {                        //creating a menuitem class

        public string name {get; set;}      //create the property name of type string
        public int price {get; set;}        //create the property price of type int
        public string description {get; set;}//create the property description of type string
        public bool vegetarian {get; set;}  //create the property vegetarian of type bool
        public bool vegan {get; set;}       //create the property vegan of type bool

        public MenuItem(string _name, int _price, string _description, bool _vegetarian, bool _vegan) { //menuitem constructor

            name = _name;                           //setting the name property to the argument _name of the constructor
            price = _price;                         //setting the price property to the argument _price of the constructor
            description = _description;             //setting the description property to the argument _description of the constructor
            vegetarian = _vegetarian;               //setting the vegetarian property to the argument _vegetarian of the constructor
            vegan = _vegan;                         //setting the vegan property to the argument _vegan of the constructor
        }
    }
}
