using System.Text;
using Microsoft.Data.SqlClient;
using Utility;

public class DAOMoto : IDAO, IAdditionalMethods
{
    #region Singleton
    private readonly Database db;
    private static DAOMoto? instance = null;
    private DAOMoto() => db = new Database("Generation");
    public static DAOMoto GetInstance()
    {
        if (instance == null) instance = new DAOMoto();
        return instance;
    }
 #endregion
    #region CRUD Methods
    public List<Entity> GetRecords()
    {
        var command = new SqlCommand("SELECT * FROM Moto");
        var result = db.ReadDb(command);

        if (result == null) return new List<Entity>();

        List<Entity> motoList = new List<Entity>();
        foreach (var record in result)
        {
            Moto moto = new Moto();
            moto.FromDictionary(record);
            motoList.Add(moto);
        }

        return motoList;
    }
    public bool CreateRecord(Entity entity)
    {
        Moto moto = (Moto)entity;
        string query = $"INSERT INTO Moto (passeggeri, prodotto_id) VALUES ({(moto.Passeggeri ? 1 : 0)}, {moto.Id})";
        return db.UpdateDb(query);
    }
    public bool UpdateRecord(Entity entity)
    {
        Moto moto = (Moto)entity;
        string query = $"UPDATE Moto SET passeggeri = {(moto.Passeggeri ? 1 : 0)} WHERE id = {moto.Id}";
        return db.UpdateDb(query);
    }
    public bool DeleteRecord(int recordId)
    {
        string query = $"DELETE FROM Moto WHERE id = {recordId}";
        return db.UpdateDb(query);
    }
    #endregion
    public Entity? FindRecord(int recordId)
    {
        string query = $"SELECT * FROM Moto WHERE id = {recordId}";
        var result = db.ReadOneDb(query);

        if (result == null) return null;

        Moto moto = new Moto();
        moto.FromDictionary(result);
        return moto;
    }
    public List<Prodotto> ListaProdottiVecchi()
    {
        var command = new SqlCommand("SELECT * FROM Prodotti WHERE DATEDIFF(YEAR, annoImmatricolazione, GETDATE()) >= 8 AND categoria = 'Moto'");
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
        return new List<Automobile>();
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
        var command = new SqlCommand($"SELECT * FROM Prodotti WHERE categoria = '{categoria}' AND id IN (SELECT prodotto_id FROM Moto)");
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
        var command = new SqlCommand("SELECT categoria, COUNT(*) AS frequenza FROM Prodotti WHERE categoria = 'Moto' GROUP BY categoria");
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
            "m.passeggeri " +
            "FROM Prodotti p JOIN Moto m ON p.Id = m.prodotto_id WHERE p.marca = @marca");
        command.Parameters.AddWithValue("@marca", marca);
        var result = db.ReadDb(command);

        if (result == null || result.Count == 0) return "Nessun prodotto trovato.";

        var sb = new StringBuilder();
        foreach (var record in result)
        {
            var motoRecord = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kvp in record)
            {
                if (!motoRecord.ContainsKey(kvp.Key))
                {
                    motoRecord.Add(kvp.Key, kvp.Value.ToString());
                }
            }

            Moto moto = new Moto();
            moto.FromDictionary(motoRecord);
            sb.AppendLine(moto.ToString());
        }
        return sb.ToString();
    }
    public string StampaListe(List<Prodotto> array)
    {
        string output = "";
        foreach (var prodotto in array)
        {
            if (prodotto is Moto moto)
            {
                output += moto.ToString() + "\n";
            }
        }
        return output;
    }
    public List<Prodotto> TrovaSoluzione(double budget, int passengers)
    {
        var command = new SqlCommand(
            "SELECT p.Id AS ProdottoId, p.marca, p.modello, p.categoria, p.affittabile, p.annoImmatricolazione, p.consumoMedioAKM, p.capienzaSerbatoio, " +
            "m.passeggeri " +
            "FROM Prodotti p JOIN Moto m ON p.Id = m.prodotto_id " +
            "WHERE p.Affittabile = 1 AND p.Categoria = 'Moto' AND m.passeggeri >= @passengers");
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

            var motoRecord = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kvp in record)
            {
                if (!motoRecord.ContainsKey(kvp.Key))
                {
                    motoRecord.Add(kvp.Key, kvp.Value.ToString());
                }
            }

            Prodotto moto = new Prodotto();
            moto.FromDictionary(motoRecord);
            if (moto.Prezzo() <= budget)
            {
                solutions.Add(moto);
            }
        }

        return solutions;
    }
    public List<Automobile> Veloci()
    {
        return new List<Automobile>();
    }
    public List<Prodotto> InOrdineDiPrezzo()
    {
        var command = new SqlCommand("SELECT * FROM Prodotti WHERE categoria = 'Moto' ORDER BY prezzo ASC");
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