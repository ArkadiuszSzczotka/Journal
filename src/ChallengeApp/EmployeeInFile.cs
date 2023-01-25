using System.Runtime.CompilerServices;
using System.Text;

public sealed class EmployeeInFile : EmployeeBase
{    
    private const string fileName = "grades.txt";

    public EmployeeInFile (string name) : base (name)
    { }

    public override event GradeLowerThanThreeAdded GradeAddedLowerThanThree;

    public override void AddGrade(string input)
    {
        var grade = input.ToUpper() switch
        {
            "1" or "F" => 1,
            "2" or "E" => 2,
            "3" or "D" => 3,
            "4" or "C" => 4,
            "5" or "B" => 5,
            "6" or "A" => 6,

            "2-" or "E-" => 1.75,
            "3-" or "D-" => 2.75,
            "4-" or "C-" => 3.75,
            "5-" or "B-" => 4.75,
            "6-" or "A-" => 5.75,

            "1+" or "F+" => 1.5,
            "2+" or "E+" => 2.5,
            "3+" or "D+" => 3.5,
            "4+" or "C+" => 4.5,
            "5+" or "B+" => 5.5,

            _ => throw new ArgumentException($"Ivalid {nameof(input)}."),
        };

        using (var writer = File.AppendText(fileName))
        using (var writer2 = File.AppendText("audit.txt"))
        {
            writer.WriteLine(grade);
            writer2.WriteLine($"{grade}    {DateTime.UtcNow}");

            if (grade < 3 && GradeAddedLowerThanThree is not null)
            {
                GradeAddedLowerThanThree(this, new EventArgs());
            }
        }
    }

    public override Statistics GetStatistics()
    {
        var result = new Statistics();

        if (File.Exists($"{fileName}"))
        {
            using (var reader = File.OpenText($"{fileName}"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
        }

        return result;
    }

    public override void PrintStatistics()
    {
        var stats = GetStatistics();
        if (stats.Counter != 0)
        {
            Console.WriteLine($"""
                {Name}'s statistics are:
                {stats.Counter} is a number of grades,
                {stats.High} is the highest grade,
                {stats.Low} is the lowest grade,
                {stats.Average:N2} is a average, 
                {stats.Rise} is a possible rise.
                """);
        }
        else
        {
            Console.WriteLine($"Could not get statistics for {Name} because there no grade has been added.");
        }

        StringBuilder message = new StringBuilder($"{Name}'s grades:\n");

        using (var reader = File.OpenText(($"{fileName}")))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                message.Append($"{line}\n ");
                line = reader.ReadLine();
            }
        }
        Console.WriteLine($"\n{message}");
    }
}
