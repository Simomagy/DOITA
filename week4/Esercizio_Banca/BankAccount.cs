namespace Bank {
    public class BankAccount {
        // Campi privati
        string _accountNumber;
        string _accountOwners;
        decimal _balance;
        static long _lastCreated = 4200000000; // Rendi statico
        List<Transaction> _transactions = new List<Transaction>();

        public BankAccount(string accountNumber, string accountOwners, decimal balance, List<Transaction> transactions) {
            _accountNumber = accountNumber;
            _accountOwners = accountOwners;
            _balance = balance;
            _transactions = transactions;
        }

        // Proprietà pubbliche
        #region Properties

        public long LastCreated { get => _lastCreated; set => _lastCreated = value; }
        public string AccountNumber { 
            get => _accountNumber; 
            private set => _accountNumber = value; // Rendi il setter privato
        }
        public string AccountOwners { get => _accountOwners; set => _accountOwners = value; }
        public decimal Balance {
            get => CalculateBalance();
            set => _balance = value;
        }
        public virtual bool IsLineaCredito { get => false; }
        #endregion

        // Metodo per creare un nuovo account
        #region Methods
        public void CreateAccount(string clientData, bool isNewAccount)
        {
                try
                {
                    string[] fields = clientData.Split(';');
                    if (fields.Length < 6)
                    {
                        throw new Exception("Dati insufficienti per creare un account");
                    }
        
                    AccountNumber = _lastCreated.ToString();
                    _lastCreated++; // Incrementa il numero di account dopo aver creato un account
                    AccountOwners = fields[0];
                    if (decimal.Parse(fields[5]) >= 0)
                    {
                        MakeDeposit(decimal.Parse(fields[5]), DateTime.Now, "Saldo Iniziale");
                    }
                    else
                    {
                        throw new Exception("Non possibile creare account con saldo minore di 0");
                    }
                    Balance = CalculateBalance();
        
                    if (isNewAccount)
                    {
                        // Scrivi i dati dell'account nel file Dati.txt
                        
                        File.AppendAllText("../../../Dati.txt",Environment.NewLine + clientData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        

        // Metodo per effettuare un deposito
        public void MakeDeposit(decimal amount, DateTime date, string note) {
            // Scrivere nella lista Transaction i dati della transazione
            Transaction transaction = new Transaction();
            transaction.Amount = amount;
            transaction.Date = date;
            transaction.Notes = note;
            switch (amount) {
                case > 0:
                    transaction.Type = "Deposito";
                    transaction.IsValid = true;
                    break;
                case <= 0:
                    transaction.Type = "Deposito";
                    transaction.IsValid = false;
                    break;
            }
            _transactions.Add(transaction);
        }

        // Metodo per effettuare un prelievo
        public void MakeWithdrawal(decimal amount, DateTime date, string note) {
            // Scrivere nella lista Transaction i dati della transazione
            Transaction transaction = new Transaction();
            transaction.Amount = amount;
            transaction.Date = date;
            transaction.Notes = note;
            switch (amount) {
                case > 0:
                    transaction.Type = "Prelievo";
                    transaction.IsValid = true;
                    break;
                case <= 0:
                    transaction.Type = "Prelievo";
                    transaction.IsValid = false;
                    break;
            }
            _transactions.Add(transaction);
        }

        // Metodo per calcolare il saldo
        public decimal CalculateBalance() {
            // Calcola il saldo sommando tutti gli importi delle transazioni
            decimal balance = 0;
            foreach (var transaction in _transactions) {
                if (transaction.IsValid) {
                    if (transaction.Type.Contains("Deposito")) {
                        balance += transaction.Amount;
                    } else if (transaction.Type.Contains("Prelievo")) {
                        if (IsLineaCredito) {
                            balance -= transaction.Amount + 5;
                        } else if ((balance -= transaction.Amount) < 0) {
                            Console.WriteLine("Non è possibile prelevare");
                            throw new Exception("il conto andrebbe sotto 0");
                        } else {
                            balance -= transaction.Amount;
                        }
                    }
                }
            }
            return balance;
        }

        // Metodo per ottenere la cronologia delle transazioni
        public string GetAccountHistory() {
            string output = string.Empty;
            foreach (var transaction in _transactions) {
                if (transaction.IsValid) {
                    output += $"Tipo Transazione: {transaction.Type} - Data: {transaction.Date} - Importo: {transaction.Amount} - Note: {transaction.Notes}\n";
                } else {
                    output += $"Tipo Transazione: {transaction.Type} - Data: {transaction.Date} - Importo: {transaction.Amount} - Note: {transaction.Notes} - Transazione non valida\n";
                }
            }
            return output;
        }

        public virtual void PerformMonthEndTransactions() { }

        #endregion
    }
}