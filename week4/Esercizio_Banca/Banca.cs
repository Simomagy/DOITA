using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Banca
    {

        public List<BankAccount> accounts;
        List<String> strings;

        public Banca(string path)
        {
            accounts = new List<BankAccount>();
            Inizio(path);
        }
        private void Inizio(string path)
        {
            string[] file = File.ReadAllLines(path);

            string accountData = string.Empty;

            foreach (string line in file)
            {

                accountData += line + ";";

                BankAccount account = new BankAccount();
                account.CreateAccount(accountData, false);
                accounts.Add(account);

                accountData = string.Empty;
            }
        }

        public void AddAccount(BankAccount account)
        {
            accounts.Add(account);
        }

        public string StampaInfo(string accountNumber)
        {
            foreach (BankAccount account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return $"Numero account: {account.AccountNumber}\nSaldo: {account.Balance}";
                }
            }
            return "Account non trovato";
        }
    }
}
