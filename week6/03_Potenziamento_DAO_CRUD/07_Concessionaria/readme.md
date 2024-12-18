# LATO DATABASE
- Creare un Database Concessionaria;

- Creare la tabella Prodotti, con:
     int id, varchar categoria, varchar marca, varchar modello, bit affittabile,
     int annoImmatricolazione, int consumoMedioAKM, int capienzaSerbatoio

- Creare la tabella Automobili, con:
    int id, int cilindrata, int velocitaMax, int postiAuto

- Creare la tabella Moto, con:
    int id, bit passeggeri

## Come si collegheranno le auto e le moto a prodotti?
Assicuratevi la giusta relazione e le giuste impostazioni sulle FK.
Riempite poi le 3 tabelle con dei dati


# LATO C#
Sfruttate il progetto Utility, come con gli esercizi precedenti

- Creare una classe Prodotto, figlia di Entity, con i metodi:
    - double Prezzo() → Calcolo a vostro piacimento in base alla categoria
    - boolean Famoso() → Ritorna true se la marca è: Rolls Royce, Ferrari, Ducati o Harley Davidson
    - double  KMPercorribili() → Calcola quanti km posso percorrere con il carburante a disposizione
    - double AffittoMensile() → Se "affittabile" è TRUE, partendo da un prezzo di affitto pari al 40% del prezzo di vendita originale(considerate questo prezzo come il totale annuo), calcolare quanto costa al mese affittare la macchina
    - int Eta() → Calcola gli anni trascorsi da quando è stata immatricolata la macchina

- Creare una classe Automobile, figlia di Prodotto, con i metodi:
    - boolean Potente() → Ritorna true se ciclindrata è maggiore di 2000 e famoso() vale true

- Creare una classe Moto, figlia Prodotto, con i metodi:
    - boolean InCompagnia() → Ritorna true se può avere passeggeri e può percorrere almeno 100km

- Creare un interfaccia dove saranno salvate le firme dei metodi CRUD delle classi DAOProdotti, DAOAutomobili e DAOMoto e i metodi scritti di seguito.

- Creare poi i seguenti metodi nelle giuste classi DAO:
    - List<Prodotto> ListaProdottiVecchi() → Ritorna la lista dei prodotti immatricolati da almeno 8 anni
    - string MaxDistanza() → Ritorna le schede dei mezzi che possono fare più km (Sia macchine che moto)
    - List<Automobile> AutoSuper() → Ritorna tutte le auto con potente() uguale a true
    - List<Moto> Sportive() → Ritorna tutte le moto che non hanno passeggeri
    - List<Prodotto> Cerca(string categoria) → Ritorna tutti i mezzi che appartengono alla categoria cercata (ESEMPIO: cerca(“auto”) → Lista di tutte le auto a disposizione)
    - Dictionary<string,int> frequenza() → Ritorna un dictionary con la frequenza per categoria (es: Moto:2, Automobile:4)
    - string CercaPerMarca(string marca) → Ritorna le schede di tutti i mezzi della marca ricercata(sia macchine che moto)
    - string StampaListe(List<Prodotto> array) → Stampa in maniera ordinata un array di elementi di tipo Prodotto
    - List<Prodotto> TrovaSoluzione(double budgetMensile, int passeggeri) → Ritorna una lista di mezzi che si possono affittare con il budget mensile e il numero di passeggeri passati come parametri
    - List<Automobile> Veloci() → Ritorna tutte le auto con la velocità più alta
    - List<Prodotto> InOrdine() → Ritornare la lista ordinata per prezzo dei mezzi (dal meno costoso al più caro, indipendentemente dal tipo di mezzo)

- Scrivere una classe di avvio Program dove creare un menù che permetta all’utente di usare i metodi creati prima