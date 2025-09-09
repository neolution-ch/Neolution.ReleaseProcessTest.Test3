using Shouldly;
using Xunit;

namespace Neolution.ReleaseProcessTest.Calculator.Tests;

/// <summary>
/// Unit tests for the Calculator class
/// </summary>
public class CalculatorTests
{
    private readonly Calculator _calculator;

    /// <summary>
    /// Initializes a new instance of the CalculatorTests class.
    /// Sets up the Calculator instance for testing.
    /// </summary>
    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    /// <summary>
    /// Tests that the Add method returns the correct sum for various inputs.
    /// </summary>
    /// <param name="a">First number to add.</param>
    /// <param name="b">Second number to add.</param>
    /// <param name="expected">Expected sum result.</param>
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(10.5, 2.5, 13)]
    public void Add_ShouldReturnCorrectSum(double a, double b, double expected)
    {
        // Act
        _calculator.Add(a, b, out double result);

        // Assert
        result.ShouldBe(expected);
    }

    /// <summary>
    /// Tests that the Subtract method returns the correct difference for various inputs.
    /// </summary>
    /// <param name="a">Minuend.</param>
    /// <param name="b">Subtrahend.</param>
    /// <param name="expected">Expected difference result.</param>
    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(-1, 1, -2)]
    [InlineData(0, 0, 0)]
    [InlineData(10.5, 2.5, 8)]
    public void Subtract_ShouldReturnCorrectDifference(double a, double b, double expected)
    {
        // Act
        var result = _calculator.Subtract(a, b);

        // Assert
        result.ShouldBe(expected);
    }

    /// <summary>
    /// Tests that the Multiply method returns the correct product for various inputs.
    /// </summary>
    /// <param name="a">First factor.</param>
    /// <param name="b">Second factor.</param>
    /// <param name="expected">Expected product result.</param>
    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(-1, 1, -1)]
    [InlineData(0, 5, 0)]
    [InlineData(10.5, 2, 21)]
    public void Multiply_ShouldReturnCorrectProduct(double a, double b, double expected)
    {
        // Act
        var result = _calculator.Multiply(a, b);

        // Assert
        result.ShouldBe(expected);
    }

    /// <summary>
    /// Tests that the Divide method returns the correct quotient for various inputs.
    /// </summary>
    /// <param name="a">Dividend.</param>
    /// <param name="b">Divisor.</param>
    /// <param name="expected">Expected quotient result.</param>
    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(10, 2, 5)]
    [InlineData(7.5, 2.5, 3)]
    public void Divide_ShouldReturnCorrectQuotient(double a, double b, double expected)
    {
        // Act
        var result = _calculator.Divide(a, b);

        // Assert
        result.ShouldBe(expected);
    }

    /// <summary>
    /// Tests that the Divide method throws DivideByZeroException when dividing by zero.
    /// </summary>
    [Fact]
    public void Divide_ShouldThrowDivideByZeroException_WhenDividingByZero()
    {
        // Act & Assert
        Should.Throw<DivideByZeroException>(() => _calculator.Divide(5, 0));
    }

    /// <summary>
    /// Tests that the Power method returns the correct result for various inputs.
    /// </summary>
    /// <param name="base">Base number.</param>
    /// <param name="exponent">Exponent.</param>
    /// <param name="expected">Expected power result.</param>
    [Theory]
    [InlineData(2, 3, 8)]
    [InlineData(5, 0, 1)]
    [InlineData(4, 0.5, 2)]
    public void Power_ShouldReturnCorrectResult(double @base, double exponent, double expected)
    {
        // Act
        var result = _calculator.Power(@base, exponent);

        // Assert
        result.ShouldBe(expected);
    }

    /// <summary>
    /// Tests that the SquareRoot method returns the correct result for various inputs.
    /// </summary>
    /// <param name="value">Input value.</param>
    /// <param name="expected">Expected square root result.</param>
    [Theory]
    [InlineData(4, 2)]
    [InlineData(9, 3)]
    [InlineData(2.25, 1.5)]
    public void SquareRoot_ShouldReturnCorrectResult(double value, double expected)
    {
        // Act
        var result = _calculator.SquareRoot(value);

        // Assert
        result.ShouldBe(expected);
    }

    /// <summary>
    /// Tests that the SquareRoot method throws ArgumentException for negative values.
    /// </summary>
    [Fact]
    public void SquareRoot_ShouldThrowArgumentException_ForNegativeValue()
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => _calculator.SquareRoot(-1));
    }

    /// <summary>
    /// Tests that the Logarithm method returns the correct result for various inputs.
    /// </summary>
    /// <param name="value">Input value.</param>
    /// <param name="expected">Expected logarithm result.</param>
    [Theory]
    [InlineData(1, 0)]
    [InlineData(2.718281828459045, 1)] // e ≈ 2.718
    [InlineData(10, 2.302585092994046)] // ln(10) ≈ 2.3026
    public void Logarithm_ShouldReturnCorrectResult(double value, double expected)
    {
        // Act
        var result = _calculator.Logarithm(value);

        // Assert
        result.ShouldBe(expected, 1e-10); // Allow small floating point tolerance
    }

    /// <summary>
    /// Tests that the Logarithm method throws ArgumentException for non-positive values.
    /// </summary>
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Logarithm_ShouldThrowArgumentException_ForNonPositiveValue(double value)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => _calculator.Logarithm(value));
    }
}