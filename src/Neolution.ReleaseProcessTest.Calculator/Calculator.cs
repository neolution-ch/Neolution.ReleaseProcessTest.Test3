namespace Neolution.ReleaseProcessTest.Calculator;

/// <summary>
/// Basic calculator class with arithmetic operations
/// </summary>
public class Calculator
{
    /// <summary>
    /// Adds two numbers
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>Sum of a and b</returns>
    public double Add(double a, double b)
    {
        return a + b;
    }

    /// <summary>
    /// Subtracts two numbers
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>Difference of a and b</returns>
    public double Subtract(double a, double b)
    {
        return a - b;
    }
}