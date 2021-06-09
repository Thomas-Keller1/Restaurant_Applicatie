using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Menu {

    public class MultiPageMenu : IMenu {

        public List<MenuPart> menuparts {get; set;}
        public string menuname {get; set;}

        private int partsperpage;
        private int onpage;
        private int pagecount;

        public MultiPageMenu(string _menuname, List<MenuPart> _menuparts, int _partsperpage) {

            menuname = _menuname;
            menuparts = _menuparts;
            partsperpage = _partsperpage;
            pagecount = _menuparts.Count / partsperpage;
            onpage = 1;
        }

        public MultiPageMenu(string _menuname, int _partsperpage) {

            partsperpage = _partsperpage;
            onpage = 1;
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            dir += "Json\\MenuData\\" + _menuname + ".json";
            loadFromJson(File.ReadAllText(dir));
        }

        public void SaveToJSON() {

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
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
                                && menuitem.TryGetProperty("vegan", out JsonElement VeganElement)) {

                                    tempListMenuItems.Add(new MenuItem(NameElement.GetString(), PriceElement.GetInt32(), DescriptionElement.GetString(), VegetarianElement.GetBoolean(), VeganElement.GetBoolean()));
                                }
                            }
                        }

                        tempListMenuParts.Add(new MenuPart(PartnameElement.GetString(), tempListMenuItems));
                    }
                    menuparts = tempListMenuParts;
                    pagecount = menuparts.Count / partsperpage;
                }
            }
        }

        public void ToDisplay(Display.Display display, bool admin = false) {

            int count = 1;
            int currentY = 0;
            int temp = (display.displaybuffer.DisplayWidth / 2) - menuname.Length / 2;
            string tempstring = $"{new string('=', temp)}{menuname}{new string('=', display.displaybuffer.DisplayWidth - (temp + menuname.Length))}";
            Program.display.controls.Clear();

            //display.displaybuffer.EmptyBuffer();
            display.displaybuffer.ResizeDisplayBuffer(display.displaybuffer.DisplayWidth, LinesNeeded());
            display.AddString(0, currentY, tempstring);

            currentY += 2;
            foreach (MenuPart menupart in menuparts) {

                if (count <= onpage * partsperpage && count > (onpage - 1) * partsperpage) {

                    display.AddString(0, currentY, menupart.partname);
                    currentY++;
                    display.AddString(0, currentY, new string('-', display.displaybuffer.DisplayWidth));
                    currentY += 2;

                    foreach (MenuItem menuitem in menupart.menuitems) {

                        display.AddString(0, currentY, menuitem.name);
                        display.AddString(display.displaybuffer.DisplayWidth - 6, currentY, $"€{(int)menuitem.price / 100}.{(int)menuitem.price % 100}");
                        if (menuitem.vegetarian) {
                            display.AddCharacter(display.displaybuffer.DisplayWidth - 10, currentY, 'V');
                        }
                        if (menuitem.vegan) {
                            display.AddCharacter(display.displaybuffer.DisplayWidth - 8, currentY, 'v');
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
                    }
                }
                count++;
            }

            currentY++;
            display.AddString(0, currentY, new string('=', display.displaybuffer.DisplayWidth));
            display.AddControl(new Control("Terug", ScreenEnum.Menus, false));
            if (onpage > 1) {
                display.AddControl(new Control("Vorige pagina", ScreenEnum.Mainmenu, true));
            }
            if (onpage < pagecount) {
                display.AddControl(new Control("Volgende pagina", ScreenEnum.Menus, true));
            }

            if (admin)
            {
                if (Program.onScreen == ScreenEnum.LunchAdmin)
                {
                    display.AddControl(new Control("Verander Prijs", ScreenEnum.ChangeLunch, false));
                }
                else if (Program.onScreen == ScreenEnum.DinerAdmin)
                {
                    display.AddControl(new Control("Verander Prijs", ScreenEnum.ChangeDiner, false));
                }
            }
        }

        public int LinesNeeded() {
            int count = 1;
            int result = 2;

            foreach (MenuPart menupart in menuparts) {

                if (count <= onpage * partsperpage && count > (onpage - 1) * partsperpage) {

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
                count++;
            }
            return result + 2;
        }

        public void ModifyPrivateValue(int modifier) {
            onpage += modifier;
        }

    }
}
