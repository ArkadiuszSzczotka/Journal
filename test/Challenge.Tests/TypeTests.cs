namespace Challenge.Tests;    

public class TypeTests
{
    [Fact]
    public void GetEmployeeReturnsDifferentObjects()
    {
        var emp1 = GetEmployee("Arek", DateTime.Today);
        var emp2 = GetEmployee("Edie", DateTime.Today);

        Assert.NotSame(emp1, emp2);
        Assert.False(Object.ReferenceEquals(emp1, emp2));
    }

    [Fact]
    public void TwoVariableCanReferenceSameObject()
    {
        var emp1 = GetEmployee("Adam", DateTime.Today);
        var emp2 = emp1;

        Assert.Same(emp1, emp2);
        Assert.True(Object.ReferenceEquals(emp1, emp2));
    }

    [Fact]
    public void ChangeVariableInsideMethodTests()
    {
        var x = 1;
        ChangeX(out x);
        Assert.NotEqual(1, x);
    }

    private Employee GetEmployee(string name, DateTime date)
    {
        return new Employee(name, date);
    }

    private void ChangeX(out int v)
    {
        v = 2;
    }

}

