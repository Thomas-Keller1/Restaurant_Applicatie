using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Menu {
    class MenuRegister {                //creating a menuregister class to register all our menus in we do it here instead of in our main program.cs file

        public static List<Tuple<IMenu, ScreenEnum>> menuregister = new List<Tuple<IMenu, ScreenEnum>>(); //Has a public static List of tuples the tuples are of the type Imenu, screenEnum

        public static void RegisterMenus() {                                        //Public static Registermenus method to call in the start function of program
            RegisterMenu(new MultiPageMenu("testmenu", 1), ScreenEnum.Kindermenu);  //Registering a testmenu (It is called that but has all the values of the kindermenu)
        }

        private static void RegisterMenu(IMenu menu, ScreenEnum screenenum) {       //Private registermenu method that takes in an IMenu and a screenenum(Note that the IMenu can be an instance of both multipagemenu and singlepagemenu)
            menuregister.Add(Tuple.Create(menu, screenenum));                       //create a new tuple with the arguments and add that to the list
        }
    }
}
