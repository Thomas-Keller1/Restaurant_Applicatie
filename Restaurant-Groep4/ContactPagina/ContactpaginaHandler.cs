using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Restaurant_Groep4.Contactpagina
{
    public class ContactpaginaHandler
    {
        public List<Contactpagina> ContactPagina { get; set; }

        public ContactpaginaHandler()
        {

            ContactPagina = new List<Contactpagina>();
            ContactPagina.Add(new Contactpagina("Our Restaurant", "contact@Restaurant.nl", "0031657484333", "11:00_00:00", "Aalscholverlaan, 3232RR Rotterdam", "In ons restaurant vind je het lekkerste eten. Je hebt meer dan 20 opties, je kunt ook de tijd selecteren die je wilt en ook de plaats waar je wilt zitten." , "Veelgestelde vragen: .Hoe kan ik een plaats reserveren?          .Is het mogelijk om de reservering te annuleren of te wijzigen? Voor meer informatie kunt u contact met ons opnemen :)"));
            LoadFromJson();
        }
        private void LoadFromJson()
        {
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            dir += "Json\\Contactpagina\\contactpage.json";
            string jsonstring = File.ReadAllText(dir);

            using (JsonDocument document = JsonDocument.Parse(jsonstring))
            {

                JsonElement root = document.RootElement;
                if (root.TryGetProperty("ContactPagina", out JsonElement ContactPaginaElement))
                {

                    List<Contactpagina> Allinfo = new List<Contactpagina>();

                    foreach (JsonElement ContactpaginaElement in ContactPaginaElement.EnumerateArray())
                    {

                        if (ContactpaginaElement.TryGetProperty("Bedrijfsnaam", out JsonElement BedrijfsnaamElement) && ContactpaginaElement.TryGetProperty("Email", out JsonElement EmailElement) &&
                            ContactpaginaElement.TryGetProperty("TelefoonNummer", out JsonElement TelefoonnummerElement) && ContactpaginaElement.TryGetProperty("Openingstijden", out JsonElement OpeningstijdenElement) &&
                            ContactpaginaElement.TryGetProperty("Locatie", out JsonElement LocatieElement) && ContactpaginaElement.TryGetProperty("OverOns", out JsonElement OveronsElement) && ContactpaginaElement.TryGetProperty("KlantenService", out JsonElement KlantenserviceElement))
                       

                            Allinfo.Add(new Contactpagina(BedrijfsnaamElement.GetString(), EmailElement.GetString(), TelefoonnummerElement.GetString(), OpeningstijdenElement.GetString(), LocatieElement.GetString(), OveronsElement.GetString(), KlantenserviceElement.GetString()));
                        

                    }
                        ContactPagina = Allinfo;
                }
            }
        }
    }
}
