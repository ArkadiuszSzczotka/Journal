public abstract class Person
{
    private string name;
    public string Name
    {
        get { return name; }
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Name can not be empty");
            }

            foreach (char c in value)
            {
                if (char.IsDigit(c))
                {
                    throw new ArgumentException($"Invalid argument {nameof(name)}");
                }
            }

            this.name = value;
        }
    }

    public Person(string name)
    {
        this.Name = name;
    }
}