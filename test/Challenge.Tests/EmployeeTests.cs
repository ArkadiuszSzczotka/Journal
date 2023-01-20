namespace Challenge.Tests;

public class EmployeeTests
{
    [Fact]
    public void StatisticsGoodResult()
    {
        var emp = new Employee("Arek");
        emp.AddGrade(2);
        emp.AddGrade(4);
        emp.AddGrade(6);

        var result = emp.GetStatistics();

        Assert.Equal(4, result.Average, 1);
        Assert.Equal(6, result.High);
        Assert.Equal(2, result.Low);
    }

    [Fact]
    public void IsLastGradeRemoved()
    {
        var emp1 = new Employee("Zuzia");
        emp1.AddGrade(6);
        emp1.AddGrade(5.5);
        int listSizeBefore = emp1.GetListSize();

        emp1.RemoveLastGrade();

        Assert.Equal(listSizeBefore - 1, emp1.GetListSize());
    }
}