public delegate void GradeLowerThanThreeAdded(object sender, EventArgs args);

public class Employee : EmployeeBase
{
    public override event GradeLowerThanThreeAdded GradeAddedLowerThanThree;
    
    private List<double> grades = new List<double>();

    public Employee(string name) : base(name)
    {
    }

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

            "1+" or "F+" => 2.5,
            "2+" or "E+" => 2.5,
            "3+" or "D+" => 3.5,
            "4+" or "C+" => 4.5,
            "5+" or "B+" => 5.5,

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