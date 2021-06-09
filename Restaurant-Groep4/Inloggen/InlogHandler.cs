using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;


namespace Restaurant_Groep4.Inloggen
{
    public class InlogHandler
    {
        public List<Account> Accounts { get; set; }

        public InlogHandler()
        {
            Accounts = new List<Account>();
            GetAccountContents();
        }

        public void AddAccount(Account _account)
        {
            Accounts.Add(_account);
            SaveAccount();
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
                           AccountsElement.TryGetProperty("Naam", out JsonElement NaamElement) && AccountsElement.TryGetProperty("Email", out JsonElement EmailElement) && AccountsElement.TryGetProperty("TelefoonNummer", out JsonElement TelefoonnummerElement) && AccountsElement.TryGetProperty("Admin", out JsonElement AdminElement)) {

                            TempListAccount.Add(new Account(GebruikersNaamElement.GetString(), WachtwoordElement.GetString(), NaamElement.GetString(), EmailElement.GetString(), TelefoonnummerElement.GetString(), AdminElement.GetBoolean()));
                        }
                    }
                    Accounts = TempListAccount;
                }
            }
        }
        public void SaveAccount()
        {

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonstring = JsonSerializer.Serialize(this, options);
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            File.WriteAllText(dir + "Json\\Accounts\\" + "Accounts" + ".json", jsonstring);
        }
    }

}