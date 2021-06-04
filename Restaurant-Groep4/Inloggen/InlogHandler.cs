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
        public List<Account> Account { get; set; }
        public Account LoggedInUser { get; set; }

        public InlogHandler()
        {
            Account = JsonSerializer.Deserialize<List<Account>>(File.ReadAllText("./Json/Accounts/Accounts.json"));
        }
        public void AddAccount(Account _account)
        {
            Account.Add(_account);
            File.WriteAllText("./Json/Accounts/Accounts.json", JsonSerializer.Serialize(this.Account, new JsonSerializerOptions { WriteIndented = true }));
        }

        public bool Login(string username, string password)
        {
            foreach (Account account in this.Account)
            {
                if (account.Naam == username && account.Wachtwoord == password)
                {
                    this.LoggedInUser = account;
                    return true;
                }
            }
            return false;
        }
    }
}