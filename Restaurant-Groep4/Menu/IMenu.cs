using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Menu {

    public interface IMenu {                           //creating an interface called IMenu

        //All interface methods and properties are public
        List<MenuPart> menuparts {get; set;}    //each menu class has a list of menuparts
        string menuname {get; set;}             //each menu class has a menuname

        void ToDisplay(Display.Display display);//each menu class has a void method called ToDisplay that takes in a display

        void SaveToJSONFirstTime();

        int LinesNeeded();                      //each menu class has a int method called Linesneeded that takes no arguments

        void ModifyPrivateValue(int modifier);  //each menu class has a void method called modifyprivatevalue that takes in a int
    }
}
