using EreditarietaScuola;

string dataPath = "../../../data.txt";
string[] lines = System.IO.File.ReadAllLines(dataPath);

List<Student> students = new();
List<Teacher> teachers = new();

foreach (string line in lines)
{
    string[] parts = line.Split(';');
    if (parts[0] == "s")
    {
        students.Add(new Student(false, parts[1], parts[2], parts[3], parts[4], parts[5]));
    }
    else
    {
        if (parts[5] == "S")
        {
            teachers.Add(new Teacher(true, parts[1], parts[2], parts[3], parts[4], true));
        }
        else
        {
            teachers.Add(new Teacher(true, parts[1], parts[2], parts[3], parts[4], false));
        }
    }
}

foreach (Student student in students)
{
    Console.WriteLine($"Student: {student.Name} {student.Surname} {student.DateOfBirth} {student.ClassName} {student.Grades}");
}
    
foreach (Teacher teacher in teachers)
{
    Console.WriteLine($"Teacher: {teacher.Name} {teacher.Surname} {teacher.DateOfBirth} {teacher.Subject} {teacher.IsContracted}");
}

Console.WriteLine("\n ---------------- \n");
Console.WriteLine("Students grades averages: \n");
// Separate student grades and calculate average
foreach (Student student in students)
{
    string[] grades = student.Grades.Split('-');
    int sum = 0;
    foreach (string grade in grades)
    {
        sum += int.Parse(grade);
    }
    double average = (double)sum / grades.Length;
    Console.WriteLine($"Student: {student.Name} {student.Surname} {student.DateOfBirth} {student.ClassName} {student.Grades} Average: {average}");
}

Console.WriteLine("\n ---------------- \n");
Console.WriteLine("Best student by grades average: \n");
// Find the best student by average
Student bestStudent = students[0];
foreach (Student student in students)
{
    string[] grades = student.Grades.Split('-');
    int sum = 0;
    foreach (string grade in grades)
    {
        sum += int.Parse(grade);
    }
    double average = (double)sum / grades.Length;
    if (average > bestStudent.Average)
    {
        bestStudent = student;
        bestStudent.Average = average;
    }
}

Console.WriteLine($"Best student: {bestStudent.Name} {bestStudent.Surname} {bestStudent.DateOfBirth} {bestStudent.ClassName} {bestStudent.Grades} Average: {bestStudent.Average}");

// Search Students by name
Console.WriteLine("\n ---------------- \n");
Console.WriteLine("Search Students by name: \n");
Console.WriteLine("Insert the name of the student you want to search: ");
string searchName = Console.ReadLine() ?? string.Empty;

foreach (Student student in students)
{
    if (student.Name == searchName)
    {
        Console.WriteLine($"Student: {student.Name} {student.Surname} {student.DateOfBirth} {student.ClassName} {student.Grades}");
    }
}

// Search Teachers by name
Console.WriteLine("\n ---------------- \n");
Console.WriteLine("Search Teachers by name: \n");
Console.WriteLine("Insert the name of the teacher you want to search: ");
string searchTeacher = Console.ReadLine() ?? string.Empty;

foreach (Teacher teacher in teachers)
{
    if (teacher.Name == searchTeacher)
    {
        Console.WriteLine($"Teacher: {teacher.Name} {teacher.Surname} {teacher.DateOfBirth} {teacher.Subject} {teacher.IsContracted}");
    }
}

// Search Teachers by subject
Console.WriteLine("\n ---------------- \n");
Console.WriteLine("Search Teachers by subject: \n");
Console.WriteLine("Insert the subject of the teacher you want to search: ");
string searchSubject = (Console.ReadLine() ?? string.Empty).ToLower();

foreach (Teacher teacher in teachers)
{
    if (teacher.Subject.ToLower() == searchSubject)
    {
        Console.WriteLine($"Teacher: {teacher.Name} {teacher.Surname} {teacher.DateOfBirth} {teacher.Subject} {teacher.IsContracted}");
    }
}

// Search Teachers by contract
Console.WriteLine("\n ---------------- \n");
Console.WriteLine("Search Teachers by contract: \n");
Console.WriteLine("Please indicate S for contracted teachers and N for not contracted teachers: ");
string searchContract = (Console.ReadLine() ?? string.Empty).ToUpper();

foreach (Teacher teacher in teachers)
{
    if (searchContract == "S" && teacher.IsContracted)
    {
        Console.WriteLine($"Teacher: {teacher.Name} {teacher.Surname} {teacher.DateOfBirth} {teacher.Subject} {teacher.IsContracted}");
    }
    else if (searchContract == "N" && !teacher.IsContracted)
    {
        Console.WriteLine($"Teacher: {teacher.Name} {teacher.Surname} {teacher.DateOfBirth} {teacher.Subject} {teacher.IsContracted}");
    }
}

// Search Students by class
Console.WriteLine("\n ---------------- \n");
Console.WriteLine("Search Students by class: \n");
Console.WriteLine("Insert the class of the student you want to search: ");
string searchClass = (Console.ReadLine() ?? string.Empty).ToUpper();

foreach (Student student in students)
{
    if (student.ClassName.ToUpper() == searchClass)
    {
        Console.WriteLine($"Student: {student.Name} {student.Surname} {student.DateOfBirth} {student.ClassName} {student.Grades}");
    }
}

