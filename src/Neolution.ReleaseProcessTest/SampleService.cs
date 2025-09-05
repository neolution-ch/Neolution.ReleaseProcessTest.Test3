namespace Neolution.ReleaseProcessTest;

/// <summary>
/// A sample service class for testing the release process.
/// This class provides basic operations and features for demonstration purposes.
/// </summary>
public class SampleService
{
    /// <summary>
    /// Gets a greeting message with improved error handling.
    /// </summary>
    /// <remarks>This method is part of the stable release preparation for v0.2.0.</remarks>
    /// <param name="name">The name to greet. Must not be null or whitespace.</param>
    /// <param name="capitalize">Whether to capitalize the greeting message.</param>
    /// <returns>A greeting message</returns>
    /// <exception cref="ArgumentException">Thrown when name is null or whitespace.</exception>
    public string GetGreeting(string name, bool capitalize = false)
    {
        try
        {
            // Fixed: Improved greeting message for v0.3.0
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            var greeting = $"Hello, {name.Trim()}! This is Neolution.ReleaseProcessTest Library.";
            return capitalize ? greeting.ToUpper() : greeting;
        }
        catch (ArgumentException ex)
        {
            // Log the error for stabilization
            Console.WriteLine($"Error in GetGreeting: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Calculates the sum of two integers with overflow checking.
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>The sum of a and b</returns>
    /// <exception cref="OverflowException">Thrown when the sum overflows.</exception>
    public int Add(int a, int b)
    {
        try
        {
            checked
            {
                return a + b;
            }
        }
        catch (OverflowException ex)
        {
            // Log the error for stabilization
            Console.WriteLine($"Error in Add: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Initial feature for alpha release with enhanced error handling.
    /// </summary>
    public void InitialFeature()
    {
        try
        {
            // Fixed: Added implementation to log feature execution
            Console.WriteLine("Initial feature executed successfully.");
            // Enhanced: Added additional logging for feature completion
            Console.WriteLine("Feature initialization completed with enhanced logging.");
        }
        catch (Exception ex)
        {
            // Log any unexpected errors for stabilization
            Console.WriteLine($"Error in InitialFeature: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Feature completion method for beta release with improved validation.
    /// </summary>
    /// <param name="input">Input parameter for processing. Must not be null or whitespace.</param>
    /// <returns>Processed result</returns>
    /// <exception cref="ArgumentException">Thrown when input is null or whitespace.</exception>
    public string FeatureCompletion(string input)
    {
        try
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(input);
            return $"Feature completed for input: {input}. Ready for beta release.";
        }
        catch (ArgumentException ex)
        {
            // Log the error for stabilization
            Console.WriteLine($"Error in FeatureCompletion: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Stabilization method to ensure service readiness for release candidate.
    /// Performs basic health checks and logs stabilization status.
    /// </summary>
    public void Stabilize()
    {
        try
        {
            // Perform basic stabilization checks
            Console.WriteLine("Starting stabilization process...");
            // Check if service is operational
            var testGreeting = GetGreeting("Test");
            Console.WriteLine($"Stabilization check passed: {testGreeting}");
            Console.WriteLine("Service stabilized successfully for release candidate.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Stabilization failed: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// New feature for v0.2.0 with enhanced functionality and input validation.
    /// </summary>
    /// <param name="message">The message to process. Must not be null or whitespace.</param>
    /// <exception cref="ArgumentException">Thrown when message is null or whitespace.</exception>
    public void NewFeatureForV020(string message)
    {
        try
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            Console.WriteLine($"New feature for v0.2.0 executed with message: {message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error in NewFeatureForV020: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in NewFeatureForV020: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Related functionality for v0.2.0 feature completion.
    /// Processes the message and returns an enhanced result with uppercase transformation.
    /// </summary>
    /// <param name="message">The message to process. Must not be null or whitespace.</param>
    /// <returns>The processed message in uppercase with prefix.</returns>
    /// <exception cref="ArgumentException">Thrown when message is null or whitespace.</exception>
    public string GetProcessedMessage(string message)
    {
        try
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(message);
            NewFeatureForV020(message);
            return $"Processed: {message.ToUpper()}";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error in GetProcessedMessage: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetProcessedMessage: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Advanced greeting method for v1.0.0-alpha.1 with enhanced customization options.
    /// </summary>
    /// <param name="name">The name to greet. Must not be null or whitespace.</param>
    /// <param name="style">The greeting style (e.g., "formal", "casual").</param>
    /// <returns>A customized greeting message</returns>
    /// <exception cref="ArgumentException">Thrown when name is null or whitespace.</exception>
    public string GetAdvancedGreeting(string name, string style = "casual")
    {
        try
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(style);

            string baseGreeting = GetGreeting(name);
            string prefix = style.ToLower() switch
            {
                "formal" => "Greetings",
                "casual" => "Hey",
                _ => "Hello"
            };

            return $"{prefix}, {name.Trim()}! {baseGreeting.Replace("Hello", "").TrimStart()}";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error in GetAdvancedGreeting: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error in GetAdvancedGreeting: {ex.Message}");
            throw;
        }
    }
}