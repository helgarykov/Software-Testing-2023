namespace Lab_1;

public class Grid 
{
    
    public int[,]? Field { get; }
    public int Width { get; set; }
    public int Height { get; set; }

    
    
    public Grid (int[,]? field)
    {
        Field = field;
        Height = field.GetLength(0); // nr of rows
        Width = field.GetLength(1);  // nr of columns
    }
  

    public int GetNextGenerationCellState(int[,]? field, Cell cell)
    {
        // 1. Пройтись по соседним координатам: реактивный (V) и проактивный (агрессивный) метод.

        List<Cell> neighbours = new List<Cell>(8);

        for (int i = cell.X - 1; i <= cell.X + 1; i++)
        {
            for (int j = cell.Y - 1; j <= cell.Y + 1; j++)
            {
                neighbours.Add(GetNeighbourSpecialCase(new Cell(i, j)));
            }
        }

        int numberOfLiveNeighbours = 0;
        foreach (var cellInNeighbour in neighbours)
        {
            if (field[cellInNeighbour.X, cellInNeighbour.Y] == 1)
            {
                numberOfLiveNeighbours++;
            }  
        }

        if (field[cell.X, cell.Y] == 1)
        {
            numberOfLiveNeighbours--;

            if (numberOfLiveNeighbours >= 2 && numberOfLiveNeighbours <= 3)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        if (field[cell.X, cell.Y] == 0)
        {
            if (numberOfLiveNeighbours == 3)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        return 0;
    }

    
    private Cell GetNeighbourSpecialCase(Cell cell)
    {
        if (cell.X < 0)
        {
            cell.X = Height - 1;
        }

        else if (cell.X >= Height)
        {
            cell.X = cell.X - Height;
        }
        if (cell.Y < 0)
        {
            cell.Y = Width - 1;
        }
        else if (cell.Y >= Width)
        {
            cell.Y = cell.Y - Width;
        }
        return cell;
    }

    public int[,] GetNextGenerationField(int[,]? field)
    {
        int[,] newField = new int[Height, Width];

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                newField[i,j] = GetNextGenerationCellState(field, new Cell(i, j));
            }
        }
        return newField;
    }
    
    public int[,] GetGivenGenerationField(int[,] field, int numOfGen)
    {
        int count = 0;
        while (count < numOfGen)
        {
            // Call GetNextGenerationField with the current state of the field
            field = GetNextGenerationField(field);
            count++;
        }
        return field;
    }
    
    
    // This is a stub for your actual GetNextGenerationField implementation
    // public int[,] GetNextGenerationField(int[,] field)
    // {
    //     int[,] newField = new int[field.GetLength(0), field.GetLength(1)];
    //
    //     // Your logic to populate newField based on field goes here...
    //
    //     return newField;
    // }
    
    /*public int[,] GetGivenGenerationField(int[,] field, int numOfGen)
    {

        int count = 0;
        while (count < numOfGen)
        {
            // Call GetNextGenerationField with the current state of the field
            int[,] nextField = GetNextGenerationField(field);
            
            // Update the current field to the new generation, create a copy of nextField and assign it to var field
            field = (int[,]) nextField.Clone();

            count++;

        }
        return field;
    }*/
}