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
        
        int[,]? fieldFromTxt = Translator.ReadFieldValues(filePath);
        Grid gridToPrint = new Grid(fieldFromTxt);
        int[,] fieldToPrint = gridToPrint.GetGivenGenerationField(3);
        Translator.PrintField(fieldToPrint);
    }
}