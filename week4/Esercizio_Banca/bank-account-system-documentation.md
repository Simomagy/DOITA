# Sistema di Gestione Conti Bancari

## Introduzione

Questo documento descrive la progettazione di un sistema di gestione conti bancari utilizzando la programmazione orientata a oggetti in C#.

## Passaggio 1: Definizione del Tipo Conto Bancario

### Proprietà del Conto Bancario

-   `Number` (string): Numero univoco del conto
-   `Owner` (string): Nome del titolare del conto
-   `Balance` (decimal): Saldo del conto

### Metodi Principali

```csharp
public void MakeDeposit(decimal amount, DateTime date, string note)
{
    // Implementazione del versamento
}

public void MakeWithdrawal(decimal amount, DateTime date, string note)
{
    // Implementazione del prelievo
}
```

## Domande Concettuali

-   Cos'è una classe?
-   Cosa sono i campi?
-   Cosa sono i metodi?
-   Cos'è un costruttore?

## Passaggio 2: Apertura del Conto Bancario

### Gestione del Numero di Conto

-   Utilizzo di un campo statico `s_accountNumberSeed` per generare numeri di conto univoci
-   Incremento automatico per ogni nuovo conto
-   Convenzione di denominazione: `s_` per campi statici privati

### Assegnazione Numero di Conto nel Costruttore

```csharp
Number = s_accountNumberSeed.ToString();
s_accountNumberSeed++;
```

## Passaggio 3: Gestione delle Transazioni

### Classe Transaction

```csharp
class Transaction
{
    decimal Amount { get; }
    DateTime Date { get; }
    string Notes { get; }

    Transaction(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Notes = note;
    }
}
```

### Calcolo del Saldo

-   Somma di tutte le transazioni
-   Calcolo dinamico del saldo

### Regole Implementate

1. Saldo iniziale deve essere positivo
2. Prelievi non possono causare saldo negativo

## Tipi di Conti Bancari Aggiuntivi

### Tipi di Conti Proposti

1. **Conto Utili di Interesse**

    - Accumulo del 2% del saldo di fine mese

2. **Linea di Credito**

    - Saldo negativo consentito entro un limite
    - Addebito di interessi mensili
    - Commissioni per prelievi oltre il limite

3. **Conto Carta Regalo**
    - Ricaricabile una volta al mese
    - Ultimo giorno del mese

### Polimorfismo

-   Metodo virtuale `PerformMonthEndTransactions()`
-   Implementazioni specifiche per ogni tipo di conto

## Modifiche alla Classe Base BankAccount

### Nuovo Costruttore

-   Aggiunta parametro `minimumBalance`
-   Utilizzo di `readonly` per impedire modifiche dopo la costruzione
-   Gestione flessibile dell'inizializzazione del conto

## Aggregatore Banca

### Interfaccia IBank

Funzionalità per il cliente:

-   Visualizzazione dati del conto
-   Verifica saldo
-   Visualizzazione movimenti
-   Versamento
-   Prelievo

---

## Considerazioni Finali

-   Implementazione flessibile e estendibile
-   Supporto per diversi tipi di conti bancari
-   Gestione dinamica delle transazioni
