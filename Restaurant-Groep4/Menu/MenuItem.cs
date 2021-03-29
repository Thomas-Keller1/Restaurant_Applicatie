using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Menu {

    class MenuItem {

        public string name {get; set;}
        public int price {get; set;}
        public string description {get; set;}
        public bool vegetarian {get; set;}
        public bool vegan {get; set;}

        public MenuItem(string _name, int _price, string _description, bool _vegetarian, bool _vegan) {

            name = _name;
            price = _price;
            description = _description;
            vegetarian = _vegetarian;
            vegan = _vegan;
        }
    }
}
