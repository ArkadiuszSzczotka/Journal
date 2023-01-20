public abstract class EmployeeBase : Person, IEmployee
{
    public EmployeeBase(string name) : base(name)
    { }

    public abstract event GradeLowerThanThreeAdded GradeAddedLowerThanThree;

    public abstract void AddGrade(string grade);

    public abstract Statistics GetStatistics();
}