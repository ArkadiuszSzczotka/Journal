public interface IEmployee
{
    void AddGrade(string grade);

    Statistics GetStatistics();

    void PrintStatistics();

    string Name { get; }

    event GradeLowerThanThreeAdded GradeAddedLowerThanThree;
}