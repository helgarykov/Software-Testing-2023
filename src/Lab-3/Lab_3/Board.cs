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

public class giBoard 
{
    public int Width;
    public int Height;
    private List<Cell> figure;
    private List<Cell> landscape;
   // private bool figureOrLands.

    public void GetWidthAndHeight(string[] file)
    {
        string[] dimensions = file[0].Split(' ');
        Width = int.Parse(dimensions[0]);  
        Height = int.Parse(dimensions[1]); 
    }

    // 1 = figure; 0 = landscape
    private List<Cell> GetFigureAndLandscape(string[] file, bool figureOrLands)
    {
        List<Cell> result = new List<Cell>();
        char searchedCharacter;
        if (figureOrLands)
        {
            searchedCharacter = 'p';
        }
        else
        {
            searchedCharacter = '#';
        }
        for (int i = 1; i < file.Length; i++)
        {
            string line = file[i];
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == searchedCharacter)
                {
                    Cell cell = new Cell(i - 1, j);
                    result.Add(cell);
                }
            }
        } return result;
    }
    
    public List<Cell> GetFigureFromFile(string[] file)
    {
        return GetFigureAndLandscape(file, true);
    }
    
    public List<Cell> GetLandscapeFromFile(string[] file)
    {
        return GetFigureAndLandscape(file, false);
    }

    public void PrintFigureOrLandscapeWithCoordinates(List<Cell> list)
    {
        foreach (var cell in list)
        {
            Console.Write($"({cell.X}, {cell.Y}) ");
        }
        Console.WriteLine();
    }

    public void ProcessFigureOneCycle()
    {
        foreach (var cell in figure)
        {
            if (!(cell.X+1 < Width && cell.Y+1 < Height))
            {
                return;
            }

            foreach (var cellLandscape in landscape)
            {
                if (!(cell.X + 1 < cellLandscape.X && cell.Y + 1 < cellLandscape.Y))
                {
                    return;
                }
            }
        }

        foreach (var cell in figure)
        {
            cell.X += 1;
        }
    }
    
    // TODO : delegates, code doubling?
    
}

