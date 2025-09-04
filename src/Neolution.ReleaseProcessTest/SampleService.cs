namespace Neolution.ReleaseProcessTest;

/// <summary>
/// A sample service class for testing the release process
/// </summary>
public class SampleService
{
    /// <summary>
    /// Gets a greeting message
    /// </summary>
    /// <param name="name">The name to greet</param>
    /// <returns>A greeting message</returns>
    public string GetGreeting(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        return $"Hello, {name}! This is Neolution.ReleaseProcessTest library.";
    }

    /// <summary>
    /// Calculates the sum of two integers
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>The sum of a and b</returns>
    public int Add(int a, int b)
    {
        return a + b;
    }
}