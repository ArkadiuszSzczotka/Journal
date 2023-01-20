Console.WriteLine("Please input name");
var name = Console.ReadLine();

var employee = new Employee(name);

employee.GradeAddedLowerThanThree += OnGradeLowerThanThreeAdded;

while (true)
{
    Console.WriteLine($"Enter grade(s) for {employee.Name} or press q for quit. Or empty and hit enter to close program.");
    var input = Console.ReadLine();

    if(string.IsNullOrEmpty(input) || input == "q" || input == "Q")
    {
        break;
    }

    try
    {
        employee.AddGrade(input);
    }

    catch(FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }

    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }

    var stats = employee.GetStatistics();

    Console.WriteLine($"Average: {stats.Average:N2}");
    Console.WriteLine($"Low: {stats.Low}");
    Console.WriteLine($"High: {stats.High}");
    Console.WriteLine($"Letter: {stats.Letter}");
}

static void OnGradeLowerThanThreeAdded(object sender, EventArgs args)
{
    Console.WriteLine($"We must inform that your employee may not get a rise.");
}






