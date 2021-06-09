using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens
{
    public static class AdminMenu
    {
        public static void ToDisplay()
        {
            Program.display.ResizeDisplay(80, 9);
            Program.display.controls.Clear();
            Program.display.AddString(0, 0, $"{new string('=', 33)}Prijzen Menu{new string('=', 33)}");
            Program.display.AddString(0, 2, "1: DinerAdmin");
            Program.display.AddString(0, 3, "2: DrankenAdmin");
            Program.display.AddString(0, 4, "3: KinderAdmin");
            Program.display.AddString(0, 5, "4: LunchAdmin");
            Program.display.AddString(0, 6, "5: OntbijtAdmin");
            Program.display.AddString(0, 7, "6: Uitloggen");
            Program.display.AddControl(new Control("Uitloggen", ScreenEnum.Mainmenu, false));
            Program.display.AddControl(new Control("1: DinerAdmin", ScreenEnum.DinerAdmin, false));
            Program.display.AddControl(new Control("2: DrankenAdmin", ScreenEnum.DrankenAdmin, false));
            Program.display.AddControl(new Control("3: KinderAdmin", ScreenEnum.KinderAdmin, false));
            Program.display.AddControl(new Control("4: LunchAdmin", ScreenEnum.LunchAdmin, false));
            Program.display.AddControl(new Control("OntbijtAdmin", ScreenEnum.OntbijtAdmin, false));
        }
        
       
    }
}
