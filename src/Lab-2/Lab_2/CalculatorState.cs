namespace Lab_2;

public class CalculatorState
{
    public int screen;
    public int first_number;
    public char op;
    public bool start_new_number = true;
    public CalculatorPhase LastPhaseReached { get; set; }
    public CalculatorPhase currentPhase = CalculatorPhase.WaitingForFirstOperand;

    public static void HandleKeyPress(CalculatorState calc, char key)
{
    switch (calc.currentPhase)
    {
        case CalculatorPhase.WaitingForFirstOperand:
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
                // Transition to the next phase
                calc.currentPhase = CalculatorPhase.WaitingForOperator;
                calc.start_new_number = true; // prepare for a new number
                HandleKeyPress(calc, key); // Recursively handle the key press
            }
            else
            {
                ErrorMessageWriteToFile("Expected a digit or operator.");
            }
            break;

        case CalculatorPhase.WaitingForOperator:
            if (key is '+' or '-' or '*' or '/')
            {
                // Process operator
                calc.op = key;
                calc.currentPhase = CalculatorPhase.WaitingForSecondOperand;
                calc.start_new_number = true; // prepare for a new number
            }
            else
            {
                ErrorMessageWriteToFile("Expected an operator.");
            }
            break;

        case CalculatorPhase.WaitingForSecondOperand:
            if (char.IsDigit(key))
            {
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
                // Transition to the next phase
                calc.currentPhase = CalculatorPhase.WaitingForEqualsOperator;
                calc.LastPhaseReached = calc.currentPhase; 
                HandleKeyPress(calc, key); // Recursively handle the key press
            }
            else
            {
                ErrorMessageWriteToFile("Expected a digit or '='.");
            }
            break;

        case CalculatorPhase.WaitingForEqualsOperator:
            if (key == '=')
            {
                // Perform calculation
                int result = PerformCalculation(calc.first_number, calc.screen, calc.op);
                calc.screen = result; // store result in screen
                WriteResultToFile(result);
                calc.currentPhase = CalculatorPhase.WaitingForFirstOperand; // reset to initial state
                calc.LastPhaseReached = calc.currentPhase; 
                calc.start_new_number = true; // prepare for a new number
            }
            else
            {
                ErrorMessageWriteToFile("Expected '='.");
            }
            break;
    }
}

    private static int PerformCalculation(int first, int second, char op)
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
                if (second != 0)
                {
                    result = first / second;
                }
                else
                {
                    ErrorMessageWriteToFile("Cannot divide by zero.");
                }
                break;
        }
        return result;
    }

    public static void Calculate(string[] input)
    {
        CalculatorState calculator = new CalculatorState();
        for (int i = 0; i < input.Length; i++)
        {
            string currentString = input[i];
            if (string.IsNullOrEmpty(currentString))
            {
                continue;  // Skip empty strings
            }
            // If the current string contains more than one character, it's invalid
            if (currentString.Length > 1)
            {
                Console.WriteLine($"Invalid input : {currentString}");
                continue;  // Skip to the next iteration of the loop
            }
            char currentChar = currentString[0];
            HandleKeyPress(calculator, currentChar);
        }
        if (calculator.LastPhaseReached != CalculatorPhase.WaitingForEqualsOperator)
        {
            ErrorMessageWriteToFile("Invalid input, equality sign is missing.");
        }
    }

    private static void WriteResultToFile(int result)
    {
        try
        {
            string filePath = Directory.GetCurrentDirectory();
            filePath = Directory.GetParent(filePath)!.ToString();
            filePath = Directory.GetParent(filePath)!.ToString();
            filePath = Directory.GetParent(filePath)!.ToString();
            filePath += "/Output.txt";
            
            // This will write the result
            File.WriteAllText(filePath, result.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occured when writing to file: " + ex.Message);
        }
    }

    public static void ErrorMessageWriteToFile(string message)
    {
        string path = Directory.GetCurrentDirectory();
        path = Directory.GetParent(path)!.ToString();
        path = Directory.GetParent(path)!.ToString();
        path = Directory.GetParent(path)!.ToString();
        path += "/Output.txt";
        File.AppendAllText(path, $"Error: {message}\n");
    }
}


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

// Предыдущая рабочая версия HandleKeyPress():
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
        
// Previous property op with a setter-method:
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