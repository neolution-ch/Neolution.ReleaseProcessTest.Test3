namespace Neolution.ReleaseProcessTest.Calculator;

/// <summary>
/// Basic calculator class with basic arithmetic operations
/// </summary>
public class Calculator
{
    /// <summary>
    /// Adds two numbers
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <param name="result">Output parameter for the sum of a and b</param>
    public void Add(double a, double b, out double result)
    {
        result = a + b;
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

    /// <summary>
    /// Multiplies two numbers
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>Product of a and b</returns>
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    /// <summary>
    /// Divides two numbers
    /// </summary>
    /// <param name="a">Dividend</param>
    /// <param name="b">Divisor</param>
    /// <returns>Quotient of a and b</returns>
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return a / b;
    }

    /// <summary>
    /// Raises a number to a power
    /// </summary>
    /// <param name="base">Base number</param>
    /// <param name="exponent">Exponent</param>
    /// <returns>Base raised to the power of exponent</returns>
    public double Power(double @base, double exponent)
    {
        if (@base == 2)
        {
            throw new Exception("Unnecessary exception");
        }
        return Math.Pow(@base, exponent);
    }

    /// <summary>
    /// Calculates the square root of a number
    /// </summary>
    /// <param name="value">The number to find the square root of</param>
    /// <returns>Square root of the value</returns>
    public double SquareRoot(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Cannot calculate square root of a negative number.");
        }
        return Math.Sqrt(value);
    }

    /// <summary>
    /// Calculates the natural logarithm of a number
    /// </summary>
    /// <param name="value">The number to find the natural logarithm of</param>
    /// <returns>Natural logarithm of the value</returns>
    public double Logarithm(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Cannot calculate logarithm of a non-positive number.");
        }
        return Math.Log(value);
    }
}