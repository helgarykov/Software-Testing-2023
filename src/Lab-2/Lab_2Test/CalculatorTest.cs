using Lab_2;
using System.Text.RegularExpressions;

namespace Lab_2Test;
/// <summary>
/// Contains test methods for evaluating the functionality of a simple calculator program.
/// </summary>
/// <remarks>
/// The SimpleCalcTests class provides several test methods to ensure that the calculator
/// handles input/output files correctly and performs calculations as expected. It also checks
/// for appropriate error handling and logging.
/// </remarks>
public class SimpleCalcTests
{
    /// <summary>
    /// Provides test cases for input and output files and their expected outcomes.
    /// </summary>
    /// <returns>An IEnumerable of TestCaseData containing input file, output file, expected error message, and actual key.</returns>
    /// <remarks>
    /// The method uses the yield return statement to return each set of test parameters
    /// one at a time.
    /// </remarks>
    public static IEnumerable<TestCaseData> TestInputAndOutputFilesWithErrors()
    {
        
            string basePath = TestContext.CurrentContext.TestDirectory;
            basePath = Directory.GetParent(basePath)!.ToString();
            basePath = Directory.GetParent(basePath)!.ToString();
            basePath = Directory.GetParent(basePath)!.ToString();
            basePath = Directory.GetParent(basePath)!.ToString();
            string relativePath = "Lab_2Test/InputOutputWithErrors"; // Set the relative path to your InputsTest directory
            string fullPath = Path.Combine(basePath, relativePath);

            yield return new TestCaseData(Path.Combine(fullPath, "Input1.txt"),
                Path.Combine(fullPath, "Output1.txt"), "Error: Invalid input : {key}.", "25");
            yield return new TestCaseData(Path.Combine(fullPath, "Input2.txt"), 
                Path.Combine(fullPath, "Output2.txt"), "Error: Invalid input: 1st operand or 2nd operand.",
                "Error: Invalid input: 1st operator or 2nd operator.");
            yield return new TestCaseData(Path.Combine(fullPath, "Input3.txt"),
                Path.Combine(fullPath, "Output3.txt"), "Error: Invalid input, equality sign is missing.",
                "Error: Invalid input, equality sign is missing.");
            yield return new TestCaseData(Path.Combine(fullPath, "Input4.txt"), Path.Combine(fullPath, "Output4.txt"),
                "Error: Cannot divide by zero.", "Error: Cannot divide by zero.");
            yield return new TestCaseData(Path.Combine(fullPath, "Input5.txt"), Path.Combine(fullPath, "Output5.txt"),
                "Error: Invalid input : 1.2.", "Error: Invalid input : 1.2.");
            yield return new TestCaseData(Path.Combine(fullPath, "Input6.txt"), Path.Combine(fullPath, "Output6.txt"),
                "Error: Invalid input: expected a number, but was {first}", "0");
            
    }
    
    public static IEnumerable<TestCaseData> TestInputAndOutputFilesNoErrors()
    {
        
        string basePath = TestContext.CurrentContext.TestDirectory;
        basePath = Directory.GetParent(basePath)!.ToString();
        basePath = Directory.GetParent(basePath)!.ToString();
        basePath = Directory.GetParent(basePath)!.ToString();
        basePath = Directory.GetParent(basePath)!.ToString();
        string relativePath = "Lab_2Test/InputOutputNoErrors"; // Set the relative path to your InputsTest directory
        string fullPath = Path.Combine(basePath, relativePath);

       yield return new TestCaseData(Path.Combine(fullPath, "Input1.txt"),
           Path.Combine(fullPath, "Output1.txt"), "9");
       yield return new TestCaseData(Path.Combine(fullPath, "Input2.txt"), 
           Path.Combine(fullPath, "Output2.txt"), "10");
       yield return new TestCaseData(Path.Combine(fullPath, "Input3.txt"), 
           Path.Combine(fullPath, "Output3.txt"), "16949");
       yield return new TestCaseData(Path.Combine(fullPath, "Input4.txt"), 
           Path.Combine(fullPath, "Output4.txt"), "24320832");
       yield return new TestCaseData(Path.Combine(fullPath, "Input5.txt"), 
           Path.Combine(fullPath, "Output5.txt"), "0");
       yield return new TestCaseData(Path.Combine(fullPath, "Input6.txt"), 
           Path.Combine(fullPath, "Output6.txt"), "-90");
       yield return new TestCaseData(Path.Combine(fullPath, "Input7.txt"), 
           Path.Combine(fullPath, "Output7.txt"), "579");
    }
    
    /// <summary>
    /// Tests if the input and output files specified in the test cases exist.
    /// </summary>
    /// <param name="inputFile">The path to the input file.</param>
    /// <param name="outputFile">The path to the output file.</param>
    /// <param name="unused1">Unused parameter, kept for consistency with the TestCaseData.</param>
    /// <param name="unused2">Unused parameter, kept for consistency with the TestCaseData.</param>
    /// <remarks>
    /// This test ensures that the input and output files used in the tests actually exist. 
    /// </remarks>
    [Test]
    [TestCaseSource(nameof(TestInputAndOutputFilesWithErrors))]
    public void FileExistsTest(string inputFile, string outputFile, string unused1, string unused2)
    {
        Console.WriteLine("Checking if files exist: " + inputFile, outputFile);
        Assert.IsTrue(File.Exists(inputFile), $"File does not exist: {inputFile}");
        Assert.IsTrue(File.Exists(outputFile), $"File does not exist: {inputFile}");
        Assert.IsTrue(File.Exists(outputFile), $"File does not exist: {inputFile}");
        Assert.IsTrue(File.Exists(outputFile), $"File does not exist: {inputFile}");
        Assert.IsTrue(File.Exists(outputFile), $"File does not exist: {inputFile}");
    }

    [Test]
    [TestCaseSource(nameof(TestInputAndOutputFilesNoErrors))]
    public void FileExistsTest2(string inputFile, string outputFile, string _)
    {
        Assert.IsTrue(File.Exists(inputFile), $"File does not exist: {inputFile}");
        Assert.IsTrue(File.Exists(outputFile), $"File does not exist: {inputFile}");
        Assert.IsTrue(File.Exists(outputFile), $"File does not exist: {inputFile}");
        Assert.IsTrue(File.Exists(outputFile), $"File does not exist: {inputFile}");
        Assert.IsTrue(File.Exists(outputFile), $"File does not exist: {inputFile}");
        Assert.IsTrue(File.Exists(outputFile), $"File does not exist: {inputFile}");
        Assert.IsTrue(File.Exists(outputFile), $"File does not exist: {inputFile}");
    }
    
    
    /// <summary>
    /// Tests the calculator's ability to perform calculations and handle errors.
    /// </summary>
    /// <param name="inputFile">The path to the input file containing the calculations.</param>
    /// <param name="outputFile">The path to the output file where results or errors are written.</param>
    /// <param name="expectedErrorMessageTemplate">The template for the expected error message.</param>
    /// <param name="actualKey">The actual key to replace in the expected error message template.</param>
    /// <remarks>
    /// This test reads an input file, performs calculations or error handling based on that input,
    /// and then validates the output file against expected results or error messages.
    /// </remarks>
    [Test]
    [TestCaseSource(nameof(TestInputAndOutputFilesWithErrors))]
    public void CalculateAndHandleKeyPressTestFails(string inputFile, string outputFile, string expectedErrorMessageTemplate, string actualKey)
    {
        // Clears the contents of the output file to ensure a clean slate for the test.
        File.WriteAllText(outputFile, string.Empty); 
        CalculatorState calculator = new CalculatorState(outputFile);
        string? inputFromFile = Program.ReadInputFromFileOrReturnNull(inputFile, outputFile);
        string[] parsedInput = Program.Parse(inputFromFile, outputFile);

        calculator.Calculate(parsedInput);  

        // Read the outputFile 
        string logContents = File.ReadAllText(outputFile);
    
        // Replace {key} OR {first} in the expectedErrorMessageTemplate with the actual key 
        // string expectedErrorMessage = expectedErrorMessageTemplate
        //     .Replace("{key}", actualKey)
        //     .Replace("{first}", actualKey);
        
        // Alternatively, use regex to replace both {key} and {first} with actualKey:
        string expectedErrorMessage = Regex.Replace
            (expectedErrorMessageTemplate, 
                @"\{key\}|\{first\}", 
                actualKey);
        
        Assert.IsTrue(logContents.Contains(expectedErrorMessage));
    }
    
    [Test]
    [TestCaseSource(nameof(TestInputAndOutputFilesNoErrors))]
    public void CalculateAndHandleKeyPressTestSucceed(string inputFile, string outputFile, string expectedResult)
    {
        // Arrange
        File.WriteAllText(outputFile, string.Empty);    // Clear up the contents of the output file 
        CalculatorState calculator = new CalculatorState(outputFile);
        string? inputFromFile = Program.ReadInputFromFileOrReturnNull(inputFile, outputFile);
        string[] parsedInput = Program.Parse(inputFromFile, outputFile);
        
        // Act
        calculator.Calculate(parsedInput);  
        string actualResult = File.ReadAllText(outputFile);  // Read the output file 
        
        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
    
}