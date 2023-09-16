namespace Lab_2;

/// <summary>
/// Represents the state of a simplified keyboard calculator.
/// 
/// Calculator Keys:
/// ● "0" ... "9" -- entering a digit
/// ● "+", "-", "*", "/" -- performing arithmetic operations on integers
/// ● "=" -- executing the operation
/// 
/// To simplify the task, we introduce the following limitations that are absent in a regular calculator:
/// ● Calculations are performed on integers (int, not float, not double),
/// ● The user can only enter a sequence of digits, then an operation, then digits again, then "=".
///     Any other sequence of keys is prohibited.
/// 
/// Input Format:
/// The input file contains the names of the keys pressed by the user. Key names are separated by a
/// single space character.
/// 
/// Output Format:
/// The output file contains one number — the result of the calculations, which is displayed on the screen.
/// </summary>
public class CalculatorState
{
    private int screen;
    private int first_number;
    private char op;
    private bool start_new_number = true;
    public bool HasErrorOccurred { get; set; } = false;
    
    /// <remarks>
    /// This property is used to validate that the calculator reached the final phase of calculation, 
    /// represented by <see cref="CalculatorPhase.WaitingForEqualsOperator"/>. If the calculator did
    /// not reach this phase, an error message is written to indicate that the equality symbol '='
    /// is missing in the input.
    /// </remarks>
    private CalculatorPhase LastPhaseReached { get; set; }
    private CalculatorPhase currentPhase = CalculatorPhase.WaitingForFirstOperand;
    public string OutputFile { get;}
    public CalculatorState(string outputFile)
    {
        OutputFile = outputFile;
    }
    
    /// <summary>
    /// HandleKeyPress method processes a keypress according to the current calculator phase.
    /// </summary>
    /// <param name="calc">An instance of the CalculatorState class.</param>
    /// <param name="key">The key that was pressed.</param>
    /// <remarks>
    /// The <see cref="CalculatorPhase"/> of the CalculatorState determines how the key press is handled.
    /// </remarks>
    private static void HandleKeyPress(CalculatorState calc, char key)
    {
        calc.LastPhaseReached = calc.currentPhase;  // Always update the last phase reached
        switch (calc.currentPhase)
        {
            case CalculatorPhase.WaitingForFirstOperand:
                try
                {
                    if (char.IsDigit(key))
                    {
                        // Process first operand, build up the number
                        if (calc.start_new_number)
                        {
                            calc.first_number = Int32.Parse(key.ToString());
                            calc.start_new_number = false;
                        }
                        else
                        {
                            calc.first_number *= 10;
                            calc.first_number += Int32.Parse(key.ToString());
                        }
                    }
                    else if (key is '+' or '-' or '*' or '/')
                    {
                        // Detected an operator; change the phase.
                        calc.op = key;
                        calc.currentPhase = CalculatorPhase.WaitingForSecondOperand;
                        calc.start_new_number = true; // prepare for a new number
                    }
                    else
                    {
                        throw new InvalidOperationException("Expected a digit or operator, but was " + key);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    ErrorMessageWriteToFile(ex.Message, calc.OutputFile);
                    calc.HasErrorOccurred = true; 
                    
                }
                break;

            case CalculatorPhase.WaitingForOperator:
                try
                {
                    if (key is '+' or '-' or '*' or '/')
                    {
                        // Process operator
                        calc.op = key;
                        calc.currentPhase = CalculatorPhase.WaitingForSecondOperand;
                        calc.start_new_number = true; // prepare for a new number
                    }
                    else
                    {
                        throw new InvalidOperationException("Expected an operator +, -, * or / but was " + key);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    ErrorMessageWriteToFile(ex.Message, calc.OutputFile);
                    calc.HasErrorOccurred = true;
                }
                break;

            case CalculatorPhase.WaitingForSecondOperand:

                try
                {
                    if (char.IsDigit(key))
                    {
                        // TODO : move this check to PerformCalculation. Now one of the tests DivideByZero fails.
                        // if (key == '0')
                        // {
                        //     throw new InvalidOperationException("Cannot divide by zero.");
                        // }
                        // Process second operand, build up the number
                        if (calc.start_new_number)
                        {
                            calc.screen = Int32.Parse(key.ToString());
                            calc.start_new_number = false;
                        }
                        else
                        {
                            calc.screen *= 10;
                            calc.screen += Int32.Parse(key.ToString());
                        }
                    }
                    else if (key == '=')
                    {
                        // Detected an operator; change the phase.
                        calc.op = key;
                        calc.currentPhase = CalculatorPhase.WaitingForEqualsOperator;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Expected a digit, but was " + key);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    ErrorMessageWriteToFile(ex.Message, calc.OutputFile);
                    calc.HasErrorOccurred = true;
                }
                break;

            case CalculatorPhase.WaitingForEqualsOperator:
                try
                {
                    if (key == '=')
                    {
                        // Perform calculation
                        int result = PerformCalculation(calc.first_number, calc.screen, calc.op, calc);
                        calc.screen = result; // store result in screen
                        WriteResultToFile(result, calc.OutputFile);
                    }
                    else
                    {
                        throw new InvalidOperationException("Expected '=', but was " + key);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    ErrorMessageWriteToFile(ex.Message, calc.OutputFile);
                    calc.HasErrorOccurred = true; 
                }
                break;
        }
    }
    
    
    /// <summary>
    /// Performs a basic calculation based on two operands and an operator.
    /// </summary>
    /// <param name="first">The first operand.</param>
    /// <param name="second">The second operand.</param>
    /// <param name="op">The operator to use for the calculation.</param>
    /// <returns>The result of the calculation.</returns>
    /// <exception cref="InvalidOperationException">Thrown when division by zero is attempted.</exception>
    private static int PerformCalculation(int first, int second, char op, CalculatorState calc)
    {
        int result = 0;
        switch (op)
        {
            case '+':
                result = first + second;
                break;
            case '-':
                result = first - second;
                break;
            case '*':
                result = first * second;
                break;
            case '/':
                try
                {
                    result = first / second;
                }
                catch (Exception ex)
                { 
                    ErrorMessageWriteToFile(ex.Message, calc.OutputFile);    // Optionally re-throw or handle other types of exceptions
                    calc.HasErrorOccurred = true;
                }
                break;
        }
        return result;
    }

    /// <summary>
    /// Processes a sequence of keypresses to perform a calculator operation.
    /// </summary>
    /// <param name="input">An array of strings, each representing a keypress.</param>
    /// <remarks>
    /// The method takes a string array as input and processes each string one at a time,
    /// treating it as a single keypress to a calculator.
    /// 
    /// The sequence of keypresses must adhere to the following:
    /// - Only integers are supported.
    /// - An operation consists of a sequence of digits, followed by an operator, then another sequence of digits, and finally the '=' sign.
    /// 
    /// Error messages are written to a file named "Output.txt" in case of invalid input.
    /// </remarks>
    /// <example>
    /// This is how you would call the Calculate method:
    /// <code>
    /// string[] input = new string[] { "2", "5", "/", "5", "=" };
    /// Calculate(input);
    /// </code>
    /// </example>
    public void Calculate(string[] input)
    {
        try
        {

            for (int i = 0; i < input.Length; i++)
            {
                string currentString = input[i];
                if (string.IsNullOrEmpty(currentString))
                {
                    continue; // Skip empty strings
                }

                // If the current string contains more than one character, it's invalid
                if (currentString.Length > 1)
                {
                    ErrorMessageWriteToFile($"Invalid input : {currentString}. Separate digits by a space.", OutputFile);
                    return; // Skip to the next iteration of the loop
                }

                char currentChar = currentString[0];
                HandleKeyPress(this, currentChar);
                if (this.HasErrorOccurred)
                {
                    return;
                }

            }
            // Check for missing "=" at the end of all inputs
            if (LastPhaseReached != CalculatorPhase.WaitingForEqualsOperator)
            {
                ErrorMessageWriteToFile("Invalid input, equality sign is missing.", OutputFile);
            }
        }
        catch (InvalidOperationException ex)
        {
            // Log ex.Message as well as any other information that might help you debug the issue
            ErrorMessageWriteToFile(ex.Message, OutputFile);
        }
    }

    /// <summary>
    /// Writes the calculation result to a file.
    /// </summary>
    /// <param name="result">The result of the calculation to be written to the file.</param>
    /// <param name="outputFile"></param>
    /// <remarks>
    /// This method overwrites the contents of a file named "Output.txt" located in Lab_2 directory 
    /// with the provided integer result.
    /// </remarks>
    /// <exception cref="Exception">Thrown when the method fails to write to the file.</exception>
    private static void WriteResultToFile(int result, string outputFile)
        {
            try
            {
                File.WriteAllText(outputFile, result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAn error occured when writing to file: " + ex.Message);
            }
        }

    /// <summary>
    /// Writes an error message to a file.
    /// </summary>
    /// <param name="message">The error message to write.</param>
    /// <param name="outputFile"></param>
    /// <remarks>
    /// This method appends the error message to a file named "Output.txt" located in Lab_2 directory.
    /// If the method fails to write the message, it prints an error to the console.
    /// </remarks>
    /// <exception cref="Exception">Thrown when the method fails to write to the file.</exception>
    public static void ErrorMessageWriteToFile(string message, string outputFile)
        {
            try
            {   
                File.AppendAllText(outputFile, $"Error: {message}\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Could not write to file: {ex.Message}");
            }
        }
}



/*
  ===============================================================================
  BEGIN BLOCK OF COMMENTED CODE

  Description:
  The following code snippets were intended for the initial version of Calculator
  that is not currently in use.

  Last Updated: 2023-09-07
  Author: Helga R. Ibsen
  ===============================================================================
*/

/* Вариант с проверкой результата деления.
 1. Если ресультат целое число, то...
 2. Иначе, результат дробное число и применяется соответственная логика.
 case '/':
if (calc.screen != 0)
{
    if (calc.first_number % calc.screen == 0)
    {   // The result is a whole number
        result = calc.first_number / calc.screen;
    }
    else
    {   // The result is not a whole number
        // But integer division "floors" the result
        result = calc.first_number / calc.screen;
    }

//Предыдущая рабочая версия HandleKeyPress():
private static void HandleKeyPress(CalculatorState calc, char key)
    {
        if (Char.IsNumber(key))
        {
            if (calc.start_new_number)
            {
                calc.screen = Int32.Parse(key.ToString());
                calc.start_new_number = false;
            }
            else
            {
                calc.screen *= 10;
                calc.screen += Int32.Parse(key.ToString());
                calc.start_new_number = false;
            }

            calc.isFirstKeyPress = false;
        }
        else if (calc.isFirstKeyPress)
        {
            ErrorMessageWriteToFile("Expected input should be an integer.");
        }
        else if (key is '+' or '-' or '*' or '/')
        {
            calc.op = key;          // double code on line 11-17.
            calc.start_new_number = true;
            calc.first_number = calc.screen;
        }
        // TODO: add a check for the absence of '='
        else if (key is '=')
        {
            int result = 0;
            switch (calc.op)
            {
                case '+':
                    result = calc.first_number + calc.screen;
                    break;
                case '-':
                    result = calc.first_number - calc.screen;
                    break;
                case '*':
                    result = calc.first_number * calc.screen;
                    break;
                case '/':
                    if (calc.screen != 0)
                    {
                        result = calc.first_number / calc.screen;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Unknown operation.");
                    return;
            }
            calc.screen = result;
            WriteResultToFile(result);
        }
        else
        {
            Console.WriteLine("Expected input should be an int.");
        }
        
//Previous property op with a setter-method:
public class CalculatorState
{
    private char _op;

    public char Op
    {
        get => _op;
        set
        {
            if (value is '+' or '-' or '*' or '/')
            {
                _op = value;
            }
            else
            {
                ErrorMessageWriteToFile("Invalid operator.");
            }
        }
    }
}*/

/*
  ===============================================================================
  END BLOCK OF COMMENTED CODE
  ===============================================================================
*/