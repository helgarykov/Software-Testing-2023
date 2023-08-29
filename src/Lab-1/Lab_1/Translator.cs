namespace Lab_1;

public static class Translator
{
    private static string filePath { get; }

    static Translator()
    {
        filePath = Directory.GetCurrentDirectory();
        filePath = (Directory.GetParent(filePath)).ToString();
        filePath = (Directory.GetParent(filePath)).ToString();
    
        Console.WriteLine(Directory.GetParent(filePath));
    }
    // Check if file exists
  
    
    
    
    public static int[,]? ReadFieldValues(string? filePath)
    {
        // Check if file exists
         if (!File.Exists(filePath))
         {
             Console.WriteLine("File not found.");
             return null;
         }
        
        try {
      
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length > 1)
            {
                string[] dimensions = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (dimensions.Length >= 2)
                {
                    var fieldHeight = int.Parse(dimensions[0]);
                    var fieldWidth = int.Parse(dimensions[1]);
        
                    // Create a 2D-array
                    int[,]? field = new int[fieldHeight, fieldWidth];
            
                    // Read the remaining lines into the 2D-array
                    for (int i = 2; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        for (int j = 0; j < line.Length; j++)
                        {
                            // Parse the character using a separate function
                            int cellValue = CharParser(line[j]);

                            if (cellValue == -1)
                            {
                                Console.Write($"Invalid character in the field: {line[j]}.");
                                return null;
                            }

                            field[i - 2, j] = cellValue;
                        }
                    }
                    return field;                             //return new[] { generationsCount, fieldWidth, fieldHight };
                }
                Console.WriteLine("The second line must contain at least 2 numbers.");
            }
            Console.WriteLine("File is empty.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error while reading file: {e.Message}");
        }
        return null;
    }

        private static int CharParser(char e)
        {
            return e switch
            {
                'x' => 1,
                '.' => 0,
                _ => -1
            };
        }

        public static void PrintField(int[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
}