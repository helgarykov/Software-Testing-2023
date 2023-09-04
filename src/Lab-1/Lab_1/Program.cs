namespace Lab_1;

public abstract class Program
{
    public static void Main()
    {
        // Your file path here
        string filePath = Directory.GetCurrentDirectory();
        filePath = Directory.GetParent(filePath)!.ToString();
        filePath = Directory.GetParent(filePath)!.ToString();
        filePath = Directory.GetParent(filePath)!.ToString();
        filePath += "/InputGame.txt";
        
        int[,]? fieldFromTXT = Translator.ReadFieldValues(filePath);
        Grid gridToPrint = new Grid(fieldFromTXT);
        int[,] fieldToPrint = gridToPrint.GetGivenGenerationField(3);
        Translator.PrintField(fieldToPrint);
    }
}