using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal abstract class CartaRegalo : BankAccount
    {

    public CartaRegalo (string accountNumber, string accountOwners, decimal balance, List<Transaction> transactions) : base (accountNumber, accountOwners, balance, transactions) {
        
    }

    public override void PerformMonthEndTransactions() 
        {
            base.Balance += 100;

        }
    }
}
