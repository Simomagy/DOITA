using Utility;
public class MenuManagment
{
    #region Fields
    private static DAOProdotto daoProdotto = DAOProdotto.GetInstance();
    private static DAOAutomobile daoAutomobile = DAOAutomobile.GetInstance();
    private static DAOMoto daoMoto = DAOMoto.GetInstance();
    #endregion
    #region Menu
    public static void Menu()
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Ottieni tutti i prodotti");
            Console.WriteLine("2. Crea un nuovo prodotto");
            Console.WriteLine("3. Aggiorna un prodotto");
            Console.WriteLine("4. Elimina un prodotto");
            Console.WriteLine("5. Trova un prodotto per ID");
            Console.WriteLine("6. Ottieni prodotti vecchi");
            Console.WriteLine("7. Trova per categoria");
            Console.WriteLine("8. Stampa tutti i prodotti per marca");
            Console.WriteLine("9. Trova soluzione");
            Console.WriteLine("10. Stampa prodotti in ordine crescente per prezzo");
            Console.WriteLine("11. Stampa prodotti per distanza massima");
            Console.WriteLine("0. Esci");


            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GetAllProducts();
                    break;
                case "2":
                    CreateProduct();
                    break;
                case "3":
                    UpdateProduct();
                    break;
                case "4":
                    DeleteProduct();
                    break;
                case "5":
                    FindProductById();
                    break;
                case "6":
                    GetOldProducts();
                    break;
                case "7":
                    FindByCategory();
                    break;
                case "8":
                    PrintByBrand();
                    break;
                case "9":
                    FindSolution();
                    break;
                case "10":
                    PrintInOrder();
                    break;
                case "11":
                    PrintByMaxDistance();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Scelta non valida. Per favore riprova.");
                    break;
            }
        }
    }
    #endregion
    #region CRUD Methods
    private static void GetAllProducts()
    {
        var entities = daoProdotto.GetRecords();
        PrintList(entities);
    }

    private static void CreateProduct()
    {
        Console.Write("Inserisci il tipo di prodotto (1 per Automobile, 2 per Moto): ");
        int type = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            Console.Write("Inserisci la Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Inserisci il Modello: ");
            string modello = Console.ReadLine();
            Console.Write("Inserisci la Categoria: ");
            string categoria = Console.ReadLine();
            Console.Write("Inserisci l'Anno Immatricolazione: ");
            int anno = int.Parse(Console.ReadLine());
            Console.Write("Inserisci la Cilindrata: ");
            int cilindrata = int.Parse(Console.ReadLine());
            Console.Write("Inserisci la Velocita Max: ");
            int velocitaMax = int.Parse(Console.ReadLine());
            Console.Write("Inserisci i Posti Auto: ");
            int postiAuto = int.Parse(Console.ReadLine());
            Console.Write("Affittabile? (true/false): ");
            bool affittabile = bool.Parse(Console.ReadLine());
            Console.Write("Inserisci il Consumo Medio A KM: ");
            int consumoMedioAKM = int.Parse(Console.ReadLine());  
            Console.Write("Inserisci la Capienza Serbatoio: ");
            int capienzaSerbatoio = int.Parse(Console.ReadLine()); 

            var auto = new Automobile
            {
                Marca = marca,
                Modello = modello,
                Categoria = categoria,
                AnnoImmatricolazione = anno,
                Cilindrata = cilindrata,
                VelocitaMax = velocitaMax,
                PostiAuto = postiAuto,
                Affittabile = affittabile,
                ConsumoMedioAKM = consumoMedioAKM,
                CapienzaSerbatoio = capienzaSerbatoio
            };

            double prezzo = auto.Prezzo();

            daoAutomobile.CreateRecord(auto);
        }
        else if (type == 2)
        {
            Console.Write("Inserisci la Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Inserisci il Modello: ");
            string modello = Console.ReadLine();
            Console.Write("Inserisci la Categoria: ");
            string categoria = Console.ReadLine();
            Console.Write("Inserisci l'Anno Immatricolazione: ");
            int anno = int.Parse(Console.ReadLine());
            Console.Write("Passeggeri? (true/false): ");
            bool passeggeri = bool.Parse(Console.ReadLine());
            Console.Write("Affittabile? (true/false): ");
            bool affittabile = bool.Parse(Console.ReadLine());
            Console.Write("Inserisci il Consumo Medio A KM: ");
            int consumoMedioAKM = int.Parse(Console.ReadLine()); 
            Console.Write("Inserisci la Capienza Serbatoio: ");
            int capienzaSerbatoio = int.Parse(Console.ReadLine()); 

            var moto = new Moto
            {
                Marca = marca,
                Modello = modello,
                Categoria = categoria,
                AnnoImmatricolazione = anno,
                Passeggeri = passeggeri,
                Affittabile = affittabile,
                ConsumoMedioAKM = consumoMedioAKM,
                CapienzaSerbatoio = capienzaSerbatoio
            };

            double prezzo = moto.Prezzo();

            daoMoto.CreateRecord(moto);
        }
        else
        {
            Console.WriteLine("Tipo pprodotto non valido.");
        }
    }

    private static void UpdateProduct()
    {
        Console.Write("Inserisci l'ID del Prodotto da aggiornare: ");
        int id = int.Parse(Console.ReadLine());

        var product = daoProdotto.FindRecord(id);
        if (product == null)
        {
            Console.WriteLine("Prodotto non trovato.");
            return;
        }

        if (product is Prodotto prodotto)
        {
            Console.WriteLine("Lascia il campo vuoto per mantenere il valore attuale.");

            Console.Write($"Inserisci la Marca ({prodotto.Marca}): ");
            string marca = Console.ReadLine();
            if (!string.IsNullOrEmpty(marca)) prodotto.Marca = marca;

            Console.Write($"Inserisci il Modello ({prodotto.Modello}): ");
            string modello = Console.ReadLine();
            if (!string.IsNullOrEmpty(modello)) prodotto.Modello = modello;

            Console.Write($"Inserisci la Categoria ({prodotto.Categoria}): ");
            string categoria = Console.ReadLine();
            if (!string.IsNullOrEmpty(categoria)) prodotto.Categoria = categoria;

            Console.Write($"Inserisci l'Anno Immatricolazione ({prodotto.AnnoImmatricolazione}): ");
            string anno = Console.ReadLine();
            if (!string.IsNullOrEmpty(anno)) prodotto.AnnoImmatricolazione = int.Parse(anno);

            Console.Write($"Affittabile? ({prodotto.Affittabile}): ");
            string affittabile = Console.ReadLine();
            if (!string.IsNullOrEmpty(affittabile)) prodotto.Affittabile = bool.Parse(affittabile);

            Console.Write($"Inserisci il Consumo Medio A KM ({prodotto.ConsumoMedioAKM}): ");
            string consumoMedioAKM = Console.ReadLine();
            if (!string.IsNullOrEmpty(consumoMedioAKM)) prodotto.ConsumoMedioAKM = int.Parse(consumoMedioAKM);

            Console.Write($"Inserisci la Capienza Serbatoio ({prodotto.CapienzaSerbatoio}): ");
            string capienzaSerbatoio = Console.ReadLine();
            if (!string.IsNullOrEmpty(capienzaSerbatoio)) prodotto.CapienzaSerbatoio = int.Parse(capienzaSerbatoio);

            if (prodotto is Automobile auto)
            {
                Console.Write($"Inserisci la Cilindrata ({auto.Cilindrata}): ");
                string cilindrata = Console.ReadLine();
                if (!string.IsNullOrEmpty(cilindrata)) auto.Cilindrata = int.Parse(cilindrata);

                Console.Write($"Inserisci la Velocita Max ({auto.VelocitaMax}): ");
                string velocitaMax = Console.ReadLine();
                if (!string.IsNullOrEmpty(velocitaMax)) auto.VelocitaMax = int.Parse(velocitaMax);

                Console.Write($"Inserisci i Posti Auto ({auto.PostiAuto}): ");
                string postiAuto = Console.ReadLine();
                if (!string.IsNullOrEmpty(postiAuto)) auto.PostiAuto = int.Parse(postiAuto);

                daoAutomobile.UpdateRecord(auto);
            }
            else if (prodotto is Moto moto)
            {
                Console.Write($"Passeggeri? ({moto.Passeggeri}): ");
                string passeggeri = Console.ReadLine();
                if (!string.IsNullOrEmpty(passeggeri)) moto.Passeggeri = bool.Parse(passeggeri);

                daoMoto.UpdateRecord(moto);
            }
            else
            {
                daoProdotto.UpdateRecord(prodotto);
            }

            Console.WriteLine("Prodotto aggiornato con successo.");
        }
        else
        {
            Console.WriteLine("Il prodotto non è del tipo corrente.");
        }
    }

    private static void DeleteProduct()
    {
        Console.Write("Inserisci l'ID del Prodotto da eliminare: ");
        int id = int.Parse(Console.ReadLine());

        if (daoProdotto.DeleteRecord(id))
        {
            Console.WriteLine("Prodotto eliminato con successo.");
        }
        else
        {
            Console.WriteLine("Errore nell'eliminazione del prodotto.");
        }
    }
    #endregion
    #region Query Methods
    private static void FindProductById()
    {
        Console.Write("Inserisci l'ID del Prodotto: ");
        int id = int.Parse(Console.ReadLine());
        var product = daoProdotto.FindRecord(id);
        Console.WriteLine(product?.ToString() ?? "Prodotto non trovato.");
    }
    private static void FindSolution()
    {
        Console.Write("Inserisci il Budget mensile: ");
        double monthlyBudget = double.Parse(Console.ReadLine());
        double annualBudget = monthlyBudget * 12;  
        Console.Write("Inserisci il numero di passeggeri: ");
        int passengers = int.Parse(Console.ReadLine());

        var automobileSolutions = daoAutomobile.TrovaSoluzione(annualBudget, passengers);
        var motoSolutions = daoMoto.TrovaSoluzione(annualBudget, passengers);

        Console.WriteLine("Soluzioni Automobile:");
        PrintList(automobileSolutions.Cast<Utility.Entity>().ToList());

        Console.WriteLine("Soluzioni Moto:");
        PrintList(motoSolutions.Cast<Utility.Entity>().ToList());
    }
    private static void FindByCategory()
    {
        Console.Write("Inserisci la categoria: ");
        string category = Console.ReadLine();
        var products = daoProdotto.Cerca(category);

        List<Utility.Entity> entities = products.Cast<Utility.Entity>().ToList();

        PrintList(entities);
    }
    private static void GetOldProducts()
    {
        var oldProducts = daoProdotto.ListaProdottiVecchi();

        List<Utility.Entity> entities = oldProducts.Cast<Utility.Entity>().ToList();

        PrintList(entities);
    }
    #endregion
    #region Print Methods
    private static void PrintByBrand()
    {
        Console.Write("Inserisci la marca: ");
        string brand = Console.ReadLine();

        var automobiles = daoAutomobile.CercaPerMarca(brand);
        var moto = daoMoto.CercaPerMarca(brand);

        Console.WriteLine("Automobili:");
        PrintProducts(automobiles);

        Console.WriteLine("Moto:");
        PrintProducts(moto);
    }
    private static void PrintProducts(string products)
    {
        Console.WriteLine(products);
    }
    private static void PrintInOrder()
    {
        var allProducts = daoProdotto.GetAllProducts();

        var orderedProducts = allProducts.OrderBy(prodotto => prodotto.Prezzo()).ToList();

        Console.WriteLine("Prodotti ordinati per prezzo:");
        PrintList(orderedProducts.Cast<Utility.Entity>().ToList());
    }
    private static void PrintByMaxDistance()
    {
        try
        {
            Console.WriteLine(daoProdotto.MaxDistanza());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore durante la scrittura dei prodotti per distanza massima: {ex.Message}");
        }
    }
    private static void PrintList(List<Utility.Entity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity is Prodotto prodotto)
            {
                Console.WriteLine(prodotto);
            }
        }
    }
    #endregion
}
