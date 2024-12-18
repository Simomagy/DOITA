using System.Text;
using Microsoft.Data.SqlClient;
using Utility;

public class DAOProdotto : IDAO, IAdditionalMethods
{
    #region Singleton
    private readonly Database db;
    private static DAOProdotto? instance = null;
    private DAOProdotto() => db = new Database("Generation");
    public static DAOProdotto GetInstance()
    {
        if (instance == null) instance = new DAOProdotto();
        return instance;
    }
    #endregion
    #region CRUD Methods
    public List<Entity> GetRecords()
    {
        var command = new SqlCommand("SELECT * FROM Prodotti");
        var result = db.ReadDb(command);

        if (result == null) return new List<Entity>();

        List<Entity> entities = new List<Entity>();
        foreach (var record in result)
        {
            Prodotto prodotto = new Prodotto();
            prodotto.FromDictionary(record);
            entities.Add(prodotto); 
        }

        return entities;
    }
    public bool CreateRecord(Entity entity)
    {
        Prodotto prodotto = (Prodotto)entity;
        string query = $"INSERT INTO Prodotti (categoria, marca, modello, affittabile, annoimmatricolazione, consumoMedioakm, capienzaserbatoio) VALUES ('{prodotto.Categoria}', '{prodotto.Marca}', '{prodotto.Modello}', {(prodotto.Affittabile ? 1 : 0)}, {prodotto.AnnoImmatricolazione}, {prodotto.ConsumoMedioAKM}, {prodotto.CapienzaSerbatoio})";
        return db.UpdateDb(query);
    }
    public bool UpdateRecord(Entity entity)
    {
        Prodotto prodotto = (Prodotto)entity;
        string query = $"UPDATE Prodotti SET categoria = '{prodotto.Categoria}', marca = '{prodotto.Marca}', modello = '{prodotto.Modello}', affittabile = {(prodotto.Affittabile ? 1 : 0)}, annoImmatricolazione = {prodotto.AnnoImmatricolazione}, consumoMedioAKM = {prodotto.ConsumoMedioAKM}, capienzaSerbatoio = {prodotto.CapienzaSerbatoio} WHERE id = {prodotto.Id}";
        return db.UpdateDb(query);
    }
    public bool DeleteRecord(int recordId)
    {
        string query = $"DELETE FROM Prodotti WHERE id = {recordId}";
        return db.UpdateDb(query);
    }
    #endregion
    public Entity? FindRecord(int recordId)
    {
        string query = $"SELECT * FROM Prodotti WHERE id = {recordId}";
        var result = db.ReadOneDb(query);

        if (result == null) return null;

        Prodotto prodotto = new Prodotto();
        prodotto.FromDictionary(result);
        return prodotto;
    }
    public List<Prodotto> ListaProdottiVecchi()
    {
        var command = new SqlCommand("SELECT * FROM Prodotti WHERE DATEDIFF(YEAR, annoimmatricolazione, GETDATE()) >= 8");
        var result = db.ReadDb(command);

        if (result == null) return new List<Prodotto>();

        List<Prodotto> prodottiVecchi = new List<Prodotto>();
        foreach (var record in result)
        {
            Prodotto prodotto = new Prodotto();
            prodotto.FromDictionary(record);
            prodottiVecchi.Add(prodotto);
        }

        return prodottiVecchi;
    }
    public string MaxDistanza()
    {
        var commandAutomobili = new SqlCommand(
            "SELECT p.*, a.cilindrata, a.velocitaMax, a.postiAuto " +
            "FROM Prodotti p " +
            "JOIN Automobili a ON p.id = a.prodotto_id " +
            "WHERE (p.capienzaSerbatoio * 100.0 / p.consumoMedioAKM) = " +
            "(SELECT MAX(p.capienzaSerbatoio * 100.0 / p.consumoMedioAKM) FROM Prodotti p JOIN Automobili a ON p.id = a.prodotto_id)");

        var commandMoto = new SqlCommand(
            "SELECT p.*, m.passeggeri " +
            "FROM Prodotti p " +
            "JOIN Moto m ON p.id = m.prodotto_id " +
            "WHERE (p.capienzaSerbatoio * 100.0 / p.consumoMedioAKM) = " +
            "(SELECT MAX(p.capienzaSerbatoio * 100.0 / p.consumoMedioAKM) FROM Prodotti p JOIN Moto m ON p.id = m.prodotto_id)");

        var resultAutomobili = db.ReadDb(commandAutomobili);
        var automobiliWithMaxDistance = new List<Automobile>();
        if (resultAutomobili != null)
        {
            foreach (var record in resultAutomobili)
            {
                Automobile auto = new Automobile();
                auto.FromDictionary(record);
                automobiliWithMaxDistance.Add(auto);
            }
        }

        var resultMoto = db.ReadDb(commandMoto);
        var motoWithMaxDistance = new List<Moto>();
        if (resultMoto != null)
        {
            foreach (var record in resultMoto)
            {
                Moto moto = new Moto();
                moto.FromDictionary(record);
                motoWithMaxDistance.Add(moto);
            }
        }

        var output = new StringBuilder();

        output.AppendLine("Automobiles with max distance:");
        if (automobiliWithMaxDistance.Any())
        {
            foreach (var auto in automobiliWithMaxDistance)
            {
                output.AppendLine(auto.ToString());
            }
        }
        else
        {
            output.AppendLine("Nessuna automobile trovata.");
        }

        output.AppendLine("\nMoto with max distance:");
        if (motoWithMaxDistance.Any())
        {
            foreach (var moto in motoWithMaxDistance)
            {
                output.AppendLine(moto.ToString());
            }
        }
        else
        {
            output.AppendLine("Nessuna moto trovata.");
        }

        return output.ToString();
    }
    public List<Automobile> AutoSuper()
    {
        var command = new SqlCommand("SELECT * FROM Automobili");
        var result = db.ReadDb(command);

        if (result == null) return new List<Automobile>();

        List<Automobile> autoSuper = new List<Automobile>();
        foreach (var record in result)
        {
            Automobile auto = new Automobile();
            auto.FromDictionary(record);

            if (auto.Potente())
            {
                autoSuper.Add(auto);
            }
        }

        return autoSuper;
    }
    public List<Moto> Sportive()
    {
        var command = new SqlCommand("SELECT * FROM Moto WHERE passeggeri = 0");
        var result = db.ReadDb(command);

        if (result == null) return new List<Moto>();

        List<Moto> motoSportive = new List<Moto>();
        foreach (var record in result)
        {
            Moto moto = new Moto();
            moto.FromDictionary(record);
            motoSportive.Add(moto);
        }

        return motoSportive;
    }
    public List<Prodotto> Cerca(string categoria)
    {
        var command = new SqlCommand($"SELECT * FROM Prodotti WHERE categoria = '{categoria}'");
        var result = db.ReadDb(command);

        if (result == null) return new List<Prodotto>();

        List<Prodotto> prodottiCategoria = new List<Prodotto>();
        foreach (var record in result)
        {
            Prodotto prodotto = new Prodotto();
            prodotto.FromDictionary(record);
            prodottiCategoria.Add(prodotto);
        }

        return prodottiCategoria;
    }
    public Dictionary<string, int> Frequenza()
    {
        var command = new SqlCommand("SELECT categoria, COUNT(*) AS frequenza FROM Prodotti GROUP BY categoria");
        var result = db.ReadDb(command);

        if (result == null) return new Dictionary<string, int>();

        Dictionary<string, int> frequenza = new Dictionary<string, int>();
        foreach (var record in result)
        {
            frequenza.Add(record["categoria"], int.Parse(record["frequenza"]));
        }

        return frequenza;
    }
    public string CercaPerMarca(string marca)
    {
        var command = new SqlCommand($"SELECT * FROM Prodotti WHERE marca = '{marca}'");
        var result = db.ReadDb(command);

        if (result == null) return "Nessun prodotto trovato.";

        string schede = "";
        foreach (var record in result)
        {
            Prodotto prodotto = new Prodotto();
            prodotto.FromDictionary(record);
            schede += $"Marca: {prodotto.Marca}, Modello: {prodotto.Modello}, Categoria: {prodotto.Categoria}\n";
        }

        return schede;
    }
    public string StampaListe(List<Prodotto> array)
    {
        string output = "";
        foreach (var prodotto in array)
        {
            output += $"ID: {prodotto.Id}, Marca: {prodotto.Marca}, Modello: {prodotto.Modello}, Categoria: {prodotto.Categoria}\n";
        }
        return output;
    }
    public List<Prodotto> TrovaSoluzione(double budgetMensile, int passeggeri)
    {
        var command = new SqlCommand($"SELECT * FROM Prodotti WHERE affittabile = 1");
        var result = db.ReadDb(command);

        if (result == null) return new List<Prodotto>();

        List<Prodotto> soluzioni = new List<Prodotto>();
        foreach (var record in result)
        {
            Prodotto prodotto = new Prodotto();
            prodotto.FromDictionary(record);
            if (prodotto.AffittoMensile() <= budgetMensile)
            {
                soluzioni.Add(prodotto);
            }
        }

        return soluzioni;
    }
    public List<Prodotto> GetAllProducts()
    {
        var command = new SqlCommand("SELECT * FROM Prodotti");
        var result = db.ReadDb(command);

        if (result == null)
        {
            Console.WriteLine("Il risultato della query è null.");
            return new List<Prodotto>();
        }

        List<Prodotto> products = new List<Prodotto>();
        foreach (var record in result)
        {
            var productRecord = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kvp in record)
            {
                productRecord[kvp.Key.ToLower()] = kvp.Value.ToString();
            }

            Prodotto prodotto = new Prodotto();
            prodotto.FromDictionary(productRecord);
            products.Add(prodotto);
        }

        return products;
    }
    public int GetMaxSpeed()
    {
        var command = new SqlCommand("SELECT MAX(velocitamax) AS MaxVelocita FROM Automobili");
        var result = db.ReadOneDb(command);

        if (result == null || !result.ContainsKey("MaxVelocita")) return 0;

        return int.Parse(result["MaxVelocita"]);
    }
    public List<Automobile> Veloci()
    {
        int maxSpeed = GetMaxSpeed();

        var command = new SqlCommand($"SELECT * FROM Automobili WHERE velocitaMax = {maxSpeed}");
        var result = db.ReadDb(command);

        if (result == null) return new List<Automobile>();

        List<Automobile> autoVeloci = new List<Automobile>();
        foreach (var record in result)
        {
            Automobile auto = new Automobile();
            auto.FromDictionary(record);
            autoVeloci.Add(auto);
        }

        return autoVeloci;
    }
    public List<Prodotto> InOrdineDiPrezzo()
    {
        var command = new SqlCommand("SELECT * FROM Prodotti ORDER BY prezzo ASC");
        var result = db.ReadDb(command);

        if (result == null) return new List<Prodotto>();

        List<Prodotto> prodottiOrdinati = new List<Prodotto>();
        foreach (var record in result)
        {
            Prodotto prodotto = new Prodotto();
            prodotto.FromDictionary(record);
            prodottiOrdinati.Add(prodotto);
        }

        return prodottiOrdinati;
    }
}