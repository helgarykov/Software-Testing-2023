using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Text;

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
   // private bool figureOrLands.


   public Board()
   {
       
   }
   public Board(string[] lines)
   {
       GetLandscapeFromFile(lines);
       GetFigureFromFile(lines);
       GetWidthAndHeight(lines);
   }
   public Board(Board otherBoard)
   {
       figure = new List<Cell>();
       landscape = new List<Cell>();
       Width = otherBoard.Width;
       Height = otherBoard.Height;
       foreach (var cell in otherBoard.figure)
       {
           this.figure.Add(new Cell(cell)); 
       }
       foreach (var cell in otherBoard.landscape)
       {
           this.landscape.Add(new Cell(cell)); 
       }
   }
   public override bool Equals(object? obj)
   {
       if (obj is Board other)
       {
           for (int i = 0; i < this.figure.Count; i++)
           {
               if (!(this.figure[i].Equals(other.figure[i])))
               {
                   return false;
               }
           }
           return true;
       }
       return false;
   }
    public void GetWidthAndHeight(string[] file)
    {
        string[] dimensions = file[0].Split(' ');
        Height = int.Parse(dimensions[0]);  
        Width = int.Parse(dimensions[1]); 
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
    
    public void GetFigureFromFile(string[] file)
    {
        figure = GetFigureAndLandscape(file, true);
    }
    
    public void GetLandscapeFromFile(string[] file)
    {
        landscape = GetFigureAndLandscape(file, false);
    }

    public char[,] BoardToText()
    {
        char[,] strBoard = new char[Height, Width];
        Cell cell = new Cell();
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                cell.X = i;
                cell.Y = j;
                if (figure.Contains(cell))
                {
                    strBoard[i, j] = 'p';
                }else if(landscape.Contains(cell))
                {
                    strBoard[i, j] = '#';
                }
                else
                {
                    strBoard[i, j] = '.';    
                }
                
            }
        }

        return strBoard;
    }

    public static void BoardTxtToConsole(char[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(board[i,j]);
            }
            Console.WriteLine();
        }
    }
    public static void BoardTxtToFile( string path, char[,] board)
    {
        string[] result = new string[board.GetLength(0)];
        StringBuilder sb;
        
        for (int i = 0; i < board.GetLength(0); i++)
        {
            sb = new StringBuilder();
            for (int j = 0; j < board.GetLength(1); j++)
            {
                sb.Append(board[i, j]);
            }

            result[i] = sb.ToString();
        }
        
        File.WriteAllLines(path,result);
    }

    public void PrintFigureOrLandscapeWithCoordinates(List<Cell> list)
    {
        foreach (var cell in list)
        {
            Console.Write($"({cell.X}, {cell.Y}) ");
        }
        Console.WriteLine();
    }
    
    public void PrintFigure()
    {
        foreach (var cell in figure)
        {
            Console.Write($"({cell.X}, {cell.Y}) ");
        }
        Console.WriteLine();
    }

    public void ProcessFigureOneCycle()
    {
        foreach (var cell in figure)
        {
            if (cell.X+1 >= Height)
            {
                return;
            }

            foreach (var cellLandscape in landscape)
            {
                if (cell.X + 1 >= cellLandscape.X && cell.Y == cellLandscape.Y)
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

    public void ProcessFigureSeveralCycles()
    {
        Board previousState;
        do
        {
            Console.Write("hellou\n");
            previousState = new Board(this);
            ProcessFigureOneCycle();
            PrintFigure();
        } while (!(this.Equals(previousState)));
    }
    
    
    // TODO : delegates, code doubling?
    
}

