using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Menu;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {
    public static class PriceChanger {

        public static void ToDisplay() {

            string str = "Menu's: \n";
            int count = 1;
            Tuple<int, int, int> indexes = new Tuple<int, int, int>(0, 0, 0);

            Program.display.ResizeDisplay(80, 0);
            Console.WriteLine($"{new string('=', 31)}Prijzen aanpassen={new string('=', 31)}\n");
            for (int i = 0; i < MenuRegister.menuregister.Count; i++) {

                IMenu menu = MenuRegister.menuregister[i].Item1;

                str += $"[{count++}] {menu.menuname} - \n";
                Program.display.AddControl(new Control(menu.menuname, ScreenEnum.Mainmenu, false));
            }
            Console.WriteLine(str + "\n");
            Console.Write("Geef het nummer van het menu dat je wil aanpassen: ");
            Program.UserInput = Console.ReadLine();
            Console.WriteLine("\n");

            while (!ControlHandler.IsInputValid()) {

                Console.Write("Geef het nummer van het menu dat je wil aanpassen: ");
                Program.UserInput = Console.ReadLine();
                Console.WriteLine("\n");

            }
            indexes = new Tuple<int, int, int>(Int32.Parse(Program.UserInput) - 1, indexes.Item2, indexes.Item3);
            count = 1;
            Program.display.ResizeDisplay(80, 0);
            IMenu choosenmenu = MenuRegister.menuregister[Int32.Parse(Program.UserInput) - 1].Item1;
            str = "MenuStukken: \n";
            foreach (MenuPart menupart in choosenmenu.menuparts) {

                str += $"[{count++}] {menupart.partname} -\n";
                Program.display.AddControl(new Control(menupart.partname, ScreenEnum.Mainmenu, false));
            }

            Console.WriteLine(str + "\n");
            Console.Write("Geef het nummer van het menustuk dat je wil aanpassen: ");
            Program.UserInput = Console.ReadLine();
            Console.WriteLine("\n");

            while (!ControlHandler.IsInputValid()) {

                Console.Write("Geef het nummer van het menustuk dat je wil aanpassen: ");
                Program.UserInput = Console.ReadLine();
                Console.WriteLine("\n");

            }
            indexes = new Tuple<int, int, int>(indexes.Item1, Int32.Parse(Program.UserInput) - 1, indexes.Item3);

            count = 1;
            Program.display.ResizeDisplay(80, 0);
            MenuPart choosenpart = choosenmenu.menuparts[Int32.Parse(Program.UserInput) - 1];
            str = "Gerechten: \n";
            foreach (MenuItem menuitem in choosenpart.menuitems) {

                str += $"[{count++}] {menuitem.name} : \t\t\t € {menuitem.price * 0.01f} -\n";
                Program.display.AddControl(new Control(menuitem.name, ScreenEnum.Mainmenu, false));
            }

            Console.WriteLine(str + "\n");
            Console.Write("Geef het nummer van het gerecht dat je wil aanpassen: ");
            Program.UserInput = Console.ReadLine();
            Console.WriteLine("\n");

            while (!ControlHandler.IsInputValid()) {

                Console.Write("Geef het nummer van het gerecht dat je wil aanpassen: ");
                Program.UserInput = Console.ReadLine();
                Console.WriteLine("\n");

            }

            indexes = new Tuple<int, int, int>(indexes.Item1, indexes.Item2, Int32.Parse(Program.UserInput) - 1);

            Program.display.ResizeDisplay(80, 0);
            MenuItem choosenitem = choosenpart.menuitems[Int32.Parse(Program.UserInput) - 1];
            Console.WriteLine($"{choosenitem.name} \t\t {choosenitem.price * 0.01} \n\n");

            Console.Write("Geef de nieuwe prijs voor het gerecht in centen: ");
            Program.UserInput = Console.ReadLine();
            Console.WriteLine("\n");

            bool validinput = (!String.IsNullOrEmpty(Program.UserInput)) && Int32.TryParse(Program.UserInput, out int userinputasint);
            int newprice = validinput ? Int32.Parse(Program.UserInput) : 0;

            while (!validinput) {

                Console.Write("Geef de nieuwe prijs voor het gerecht in centen: ");
                Program.UserInput = Console.ReadLine();
                Console.WriteLine("\n");
                validinput = (!String.IsNullOrEmpty(Program.UserInput)) && Int32.TryParse(Program.UserInput, out int auserinputasint);
                newprice = validinput ? Int32.Parse(Program.UserInput): 0;
            }

            Console.WriteLine($"De prijs van {choosenitem.name} is succesvol gewijzigd van {choosenitem.price} naar {newprice}");

            MenuRegister.menuregister[indexes.Item1].Item1.menuparts[indexes.Item2].menuitems[indexes.Item3].price = newprice;
            MenuRegister.menuregister[indexes.Item1].Item1.SaveToJSONFirstTime();

            Program.onScreen = ScreenEnum.AdminManager;
            Screens.AdminManager.ToDisplay();

            Program.display.AddControl(new Control("Terug", ScreenEnum.AdminManager, false));
        }
    }
}
