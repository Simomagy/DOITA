using System.Text;
using Microsoft.Data.SqlClient;
using Utility;

public class DAOAutomobile : IDAO, IAdditionalMethods
{
    #region Singleton
    private readonly Database db;
    private static DAOAutomobile? instance = null;
    private DAOAutomobile() => db = new Database("Generation");
    public static DAOAutomobile GetInstance()
    {
        if (instance == null) instance = new DAOAutomobile();
        return instance;
    }
 #endregion
    #region CRUD Methods
    public List<Entity> GetRecords()
    {
        var command = new SqlCommand("SELECT * FROM Automobili");
        var result = db.ReadDb(command);

        if (result == null) return new List<Entity>();

        List<Entity> automobili = new List<Entity>();
        foreach (var record in result)
        {
            Automobile auto = new Automobile();
            auto.FromDictionary(record);
            automobili.Add(auto);
        }

        return automobili;
    }
    public bool CreateRecord(Entity entity)
    {
        Automobile auto = (Automobile)entity;
        string query = $"INSERT INTO Automobili (cilindrata, velocitaMax, postiAuto, prodotto_id) VALUES ({auto.Cilindrata}, {auto.VelocitaMax}, {auto.PostiAuto}, {auto.Id})";
        return db.UpdateDb(query);
    }
    public bool UpdateRecord(Entity entity)
    {
        Automobile auto = (Automobile)entity;
        string query = $"UPDATE Automobili SET cilindrata = {auto.Cilindrata}, velocitaMax = {auto.VelocitaMax}, postiAuto = {auto.PostiAuto} WHERE id = {auto.Id}";
        return db.UpdateDb(query);
    }
    public bool DeleteRecord(int recordId)
    {
        string query = $"DELETE FROM Automobili WHERE id = {recordId}";
        return db.UpdateDb(query);
    }
    #endregion
    public Entity? FindRecord(int recordId)
    {
        string query = $"SELECT * FROM Automobili WHERE id = {recordId}";
        var result = db.ReadOneDb(query);

        if (result == null) return null;

        Automobile auto = new Automobile();
        auto.FromDictionary(result);
        return auto;
    }
    public List<Prodotto> ListaProdottiVecchi()
    {
        var command = new SqlCommand("SELECT * FROM Prodotti WHERE DATEDIFF(YEAR, annoImmatricolazione, GETDATE()) >= 8 AND categoria = 'Automobile'");
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
        return new List<Moto>();
    }
    public List<Prodotto> Cerca(string categoria)
    {
        var command = new SqlCommand($"SELECT * FROM Prodotti WHERE categoria = '{categoria}' AND id IN (SELECT prodotto_id FROM Automobili)");
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
        var command = new SqlCommand("SELECT categoria, COUNT(*) AS frequenza FROM Prodotti WHERE categoria = 'Automobile' GROUP BY categoria");
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
        var command = new SqlCommand(
            "SELECT p.Id AS ProdottoId, p.marca, p.modello, p.categoria, p.affittabile, p.annoImmatricolazione, p.consumoMedioAKM, p.capienzaSerbatoio, " +
            "a.cilindrata, a.velocitaMax, a.postiAuto " +
            "FROM Prodotti p JOIN Automobili a ON p.Id = a.prodotto_id WHERE p.marca = @marca");
        command.Parameters.AddWithValue("@marca", marca);
        var result = db.ReadDb(command);

        if (result == null || result.Count == 0) return "Nessun prodotto trovato.";

        var sb = new StringBuilder();
        foreach (var record in result)
        {
            var autoRecord = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kvp in record)
            {
                if (!autoRecord.ContainsKey(kvp.Key))
                {
                    autoRecord.Add(kvp.Key, kvp.Value.ToString());
                }
            }

            Automobile auto = new Automobile();
            auto.FromDictionary(autoRecord);
            sb.AppendLine(auto.ToString());
        }
        return sb.ToString();
    }
    public string StampaListe(List<Prodotto> array)
    {
        string output = "";
        foreach (var prodotto in array)
        {
            if (prodotto is Automobile auto)
            {
                output += auto.ToString() + "\n";
            }
        }
        return output;
    }
    public List<Prodotto> TrovaSoluzione(double budget, int passengers)
    {
        var command = new SqlCommand(
            "SELECT p.Id AS ProdottoId, p.marca, p.modello, p.categoria, p.affittabile, p.annoImmatricolazione, p.consumoMedioAKM, p.capienzaSerbatoio, " +
            "a.cilindrata, a.velocitaMax, a.postiAuto " +
            "FROM Prodotti p JOIN Automobili a ON p.Id = a.prodotto_id " +
            "WHERE p.Affittabile = 1 AND p.Categoria = 'Automobile' AND a.postiAuto >= @passengers");
        command.Parameters.AddWithValue("@passengers", passengers);

        var result = db.ReadDb(command);

        if (result == null)
        {
            Console.WriteLine("Il risultato della query è null.");
            return new List<Prodotto>();
        }

        List<Prodotto> solutions = new List<Prodotto>();
        foreach (var record in result)
        {
            if (record == null)
            {
                Console.WriteLine("Un record nel risultato della query è null.");
                continue;
            }

            var autoRecord = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kvp in record)
            {
                if (!autoRecord.ContainsKey(kvp.Key))
                {
                    autoRecord.Add(kvp.Key, kvp.Value.ToString());
                }
            }

            Prodotto auto = new Prodotto();
            auto.FromDictionary(autoRecord);
            if (auto.Prezzo() <= budget)
            {
                solutions.Add(auto);
            }
        }

        return solutions;
    }
    public int GetMaxSpeed()
    {
        var command = new SqlCommand("SELECT MAX(velocitaMax) AS MaxVelocita FROM Automobili");
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
        var command = new SqlCommand("SELECT * FROM Prodotti WHERE categoria = 'Automobile' ORDER BY prezzo ASC");
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