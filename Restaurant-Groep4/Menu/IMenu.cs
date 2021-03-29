using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Menu {

    interface IMenu {

        List<MenuPart> menuparts {get; set;}
        string menuname {get; set;}

        void ToDisplay(Display.Display display);

        int LinesNeeded();
    }
}
