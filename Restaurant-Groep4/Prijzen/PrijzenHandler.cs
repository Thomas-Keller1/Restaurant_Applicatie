using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Menu;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Prijzen
{
    class ChangePrice
    {
        static Dictionary<ScreenEnum, int> indexes = new Dictionary<ScreenEnum, int>(){ {  ScreenEnum.ChangeOntbijt, 0  }, {  ScreenEnum.ChangeLunch, 1  }, {  ScreenEnum.ChangeDiner, 2  }, {  ScreenEnum.ChangeKinder, 3  }, { ScreenEnum.ChangeDranken, 4 }};
        static List<ScreenEnum> current = new List<ScreenEnum>() { ScreenEnum.ChangeOntbijt, ScreenEnum.ChangeLunch, ScreenEnum.ChangeDiner, ScreenEnum.ChangeKinder, ScreenEnum.ChangeDranken };
        static List<ScreenEnum> previous = new List<ScreenEnum>() { ScreenEnum.OntbijtAdmin, ScreenEnum.LunchAdmin, ScreenEnum.DinerAdmin, ScreenEnum.KinderAdmin, ScreenEnum.DrankenAdmin };

        private static bool Search(string search, int menu)
        {
            //kijk of het een geldige item is
            foreach (var parts in MenuRegister.menuregister[menu].Item1.menuparts)
            {
                foreach (var item in parts.menuitems)
                {
                    if (item.name.Equals(search))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static void Exit(string exit)
        {
                Program.onScreen = previous[current.IndexOf(Program.onScreen)];
                Program.display.controls.Clear();
                Program.display.ResizeDisplay(80, 9);
        }

        static string HandleInput()
        {
            //instructies
            Console.WriteLine("Voer de naam in van het Menu Item");
            //lees input in
            return Console.ReadLine();
        }

        static void EditPrice(string item, int menu)
        {
            Console.Write("Voer de nieuwe prijs in honderdtallen in (voorbeeld: €3 => 300): ");
            string prijs = Console.ReadLine();
            while (!int.TryParse(prijs, out _))
            {
                Console.Write("Voer de nieuwe prijs in honderdtallen in (voorbeeld: €3 => 300): ");
                prijs = Console.ReadLine();
            }

        }

        public static void Change()
        {
            int menu = indexes[Program.onScreen];

            bool validitem = false;
            bool exit = false;
            //menuitem aanpassen
            string input = "";
            while (!validitem && !exit)
            {
                input = HandleInput();
                validitem = Search(input, menu);
            }
        }
        
    }


}