public sealed class Employee : EmployeeBase
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

            "1+" or "F+" => 1.5,
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

    public override void PrintStatistics()
    {   
        var stats = GetStatistics();
        if(stats.Counter != 0)
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
    }

    public override Statistics GetStatistics()
    {
        var result = new Statistics();

        foreach (var grade in grades)
        {
            result.Add(grade);
        }

        return result;
    }
}