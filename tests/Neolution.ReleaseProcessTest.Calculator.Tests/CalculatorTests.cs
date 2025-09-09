using Shouldly;
using Xunit;

namespace Neolution.ReleaseProcessTest.Calculator.Tests;

/// <summary>
/// Unit tests for the Calculator class
/// </summary>
public class CalculatorTests
{
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(10.5, 2.5, 13)]
    public void Add_ShouldReturnCorrectSum(double a, double b, double expected)
    {
        // Act
        var result = _calculator.Add(a, b);

        // Assert
        result.ShouldBe(expected);
    }

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
}