public abstract class Person
{
    private string name;
    public string Name
    {
        get 
        {
            return name;
        }
        private set
        {
            this.name = value;
        }
    }

    public Person(string name)
    {
        this.Name = name;
    }
}