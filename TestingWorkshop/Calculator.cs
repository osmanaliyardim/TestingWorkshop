namespace TestingWorkshop;

public class Calculator
{
    public int AddNumbers(int num1, int num2)
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
}
