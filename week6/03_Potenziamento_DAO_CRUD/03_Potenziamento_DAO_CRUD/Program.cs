using _03_Potenziamento_DAO_CRUD;

// Inserisco i record
//Entity entity = new Videogame
//{
//    Title = "Cyberpunk 2077",
//    Genre = "Action RPG",
//    ReleaseYear = 2020,
//    Developer = "CD Projekt Red"
//};
//Console.WriteLine(DAOVideogame.GetInstance().CreateRecord(entity) ? "Record inserito con successo\n" + entity.ToString() : "Errore nell'inserimento del record");

// Cancello il record appena inserito
//Console.WriteLine(DAOVideogame.GetInstance().DeleteRecord(1) ? "Record 2 eliminato con successo" : "Errore nell'eliminazione del record");

// Inserisco 10 record diversi
// creo un lista di Videogame
//Videogame videogame = new Videogame();
//List<Videogame> videogames = new();

//videogames.Add(new Videogame(1, "Cyberpunk 2077", "Action RPG", 2020, "CD Projekt Red"));
//videogames.Add(new Videogame(2, "The Witcher 3: Wild Hunt", "Action RPG", 2015, "CD Projekt Red"));
//videogames.Add(new Videogame(3, "The Elder Scrolls V: Skyrim", "Action RPG", 2011, "Bethesda Game Studios"));
//videogames.Add(new Videogame(4, "The Legend of Zelda: Breath of the Wild", "Action-adventure", 2017, "Nintendo EPD"));
//videogames.Add(new Videogame(5, "Red Dead Redemption 2", "Action-adventure", 2018, "Rockstar Studios"));
//videogames.Add(new Videogame(6, "Grand Theft Auto V", "Action-adventure", 2013, "Rockstar Studios"));
//videogames.Add(new Videogame(7, "The Last of Us Part II", "Action-adventure", 2020, "Naughty Dog"));
//videogames.Add(new Videogame(8, "Uncharted 4: A Thief's End", "Action-adventure", 2016, "Naughty Dog"));
//videogames.Add(new Videogame(9, "Path of Exile", "Action RPG", 2013, "Grinding Gear Games"));
//videogames.Add(new Videogame(10, "Path of Exile 2", "Action RPG", 2024, "Grinding Gear Games"));

// inserisco i record della lista creata
//foreach(Videogame v in videogames)
//{
//    Console.WriteLine(DAOVideogame.GetInstance().CreateRecord(v) ? "Record inserito con successo\n" + v.ToString() : "Errore nell'inserimento del record");
//}

// Aggiorno il record con id 2
//Entity? entity = DAOVideogame.GetInstance().FindRecord(5);
//if(entity is Videogame videogame)
//{
//    videogame.Title = "League of Legends";
//    videogame.Genre = "MOBA";
//    videogame.ReleaseYear = 2009;
//    videogame.Developer = "Riot Games";
//    Console.WriteLine(DAOVideogame.GetInstance().UpdateRecord(videogame) ? "Record modificato con successo\n Nuovo record:\n" + videogame.ToString() : "Errore nella modifica del record");
//};

// Leggo i record
List<Entity> records = DAOVideogame.GetInstance().GetRecords();
foreach(Entity e in records)
{
    Console.WriteLine(e.ToString());
}
