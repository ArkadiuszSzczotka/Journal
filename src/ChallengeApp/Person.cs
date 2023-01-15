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
                throw new ArgumentException($"Invalid argument {nameof(name)}");
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

    public Person(string name, DateTime date) : this(name)
    {
        this.dateOfBirth = date;
    }

    private DateTime dateOfBirth;
    public DateTime DateOfBirth
    {
        get { return dateOfBirth; }
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Inavlid date of birth");
            }
            else
            {
                dateOfBirth = value;
            }
        }
    }
    public abstract DateTime SetDateOfBirth();
}