using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

namespace Lab_3;
/// TODO :
/// 1. Read the screen dimensions and store them.
/// 2. Read the initial screen state and create two collections:
/// one with the "figure" points, and another with "landscape" points.
/// A point is a data structure that contains the coordinates of a single pixel.
/// 3. Collect the screen dimensions, "figure", and "landscape" into one data
/// structure (for example, a class) that we will call "field".
/// 4. Create a function that takes the "field" as input, shifts each pixel of the
/// "figure" one position down, and checks if the new coordinate overlaps with
/// one of the "landscape" pixels or goes out of the field bounds. If it overlaps
/// or goes out - it returns the unchanged state of the "field", if not - it
/// returns the new state of the "field" (with the shifted "figure").
/// 5. Create a function that cyclically calls the function from the previous step
/// until the "field" stops changing.
/// 6. Create a function that returns the "field" in textual form.
/// 7. Output the result to a file.

public class Board 
{
    public int Width;
    public int Height;
    private List<Cell> figure;
    private List<Cell> landscape;

    public void GetWidthAndHeight(string[] file)
    {
        string[] dimensions = file[0].Split(' ');
        Width = int.Parse(dimensions[0]);  
        Height = int.Parse(dimensions[1]); 
    }
    
    public List<Cell> GetFigureFromFile(string[] file)
    {
        List<Cell> figure = new List<Cell>();
        for (int i = 1; i < file.Length; i++)
        {
            string line = file[i];
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == '.' || line[j] == '#')
                {
                    continue;
                }

                if (line[j] == 'p')
                {
                    Cell cell = new Cell(i, j);
                    cell.X = i;
                    cell.Y = j;
                    figure.Add(cell);
                }
                else
                {
                    Console.WriteLine($"Info at line {i + 1}, column {j + 1}: Character is {line[j]}");
                }
            }
        } return figure;
    }

    
    public List<Cell> GetLandscape(string[] file)
    {
        List<Cell> landscape = new List<Cell>();
        for (int i = 1; i < file.Length; i++)
        {
            string line = file[i];
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == '.' || line[j] == 'p')
                {
                    continue;
                }

                if (line[j] == '#')
                {
                    Cell cell = new Cell(i, j);
                    cell.X = i;
                    cell.Y = j;
                    landscape.Add(cell);
                }
                else
                {
                    Console.WriteLine($"Info at line {i + 1}, column {j + 1}: Character is {line[j]}");
                }
            }
        } return landscape;
    }

    public void PrintFigureOrLandscapeWithCoordinates(List<Cell> list)
    {
        foreach (var cell in list)
        {
            Console.WriteLine($"Cell at coordinates X: {cell.X}, Y: {cell.Y}");
        }
    }
    
}

