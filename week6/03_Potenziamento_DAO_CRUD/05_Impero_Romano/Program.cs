//foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
//    Console.WriteLine(record);

// Inserimento di un nuovo record
//Entity newImperatore = new Imperatore
//{
//    Id = 0,
//    Nome = "Commodo",
//    Dinastia = "Flavia",
//    Dob = new DateTime(161, 8, 31),
//    Dod = new DateTime(192, 12, 31),
//    Assassinio = true
//};
//Console.WriteLine(DAOImperatori.GetInstance().CreateRecord(newImperatore));

// Aggiornamento di un record esistente
//Entity entity = DAOImperatori.GetInstance().FindRecord(10);
//if(entity != null)
//{
//    Imperatore imperatore = (Imperatore) entity;
//    imperatore.Dob = new DateTime(30, 11, 08);
//    Console.WriteLine(DAOImperatori.GetInstance().UpdateRecord(imperatore));
//} else
//{
//    Console.WriteLine("Record non trovato");
//}

// Cancellazione di un record esistente
//Console.WriteLine(DAOImperatori.GetInstance().DeleteRecord(10));

// Stampo tutte le battaglie
//foreach(Entity record in DAOBattaglie.GetInstance().GetRecords())
//    Console.WriteLine(record);

// Inserimento di un nuovo record
//Entity entity = new Battaglia
//{
//    Id = 0,
//    Nemico = "Cartaginesi",
//    Data_battaglia = new DateTime(202, 6, 15),
//    Vincitore = true,
//    Luogo = "Zama",
//    Imperatore = (Imperatore) DAOImperatori.GetInstance().FindRecord(1)
//};
//Console.WriteLine(DAOBattaglie.GetInstance().CreateRecord(entity));

// Aggiornamento di un record esistente
//Entity entity = DAOBattaglie.GetInstance().FindRecord(12);
//if(entity != null)
//{
//    Battaglia battaglia = (Battaglia) entity;
//    battaglia.Luogo = "Cannae";
//    Console.WriteLine(DAOBattaglie.GetInstance().UpdateRecord(battaglia));
//} else
//{
//    Console.WriteLine("Record non trovato");
//}

// Cancellazione di un record esistente
//Console.WriteLine(DAOBattaglie.GetInstance().DeleteRecord(12));


// Voglio vedere per ogni imperatore i nomi dei nemici che ha sconfitto, se non ha sconfitto nessuno deve stampare "Non ha sconfitto nessuno"
using _04_Utility;
using _05_Impero_Romano;

foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
{
    Imperatore imperatore = (Imperatore) record;
    Console.WriteLine($"Imperatore: {imperatore.Nome}");
    bool found = false;
    foreach(Entity battaglia in DAOBattaglie.GetInstance().GetRecords())
    {
        Battaglia batt = (Battaglia) battaglia;
        if(batt.Imperatore?.Id == imperatore.Id)
        {
            Console.WriteLine($"Nemico: {batt.Nemico}");
            found = true;
        }
    }
    if(!found)
        Console.WriteLine("Non ha sconfitto nessuno");
    Console.WriteLine("--------------------------------------------------");
}

// Voglio vedere per ogni dinastia quanti imperatori ci sono stati e quali erano i loro nomi
//Dictionary<string, List<string>> dinastie = new();
//foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
//{
//    Imperatore imperatore = (Imperatore) record;
//    if(dinastie.ContainsKey(imperatore.Dinastia))
//        dinastie[imperatore.Dinastia].Add(imperatore.Nome);
//    else
//        dinastie[imperatore.Dinastia] = new List<string> { imperatore.Nome };
//}
//foreach(KeyValuePair<string, List<string>> dinastia in dinastie)
//{
//    Console.WriteLine($"Dinastia: {dinastia.Key}");
//    foreach(string nome in dinastia.Value)
//        Console.WriteLine($"Nome: {nome}");
//    Console.WriteLine("--------------------------------------------------");
//}

// Voglio vedere per ogni imperatore quanti anni è durato il suo regno e se è stato assassinato
//foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
//{
//    Imperatore imperatore = (Imperatore) record;
//    Console.WriteLine($"Imperatore: {imperatore.Nome}");
//    Console.WriteLine($"Durata regno: {imperatore.Dod.Year - imperatore.Dob.Year} anni");
//    Console.WriteLine($"Causa di morte: {(imperatore.Assassinio ? "Assassinato" : "Cause Naturali")}");
//    Console.WriteLine("--------------------------------------------------");
//}
// Ordino gli imperatori per durata del regno e calcolo la media delle durate dei regni
//List<Imperatore> imperatori = new();
//foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
//    imperatori.Add((Imperatore) record);
//imperatori.Sort((a, b) => (b.Dod.Year - b.Dob.Year).CompareTo(a.Dod.Year - a.Dob.Year));
//int sum = 0;
//foreach(Imperatore imperatore in imperatori)
//{
//    sum += imperatore.Dod.Year - imperatore.Dob.Year;
//}
//Console.WriteLine("Totale durata regni: " + sum + " anni");
//Console.WriteLine("--------------------------------------------------");
//Console.WriteLine("Totale imperatori: " + imperatori.Count);
//Console.WriteLine("--------------------------------------------------");
//Console.WriteLine($"Media durata regno: {sum / imperatori.Count} anni");
//Console.WriteLine("--------------------------------------------------");

// Crea un menu per l'utente che permetta di:
// 1. Cercare una dinastra e vedere quanti imperatori ci sono stati e quali erano i loro nomi
// 2. Trovare la dinastia che ha condotto più battaglie
// 3. Trovare l'imperatore che ha vinto più battaglie
// 4. Trovare l'imperatore che ha perso più battaglie
// 5. Trovare l'imperatore che ha regnato per più tempo
// 6. Trovare l'imperatore che ha regnato per meno tempo
// Easter egg: ascii art di Cesare

Console.WriteLine("Benvenuto nel programma dell'Impero Romano. \n Seleziona una funzione:");
Console.WriteLine("1. Cercare una dinastia e vedere quanti imperatori ci sono stati e quali erano i loro nomi");
Console.WriteLine("2. Trovare la dinastia che ha condotto più battaglie");
Console.WriteLine("3. Trovare l'imperatore che ha vinto più battaglie");
Console.WriteLine("4. Trovare l'imperatore che ha regnato per più tempo");
Console.WriteLine("5. Trovare l'imperatore che ha regnato per meno tempo");
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("C'e anche un easter egg");

string choice = Console.ReadLine() ?? string.Empty;

if(choice == "Veni, vidi, vici")
{
    CesareAsciiArt();
} else
{
    switch(choice)
    {
        case "1":
            Choice1();
            break;
        case "2":
            Choice2();
            break;
        case "3":
            Choice3();
            break;
        case "4":
            Choice4();
            break;
        case "5":
            Choice5();
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
}


static void Choice1()
{
    Console.WriteLine("Inserisci il nome di una dinastia:");
    Console.WriteLine("Dinastie disponibili:");
    // Stampo tutte le dinastie non devono esserci duplicati
    HashSet<string> dinastieSet = [];
    foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
    {
        Imperatore imperatore = (Imperatore) record;
        dinastieSet.Add(imperatore.Dinastia);
    }
    foreach(string dinastia in dinastieSet)
        Console.WriteLine(dinastia);
    Console.WriteLine();

    string dinastiaInput = Console.ReadLine() ?? string.Empty;
    List<string> imperatori = [];
    foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
    {
        Imperatore imperatore = (Imperatore) record;
        if(imperatore.Dinastia == dinastiaInput)
            imperatori.Add(imperatore.Nome);
    }
    if(imperatori.Count == 0)
        Console.WriteLine("Nessun imperatore trovato");
    else
    {
        Console.WriteLine($"Dinastia: {dinastiaInput}");
        foreach(string nome in imperatori)
            Console.WriteLine($"Nome: {nome}");
    }
}

static void Choice2()
{
    Dictionary<string, int> dinastie = [];
    foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
    {
        Imperatore imperatore = (Imperatore) record;
        dinastie[imperatore.Dinastia] = dinastie.TryGetValue(imperatore.Dinastia, out int value) ? ++value : 1;
    }
    string maxDinastia = string.Empty;
    int max = 0;
    foreach(KeyValuePair<string, int> dinastia in dinastie)
    {
        if(dinastia.Value > max)
        {
            max = dinastia.Value;
            maxDinastia = dinastia.Key;
        }
    }
    Console.WriteLine($"La dinastia che ha condotto più battaglie è: {maxDinastia}");
    Console.WriteLine("Numero di battaglie: " + max);
}

static void Choice3()
{
    Dictionary<int, int> imperatori = [];
    foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
    {
        Imperatore imperatore = (Imperatore) record;
        imperatori[imperatore.Id] = 0;
    }
    foreach(Entity record in DAOBattaglie.GetInstance().GetRecords())
    {
        Battaglia battaglia = (Battaglia) record;
        if(battaglia.Vincitore)
            imperatori[battaglia.Imperatore?.Id ?? 0]++;
    }
    int maxId = 0;
    int max = 0;
    foreach(KeyValuePair<int, int> imperatore in imperatori)
    {
        if(imperatore.Value > max)
        {
            max = imperatore.Value;
            maxId = imperatore.Key;
        }
    }
    Entity? entity = DAOImperatori.GetInstance().FindRecord(maxId);
    if(entity != null)
    {
        Imperatore imperatore = (Imperatore) entity;
        Console.WriteLine($"L'imperatore che ha vinto più battaglie è: {imperatore.Nome}. \n Numero battaglie vinte: {max}");
    }
}

static void Choice4()
{
    List<Imperatore> imperatori = [];
    foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
        imperatori.Add((Imperatore) record);
    imperatori.Sort((a, b) => (b.Dod.Year - b.Dob.Year).CompareTo(a.Dod.Year - a.Dob.Year));
    Imperatore imperatore = imperatori[0];
    Console.WriteLine($"L'imperatore che ha regnato per più tempo è: {imperatore.Nome}");
    Console.WriteLine($"Durata regno: {imperatore.Dod.Year - imperatore.Dob.Year} anni");
}

static void Choice5()
{
    List<Imperatore> imperatori = [];
    foreach(Entity record in DAOImperatori.GetInstance().GetRecords())
        imperatori.Add((Imperatore) record);
    imperatori.Sort((a, b) => (b.Dod.Year - b.Dob.Year).CompareTo(a.Dod.Year - a.Dob.Year));
    Imperatore imperatore = imperatori[^1];
    Console.WriteLine($"L'imperatore che ha regnato per meno tempo è: {imperatore.Nome}");
    Console.WriteLine($"Durata regno: {imperatore.Dod.Year - imperatore.Dob.Year} anni");
}

static void CesareAsciiArt()
{
    Console.WriteLine(@"                             
                                                     -+++++-                                        
                  +                .+##########---#############+                                    
                  ###+.        .##################################                                  
                  +#####+        .+################################++++-.                           
                  .#######+           +####################################+-                       
                   +########+   -##+.   #####################################+                      
                    +########-  .#####-  ++. .+################################+-                   
             -+      -#######+  .#######          ##################################+               
             -####+.   +#####+   ########    ##-   -##################################+             
              ##########+####+   ########-   ####+   -#################################+            
               +###############- .#######+   ######.       -############################+           
                 +###############--######+   #######.   .+.   -##########################           
             .#+-   --+++++---++#########+   ########.   ###+   -########################           
             .#####+-----         .######+   -########   +####+   #######################-          
             -####+         .+#############+  ########   +######  -#######################-         
             ######-  +###############################.  -#######   --+####################+        
            +#######+   -####################++#######-  -#######-       +##################-       
           -##########+-    .+##########+.        .+###-  +#######    +-   +################-       
          .###############+-                .+####################    +##+  -###############-       
          +#######################-     ++########################    +####- +##############-       
         -########################+   .+##########################    +#####- +#############-       
         +###########################-    --+#######--         -###.  -######  +############-       
         +###############################+-.            .++##########+ ######+ .############+       
           +##################################.    -+#########################  +############.      
          +#####################################.     --######################+ +############-      
         +#########################################+.                 -+######+ -############+      
        ################################################+++++++++++++.   -##### -############+      
      .#################################################################-   +## +############+      
     +####################################################################+  #+-#############-      
    +######################################################################+ +###############       
   +########################################################################- ##############+       
  +#########################################################################+-##############.       
  +##########################################################################+#############-        
   .+#####################################################################################.         
         -##############################################################################+           
          +############################################################################-            
          ############################################################################.             
           +##########################################################################.             
           +##########################################################################              
           +#########################################################################.              
             #######################################################################                
             +####################################################################-                 
            +###################################################################-                   
           +###################################################################-                    
          .####################################################################                     
           ####################################################################                     
           -###################################################################                     
             -+++##############################################################                     
                          -#################################################++-                     
                           .##############################################-                         
                            ##############################################                          
                           -##############################################                          
                           ###############################################-                         
                           ################################################.                        
                           -################################################                        
                            ################################################+                       
                            ##################################################                      
                            +##################################################.                    
                            -###################################+.            .-.                   
                            -###############################-                                       
                            +###########################+-                                          
                            #########################+.                                             
                            ######################-                                                 
                           -##################+-                                                    
                           ##############+-                                                         
                          -#######+-.                                                               
    ");
}

