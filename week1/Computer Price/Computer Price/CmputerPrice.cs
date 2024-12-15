//        Voglio creare un programma che sia in grado di
//        calcolare il prezzo di un PC basandosi sulle sue
//        caratteristiche.
//        Chiediamo le seguenti informazioni:
//        - Processore (I3, I5, I7 etc)
//        - quantità di ram
//        - tipologia di ram
//        - quantità di memoria
//        - tipo di memoria
//        - marca del PC
//        Il costo del PC dipende da molti fattori:
//        - I3: 150
//        - I5: 220
//        - I7: 350
//        - I9: 400
//        - in tutti gli altri casi: 180
//        Anche la ram ha un prezzo diverso, ma a seconda della
//        tipologia. Ogni GB di ram costa diversamente a seconda
//        del tipo:
//        - DDR3: 5  euro/GB
//        - DDR4: 10 euro/GB
//        - altri tipologie sconosciute: 7 euro/GB
//        Stesso discorso vale per la memoria:
//        - HDD: 0.01  euro/GB
//        - SSD: 0.2   euro/GB
//        - SSDM2: 0.5 euro/GB
//        Se la marca è ANANAS raddoppiare il prezzo finale.

// Console questions
Console.WriteLine("Quale CPU vorresti?");
string cpu = Console.ReadLine();
Console.WriteLine("Quale tipologia di RAM vorresti?");
string ramType = Console.ReadLine();
Console.WriteLine("Quanti GB di RAM vorresti?");
int ramAmount = int.Parse(Console.ReadLine());
Console.WriteLine("Quale tipologia di memoria vorresti tra HDD, SSD o SSDM2?");
string memoryType = Console.ReadLine();
Console.WriteLine("Quanti GB di memoria vorresti?");
double memoryAmount = double.Parse(Console.ReadLine());
Console.WriteLine("Quale marca di PC vorresti?");
string brand = Console.ReadLine();

// Variables initialization
int cpuPrice = 0;
int ramPrice = 0;
double memoryPrice = 0;
double finalPrice = 0;


// CPU price calc
switch
    (cpu.ToLower())
{
    case "i3":
        cpuPrice = 150;
        break;
    case "i5":
        cpuPrice = 220;
        break;
    case "i7":
        cpuPrice = 350;
        break;
    case "i9":
        cpuPrice = 400;
        break;
    default:
        cpuPrice = 180;
        break;
}

// RAM price calc
switch
    (ramType.ToLower())
{
    case "ddr3":
        ramPrice = 5;
        break;
    case "ddr4":
        ramPrice = 10;
        break;
    default:
        ramPrice = 7;
        break;
}

// Memory price calc
switch
    (memoryType.ToLower())
{
    case "hdd":
        memoryPrice = 0.01;
        break;
    case "ssd":
        memoryPrice = 0.2;
        break;
    case "ssdm2":
        memoryPrice = 0.5;
        break;
}

// Final price calc
switch
    (brand.ToLower())
{
    case "ananas":
        finalPrice = (cpuPrice + (ramPrice * ramAmount) + (memoryPrice * memoryAmount)) * 2;
        break;
    default:
        finalPrice = cpuPrice + (ramPrice * ramAmount) + (memoryPrice * memoryAmount);
        break;
}

// Output final price
Console.WriteLine("--------------------");
Console.WriteLine($"CPU: {cpu} - {cpuPrice} euro");
Console.WriteLine($"RAM: {ramType} - {ramPrice * ramAmount} euro");
Console.WriteLine($"Memory: {memoryType} - {memoryPrice * memoryAmount} euro");
Console.WriteLine($"Brand: {brand}");
Console.WriteLine("--------------------");
Console.WriteLine($"Il prezzo del PC è {finalPrice} euro");
