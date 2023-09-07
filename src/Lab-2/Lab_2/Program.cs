public abstract class Program
{
    public static void Main()
    {
        string input = "0 1 2 3 4 5 6 7 8 9 + - * / =";
        
        string[] result = Parse(input);

        // Print the result
        foreach (string keyName in result)
        {
            Console.WriteLine(keyName);
        }
        
        static string[] Parse(string? input)
        {
            return input!.Split(' ');
        }
    }
}

