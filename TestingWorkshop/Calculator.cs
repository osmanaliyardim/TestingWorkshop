namespace TestingWorkshop;

public class Calculator
{
    public List<int> NumberRange = new();

    public int AddNumbers(int num1, int num2)
    {
        return num1 + num2;
    }

    public double AddDoubleNumbers(double num1, double num2)
    {
        return num1 + num2;
    }

    public int SubstractNumbers(int num1, int num2)
    {
        return num1 - num2;
    }

    public int MultiplyNumbers(int num1, int num2)
    {
        return num1 * num2;
    }

    public int DivideNumbers(int num1, int num2)
    {
        return num1 / num2;
    }

    public bool IsNumberOdd(int num)
    {
        return num % 2 != 0;
    }

    public bool IsNumberEven(int num)
    {
        return num % 2 == 0;
    }

    public List<int> GetOddRange(int min, int max)
    {
        NumberRange.Clear();

        for (int i = min; i <= max; i++)
        {
            if (i % 2 != 0)
            {
                NumberRange.Add(i);
            }
        }

        return NumberRange;
    }
}
