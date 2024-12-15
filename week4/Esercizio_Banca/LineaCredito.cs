using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace Bank
// {
//     internal abstract class LineaCredito : BankAccount
//     {
//       public override void  PerformMonthEndTransactions() 
//         {
//             if (base.Balance < 0)
//             {
//                 base.Balance -= (Balance * 0.02m);
//             }
//         }

//     }
// }

namespace Bank {
    internal class LineaCredito : BankAccount {

        public LineaCredito (string accountNumber, string accountOwners, decimal balance, List<Transaction> transactions) : base (accountNumber, accountOwners, balance, transactions) {
        
        }
        public override bool IsLineaCredito { get => true; }

        public override void PerformMonthEndTransactions() {
            if (Balance < 0) {
                Balance -= (Balance * 0.02m);
            }
        }
    }
}
