public delegate void GradeLowerThanThreeAdded(object sender, EventArgs args);


public abstract class EmployeeBase : Person, IEmployee
{
    public EmployeeBase(string name) : base(name)
    { }

    public abstract event GradeLowerThanThreeAdded GradeAddedLowerThanThree;

    public abstract void AddGrade(string grade);

    public abstract Statistics GetStatistics();

    public abstract void PrintStatistics();

    public virtual double ReturnGrade(string input)
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
        return grade;
    }
}