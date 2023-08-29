namespace Lab_1;

public abstract class Program
{
    public static void Main()
    {
        // Your file path here
        string filePath = "/Users/helgarykov/Documents/Summer23/src/Lab-1/Lab_1/InputGame.txt";
        
        
        // string? filePath = Environment.GetEnvironmentVariable("FILE_PATH");
        //
        // if (string.IsNullOrEmpty(filePath))
        // {
        //     throw new Exception("FILE_PATH environment variable is not set");
        // }
        //
        // if (!File.Exists(filePath))
        // {
        //     throw new Exception($"File not found: {filePath}");
        // }

     
        int[,]? field = Translator.ReadFieldValues(filePath);

        if (field != null)
        {
            Translator.PrintField(field);
        }

        if (field != null)
        {
            Grid grid = new Grid(field);
        }
    }
}