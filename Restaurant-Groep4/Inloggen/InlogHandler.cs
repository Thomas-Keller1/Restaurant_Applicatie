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
            // GetAccountContents();
        }
        public void AddAccount(Account _account)
        {
            Account.Add(_account);
            //SaveAccount();
        }
    }
}
