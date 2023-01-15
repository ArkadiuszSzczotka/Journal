Console.WriteLine("Please input name");
var name = Console.ReadLine();

if (string.IsNullOrEmpty(name))
{
    throw new ArgumentNullException(nameof(name), "Please insert something");
}

var employee = new Employee(name);

employee.DateOfBirth = employee.SetDateOfBirth();

employee.GradeAddedLowerThanThree += OnGradeLowerThanThreeAdded;

while (true)
{

    Console.WriteLine($"Enter grade(s) for {employee.Name} born {employee.DateOfBirth} or press q for quit.");
    var input = Console.ReadLine();

    if(string.IsNullOrEmpty(input))
    {
        throw new ArgumentNullException(nameof(input), "Please insert something");
    }
    else if (input == "q" || input == "Q")
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






