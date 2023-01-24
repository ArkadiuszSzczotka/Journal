public class Statistics
{
    private double Sum;
    public double High;
    public double Low;
    public int Counter;

    public Statistics()
    {
        Sum = 0;
        High = double.MinValue;
        Low = double.MaxValue;
        Counter = 0;
    }

    public double Average
    {
        get
        {
            return Sum / Counter;
        }
    }

    public void Add(double number)
    {
        Sum += number;
        Counter += 1;
        Low = Math.Min(number, Low);
        High = Math.Max(number, High);
    }

    public int Rise
    {
        get
        { 
            switch (Average)
            {
                case var d when d >= 5.75:
                    return 1000;

                case var d when d >= 4.75:
                    return 800;

                case var d when d >= 3.75:
                    return 600;

                case var d when d >= 2.75:
                    return 100;

                case var d when d >= 1.75:
                    return 50;

                default:
                    return 0;

            }
        }
    }
}