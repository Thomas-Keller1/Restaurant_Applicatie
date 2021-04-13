using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4;
using Restaurant_Groep4.Menu;
using Restaurant_Groep4.Screens;

namespace Restaurant_Groep4.Misc {
    class ControlHandler {

        public static bool IsInputValid() {
            if (String.IsNullOrEmpty(Program.UserInput)) {                                                                                                      
                Console.WriteLine("Invalid input: no input was given");
                return false;
            }
            if (Int32.TryParse(Program.UserInput, out int userinputasint)) {
                if (userinputasint > Program.display.controls.Count) {
                    Console.WriteLine("Invalid input: input number is higher then available input");
                    return false;
                }
                else if (userinputasint < 1) {
                    Console.WriteLine("Invalid input: input number has to be higher then or equal to 1");
                    return false;
                }

            }
            else {
                Console.WriteLine("Invalid input: only numbers can be given as input");
                return false;
            }
            return true;
        }

        public static void HandleInput() {

            int userinputasint = Int32.Parse(Program.UserInput);
            Control ControlToBeExcecuted = Program.display.controls[userinputasint - 1];
            if (ControlToBeExcecuted.LocalSwitch) {

                for (int index = 0; index < MenuRegister.menuregister.Count; index++) {
                    if (Program.onScreen == MenuRegister.menuregister[index].Item2) {

                        if (ControlToBeExcecuted.ToDisplay == ScreenEnum.Mainmenu) {
                            MenuRegister.menuregister[index].Item1.ModifyPrivateValue(-1);
                        }
                        else if (ControlToBeExcecuted.ToDisplay == ScreenEnum.Menus) {
                            MenuRegister.menuregister[index].Item1.ModifyPrivateValue(1);
                        }
                        MenuRegister.menuregister[index].Item1.ToDisplay(Program.display);
                    }
                }
            }
            else {
                Program.onScreen = ControlToBeExcecuted.ToDisplay;
            }
        }

        public static void HandleDisplay() {

            if (Program.onScreen == ScreenEnum.Mainmenu) {

                Mainmenu.ToDisplay();
            }
            else if (Program.onScreen == ScreenEnum.Menus) {

                Menus.ToDisplay();
            }
            else if (Program.onScreen == ScreenEnum.Ontbijtmenu) {

                MenuRegister.menuregister[0].Item1.ToDisplay(Program.display);
            }
            else if (Program.onScreen == ScreenEnum.Lunchmenu) {

                MenuRegister.menuregister[1].Item1.ToDisplay(Program.display);
            }
            else if (Program.onScreen == ScreenEnum.Dinermenu) {

                MenuRegister.menuregister[2].Item1.ToDisplay(Program.display);
            }
            else if (Program.onScreen == ScreenEnum.Kindermenu) {

                MenuRegister.menuregister[3].Item1.ToDisplay(Program.display);
            }
            else if (Program.onScreen == ScreenEnum.Drankenkaart) {

                MenuRegister.menuregister[4].Item1.ToDisplay(Program.display);
            }
        }
    }
}
