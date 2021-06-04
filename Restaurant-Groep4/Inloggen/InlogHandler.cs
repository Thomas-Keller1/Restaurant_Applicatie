using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;


namespace Restaurant_Groep4.Inloggen
{
    class InlogHandler
    {
        public List<Account> Account { get; set; }

        public InlogHandler()
        {
            Account = new List<Account>();
            GetAccountContents();

        }
        public void GetAccountContents()
        {

            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            dir += "Json\\Accounts\\" + "Accounts" + ".json";
            string jsonstring = File.ReadAllText(dir);

            using (JsonDocument document = JsonDocument.Parse(jsonstring))
            {

                JsonElement root = document.RootElement;

                if (root.TryGetProperty("Accounts", out JsonElement AccountElement))
                {

                    List<Account> TempListAccount = new List<Account>();

                    foreach (JsonElement AccountsElement in AccountElement.EnumerateArray())
                    {

                        if (AccountsElement.TryGetProperty("GebruikersNaam", out JsonElement GebruikersNaamElement) && AccountsElement.TryGetProperty("Wachtwoord", out JsonElement WachtwoordElement) &&
                           AccountsElement.TryGetProperty("Naam", out JsonElement NaamElement) && AccountsElement.TryGetProperty("Email", out JsonElement EmailElement));

                    }
                    Account = TempListAccount;
                }
            }
        }
        private void SaveAccount()
        {

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonstring = JsonSerializer.Serialize(this, options);
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            File.WriteAllText(dir + "Json\\Accounts\\" + "Accounts" + ".json", jsonstring);
        }
    }
}