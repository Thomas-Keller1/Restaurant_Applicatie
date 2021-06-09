using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Menu {

    public class SinglePageMenu : IMenu {


        //Eigen code snippets bestand maken voor 1 juni

        public List<MenuPart> menuparts {get; set;}
        public string menuname {get; set;}

        public SinglePageMenu(string _menuname, List<MenuPart> _menuparts) {

            menuname = _menuname;
            menuparts = _menuparts;
            //menuparts.Add(_menupart);
            //SaveToJSONFirstTime();
        }

        public SinglePageMenu(string _menuname) {
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            dir += "Json\\MenuData\\" + _menuname + ".json";
            loadFromJson(File.ReadAllText(dir));
        }

        public void SaveToJSONFirstTime() {
            JsonSerializerOptions options = new JsonSerializerOptions {WriteIndented = true};
            string jsonstring = JsonSerializer.Serialize(this, options);
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            File.WriteAllText(dir + "Json\\MenuData\\" + menuname + ".json", jsonstring);
        }
        private void loadFromJson(string _jsonstring) {

            using (JsonDocument document = JsonDocument.Parse(_jsonstring)) {

                JsonElement root = document.RootElement;

                if (root.TryGetProperty("menuname", out JsonElement MenunameElement) && root.TryGetProperty("menuparts", out JsonElement MenupartsElement)) {

                    menuname = MenunameElement.GetString();

                    List<MenuPart> tempListMenuParts = new List<MenuPart>();

                    foreach (JsonElement menupart in MenupartsElement.EnumerateArray()) {

                        List<MenuItem> tempListMenuItems = new List<MenuItem>();

                        if (menupart.TryGetProperty("partname", out JsonElement PartnameElement) && menupart.TryGetProperty("menuitems", out JsonElement MenuitemsElement)) {

                            foreach (JsonElement menuitem in MenuitemsElement.EnumerateArray()) {

                                if (menuitem.TryGetProperty("name", out JsonElement NameElement) && menuitem.TryGetProperty("price", out JsonElement PriceElement)
                                && menuitem.TryGetProperty("description", out JsonElement DescriptionElement) && menuitem.TryGetProperty("vegetarian", out JsonElement VegetarianElement)
                                && menuitem.TryGetProperty("vegan", out JsonElement VeganElement) && menuitem.TryGetProperty("gluten", out JsonElement GlutenElement) && menuitem.TryGetProperty("zuivel", out JsonElement ZuivelElement)
                                && menuitem.TryGetProperty("noten", out JsonElement NotenElement) && menuitem.TryGetProperty("dieren", out JsonElement DierenElement)) {

                                    tempListMenuItems.Add(new MenuItem(NameElement.GetString(), PriceElement.GetInt32(), DescriptionElement.GetString(), VegetarianElement.GetBoolean(), VeganElement.GetBoolean(), GlutenElement.GetBoolean(), ZuivelElement.GetBoolean(), NotenElement.GetBoolean(), DierenElement.GetBoolean()));
                                }
                            }
                        }

                        tempListMenuParts.Add(new MenuPart(PartnameElement.GetString(), tempListMenuItems));
                    }
                    menuparts = tempListMenuParts;
                }
            }
        }

        public void ToDisplay(Display.Display display) {

            int currentY = 0;
            int temp = (display.displaybuffer.DisplayWidth / 2) - menuname.Length / 2;
            string tempstring = $"{new string('=', temp)}{menuname}{new string('=', display.displaybuffer.DisplayWidth - (temp + menuname.Length))}";
            Program.display.controls.Clear();

            //display.displaybuffer.EmptyBuffer();
            display.ResizeDisplay(display.displaybuffer.DisplayWidth, LinesNeeded());
            display.AddString(0, currentY, tempstring);
            currentY++;
            Program.display.AddString(0, currentY, x => (x.Email == null ? $"Not logged in!" : $"Logged in with account: {x.GebruikersNaam}"), ConsoleColor.White);

            currentY += 2;
            foreach (MenuPart menupart in menuparts) {

                display.AddString(0, currentY, menupart.partname);
                currentY++;
                display.AddString(0, currentY, new string('-', display.displaybuffer.DisplayWidth));
                currentY += 2;

                foreach (MenuItem menuitem in menupart.menuitems) {
                    display.AddString(0, currentY, menuitem.name);
                    display.AddString(display.displaybuffer.DisplayWidth - 6, currentY, $"€{(int)menuitem.price / 100}.{(int)menuitem.price % 100}");
                    if (menuitem.vegetarian) {
                        display.AddCharacter(display.displaybuffer.DisplayWidth - 10, currentY, 'V', ConsoleColor.DarkGreen);
                    }
                    if (menuitem.vegan) {
                        display.AddCharacter(display.displaybuffer.DisplayWidth - 8, currentY, 'v', ConsoleColor.Green);
                    }
                    if (menuitem.gluten) {
                        display.AddCharacter(display.displaybuffer.DisplayWidth - 16, currentY, 'G', ConsoleColor.Yellow);
                    }
                    if (menuitem.zuivel) {
                        display.AddCharacter(display.displaybuffer.DisplayWidth - 14, currentY, 'Z', ConsoleColor.Cyan);
                    }
                    if (menuitem.noten) {
                        display.AddCharacter(display.displaybuffer.DisplayWidth - 12, currentY, 'N', ConsoleColor.DarkRed);
                    }
                    if (menuitem.dieren) {
                        display.AddCharacter(display.displaybuffer.DisplayWidth - 10, currentY, 'D', ConsoleColor.Magenta);
                    }
                    currentY++;
                    display.AddString(2, currentY, menuitem.description);
                    if (menuitem.description.Length < 78) {
                        currentY += 2;
                    }
                    else {
                       currentY += (int)menuitem.description.Length / 78;
                       currentY += 2;
                    }
                    //currentY += 2;
                }
            }
            currentY++;
            display.AddString(0, currentY, new string('=', display.displaybuffer.DisplayWidth));
            display.AddControl(new Control("Terug", ScreenEnum.Menus, false));
        }
        public int LinesNeeded() {
            int result = 3;

            foreach (MenuPart menupart in menuparts) {

                result += 3;
                foreach (MenuItem menuitem in menupart.menuitems) {
                    result += 2;
                    if (menuitem.description.Length < 78) {
                        result += 1;
                    }
                    else {
                        result += (int)menuitem.description.Length / 78;
                        result += 1;
                    }
                }
            }
            return result + 2;
        }

        public void ModifyPrivateValue(int modifier) {
            return;
        }

    }
}
