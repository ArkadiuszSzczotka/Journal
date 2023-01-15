public delegate void GradeLowerThanThreeAdded(object sender, EventArgs args);

public class Employee : EmployeeBase
{
    public override event GradeLowerThanThreeAdded GradeAddedLowerThanThree;
    
    private List<double> grades = new List<double>();

    public Employee(string name, DateTime date) : base(name, date)
    {
    }
    
    public Employee(string name) : base(name)
    {
    }

    public override DateTime SetDateOfBirth()
    {
        DateTime birthDay;
        Console.WriteLine("Enter date of birth as day/month/year");

        string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                    "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy"};

        while (!DateTime.TryParseExact(Console.ReadLine(), formats,
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None,
            out birthDay))
        {
            Console.WriteLine("Your input is incorrect. Please input again.");
        }
        return birthDay;
    }

    public override void AddGrade(string input)
    {
        var grade = input switch
        {
            "1" or "F" or "f" => 1,
            "-2" or "2-" or "-E" or "E-" or "-e" or "e-" => 1.75,
            "2" or "E" or "e" => 2,
            "+2" or "2+" or "+E" or "E+" or "+e" or "e+" => 2.5,
            "-3" or "3-" or "-D" or "D-" or "-d" or "d-" => 2.75,
            "3" or "D" or "d" => 3,
            "+3" or "3+" or "+D" or "D+" or "+d" or "d+" => 3.5,
            "-4" or "4-" or "-C" or "C-" or "-c" or "c-" => 3.75,
            "4" or "C" or "c" => 4,
            "+4" or "4+" or "+C" or "C+" or "+c" or "c+" => 4.5,
            "-5" or "5-" or "-B" or "B-" or "-b" or "b-" => 4.75,
            "5" or "B" or "b" => 5,
            "+5" or "5+" or "+B" or "B+" or "+b" or "b+" => 5.5,
            "-6" or "6-" or "-A" or "A-" or "-a" or "a-" => 5.75,
            "6" or "A" or "a" => 6,

            _ => throw new ArgumentException($"Ivalid {nameof(input)}."),
        };
        this.grades.Add(grade);

        if (grade < 3 && GradeAddedLowerThanThree is not null)
        {
            GradeAddedLowerThanThree(this, new EventArgs());
        }
    }

    public void RemoveLastGrade()
    {
        this.grades.RemoveAt(grades.Count - 1);
    }

    public int GetListSize()
    {
        return grades.Count;
    }

    public void AddGrade(double grade)
    {
        if (grade >= 1 && grade <= 6)
        {
            this.grades.Add(grade);
        }
        else
        {
            throw new ArgumentException($"{nameof(grade)} is out of range");
        }
    }

    public void PrintStatistics()
    {
        var result = 0.0;
        var minGrade = double.MaxValue;
        var maxGrade = double.MinValue;

        foreach (var n in grades)
        {
            maxGrade = Math.Max(n, maxGrade);
            minGrade = Math.Min(n, minGrade);
            result += n;
        }
        result /= grades.Count;

        System.Console.WriteLine($"Average: {result:N2}");
        System.Console.WriteLine($"Low: {minGrade}");
        System.Console.WriteLine($"High: {maxGrade}");
    }

    public override Statistics GetStatistics()
    {
        var result = new Statistics();
        result.Average = 0.0;
        result.Low = double.MaxValue;
        result.High = double.MinValue;

        foreach (var grade in grades)
        {
            result.High = Math.Max(grade, result.High);
            result.Low = Math.Min(grade, result.Low);
            result.Average += grade;
        }
        result.Average /= grades.Count;

        switch(result.Average)
        {
            case var d when d >= 5.75:
                result.Letter = 'A';
                break;
            
            case var d when d >= 4.75:
                result.Letter = 'B';
                break;

            case var d when d >= 3.75:
                result.Letter = 'C';
                break;

            case var d when d >= 2.75:
                result.Letter = 'D';
                break;

            case var d when d >= 1.75:
                result.Letter = 'E';
                break;

            default:
                result.Letter = 'F';
                break;

        }

        return result;
    }
}