// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



string filePath = Directory.GetCurrentDirectory();
filePath = Directory.GetParent(filePath)!.ToString();
filePath = Directory.GetParent(filePath)!.ToString();
filePath = Directory.GetParent(filePath)!.ToString();
filePath += "/Input1.txt";

string[] lines = File.ReadAllLines(filePath);
string[] dimentions = lines[0].Split(' ');
int width = Int32.Parse(dimentions[0]);
int height = Int32.Parse(dimentions[1]);

public class Board
{
    public int Width;
    public int Height;

    public void GetWidthAndHeight(string[] lines)
    {
        string[] dimentions = lines[0].Split(' ');
        Width = Int32.Parse(dimentions[0]);  
        Height = Int32.Parse(dimentions[1]); 
    }
}


