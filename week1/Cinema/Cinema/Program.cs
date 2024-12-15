// Variables declaration
int age;
string residence;
string job;
double price = 15;
string output;

// User input
Console.WriteLine("Quale e la tua eta? [Inserire Numero]");
age = int.Parse(Console.ReadLine());
Console.WriteLine("Sei residente a Torino? [Y/N]");
residence = Console.ReadLine();
residence = residence.ToLower(); // Converting the input to lowercase to handle both cases
Console.WriteLine("Sei studente o Insegnante? [Y/N]");
job = Console.ReadLine();
job = job.ToLower(); // Converting the input to lowercase to handle both cases

// Conditions
bool isResident = residence == "y";
bool isStudentOrTeacher = job == "y";
bool isUnder18OrOver65 = age < 18 || age > 65;

// Price calculation
price = isResident ? 0 : price; // Using the ternary operator to set the price based on residency
price = isUnder18OrOver65 ? price / 2 : price; // Applying the discount for age
price = isStudentOrTeacher ? price - 4 : price; // Applying the discount for being a student or teacher

// Output
output = $"Il prezzo del tuo biglietto è {price} Euro";

Console.WriteLine(output);