public class Statistics
{
    public double Sum;
    public double High;
    public double Low;
    public int Counter;
    public int Rise;

    public Statistics()
    {
        Sum = 0;
        High = double.MinValue;
        Low = double.MaxValue;
        Rise = 0;
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

    public void RiseIs()
    {
        switch (Average)
        {
            case var d when d >= 5.75:
                Rise = 1000;
                break;

            case var d when d >= 4.75:
                Rise = 800;
                break;

            case var d when d >= 3.75:
                Rise = 600;
                break;

            case var d when d >= 2.75:
                Rise = 100;
                break;

            case var d when d >= 1.75:
                Rise = 50;
                break;

            default:
                Rise = 0;
                break;

        }
    }
}