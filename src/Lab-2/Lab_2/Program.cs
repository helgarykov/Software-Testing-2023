using System.Xml;
using Lab_2;

public abstract class Program
{
        public static string? ReadInputFromFileOrReturnNull(string filePath, string outputFile)
        {
            // Check if file exists
            if (!File.Exists(filePath))
            {
                CalculatorState.ErrorMessageWriteToFile("File not found.", outputFile);
                return null;
            }
            string?[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                CalculatorState.ErrorMessageWriteToFile("No valid input. Add input to file.", outputFile);
                return null;
            }
            if (lines.Length > 1)
            {
                CalculatorState.ErrorMessageWriteToFile("Expected string length should be one line.", outputFile);
                return null;
            }
            return lines[0];
        }
    
        public static string[] Parse(string? input, string outputFile)
        {
            if (input == null)
            {
                CalculatorState.ErrorMessageWriteToFile("\n No input to parse.", outputFile);
                return Array.Empty<string>();  // Return an empty string array
            }
            return input!.Split(' ');
        }
    public static void Main()
    {
        string filePath = Directory.GetCurrentDirectory();
        filePath = Directory.GetParent(filePath)!.ToString();
        filePath = Directory.GetParent(filePath)!.ToString();
        filePath = Directory.GetParent(filePath)!.ToString();
        filePath += "/Input.txt";
        
        // Clean up the output.txt before compiling
        string outputFilePath = Directory.GetCurrentDirectory();
        outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
        outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
        outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
        outputFilePath += "/Output.txt";
        
        // This will clean the file
        File.WriteAllText(outputFilePath, string.Empty);
        
        string? inputFromFile = ReadInputFromFileOrReturnNull(filePath, outputFilePath);
        string[] parsedInput = Parse(inputFromFile, outputFilePath);
        CalculatorState calculate = new CalculatorState(outputFilePath);
        calculate.Calculate(parsedInput);
    }
}

