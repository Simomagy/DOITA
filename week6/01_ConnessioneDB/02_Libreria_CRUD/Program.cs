using _02_Libreria_CRUD;

// Stampo tutti i libri
foreach (Entity e in DAOLibri.GetInstance().Read())
    Console.WriteLine(e.ToString());

// // Cerco il libro con id 5
// Console.WriteLine(DAOLibri.GetInstance().Find(5).ToString());

// // Creo un nuovo libro
// Entity e = new Libro
// {
//     Titolo = "Il signore delle panette",
//     Autore = "J.R.R. Tocchetto",
//     Genere = "Fantasy",
//     AnnoPubblicazione = 420
// };
// Console.WriteLine(DAOLibri.GetInstance().Insert(e));

// // Modifico il libro con id 5
// Entity entity = DAOLibri.GetInstance().Find(5);
// if (entity is Libro libro)
// {
//     libro.Titolo = "Il signore delle puttanelle";
//     libro.Autore = "J.R.R. Buffone";
//     libro.Genere = "Fantasy";
//     libro.AnnoPubblicazione = 6969;
//     Console.WriteLine(DAOLibri.GetInstance().Update(libro));
// }
// else
// {
//     Console.WriteLine("Libro non trovato");
// }
