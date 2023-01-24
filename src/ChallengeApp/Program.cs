Console.WriteLine("Welcome to your Journal");

bool isRunning = true;

while(isRunning)
{
    Console.WriteLine("Please choose that if your Journal should save grades for employee or student to text file nor should. Enter q for quit (Y/N/q).");

    var input = Console.ReadLine().ToLower();

    switch (input)
    {
        case "y":
            AddGradeToFile();
            break;
        case "n":
            AddGradeToMemory();
            break;
        case "q":
            isRunning = false;
            break;
        default:
            Console.WriteLine("Input is invalid");
            continue;
    }
}

static void AddGradeToFile()
{
    Console.WriteLine("Please type in employee's name.");

    var employee = Console.ReadLine();

    if (!String.IsNullOrEmpty(employee))
    {
        var employeeInFile = new EmployeeInFile (employee);
        employeeInFile.GradeAddedLowerThanThree += OnGradeLowerThanThreeAdded;
        InsertGrade(employeeInFile);
        employeeInFile.PrintStatistics();
    }
    else
    {
        Console.WriteLine("Employee's name can not be empty.");
    }
}

static void AddGradeToMemory()
{
    Console.WriteLine("Please type in employee's name.");

    var employee = Console.ReadLine();

    if (!String.IsNullOrEmpty(employee))
    {
        var employeeInMemory = new Employee(employee);
        employeeInMemory.GradeAddedLowerThanThree += OnGradeLowerThanThreeAdded;
        InsertGrade(employeeInMemory);
        employeeInMemory.PrintStatistics();
    }
    else
    {
        Console.WriteLine("Employee's name can not be empty.");
    }
}

static void InsertGrade(IEmployee employee)
{
    while (true)
    {
        Console.WriteLine($"Enter grade for {employee.Name}:");
        var input = Console.ReadLine().ToLower();

        if (input == "q" || input == "Q")
        {
            break;
        }
        try
        {
            employee.AddGrade(input);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Insert q for quit.");
        }
    }
}

static void OnGradeLowerThanThreeAdded(object sender, EventArgs args)
{
    Console.WriteLine($"We must inform that your employee may not get a rise.");
}