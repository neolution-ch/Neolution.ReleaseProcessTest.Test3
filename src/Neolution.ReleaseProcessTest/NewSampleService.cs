namespace Neolution.ReleaseProcessTest;

/// <summary>
/// A new sample service class for testing the release process v1.0.0-alpha.3.
/// This class provides enhanced operations and new features.
/// </summary>
public class NewSampleService
{
    /// <summary>
    /// New feature for v1.0.0-alpha.3: Generates a list of personalized greetings.
    /// </summary>
    /// <param name="names">List of names to greet. Must not be null or empty.</param>
    /// <param name="style">Greeting style (e.g., "formal", "casual").</param>
    /// <returns>List of greeting messages</returns>
    /// <exception cref="ArgumentException">Thrown when names is null or empty.</exception>
    public List<string> GetGreetingList(List<string> names, string style = "casual")
    {
        try
        {
            if (names == null || names.Count == 0)
            {
                throw new ArgumentException("Names list cannot be null or empty.", nameof(names));
            }

            var greetings = new List<string>();
            foreach (var name in names)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(name);
                string prefix = style.ToLower() switch
                {
                    "formal" => "Greetings",
                    "casual" => "Hey",
                    _ => "Hello"
                };
                greetings.Add($"{prefix}, {name.Trim()}! Welcome to Neolution.ReleaseProcessTest Library.");
            }
            return greetings;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error in GetGreetingList: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error in GetGreetingList: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Enhanced calculation method for v1.0.0-alpha.3 with additional operations.
    /// </summary>
    /// <param name="numbers">List of numbers to process.</param>
    /// <returns>The sum of all numbers</returns>
    /// <exception cref="ArgumentException">Thrown when numbers is null or empty.</exception>
    public int SumNumbers(List<int> numbers)
    {
        try
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("Numbers list cannot be null or empty.", nameof(numbers));
            }

            checked
            {
                return numbers.Sum();
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"Overflow error in SumNumbers: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in SumNumbers: {ex.Message}");
            throw;
        }
    }
}