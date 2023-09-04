namespace Lab_1;

public class Grid 
{
    private int[,]? Field { get; }
    private int Width { get; set; }
    private int Height { get; set; }

    
    
    public Grid (int[,]? field)
    {
        Field = field;
        Height = field!.GetLength(0); // nr of rows
        Width = field.GetLength(1);  // nr of columns
    }

    public int GetNextGenerationCellState(Cell cell)
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
            if (Field![cellInNeighbour.X, cellInNeighbour.Y] == 1)
            {
                numberOfLiveNeighbours++;
            }  
        }

        if (Field![cell.X, cell.Y] == 1)
        {
            numberOfLiveNeighbours--;

            if (numberOfLiveNeighbours >= 2 && numberOfLiveNeighbours <= 3)
            {
                return 1;
            }

            return 0;
        }

        if (Field[cell.X, cell.Y] == 0)
        {
            if (numberOfLiveNeighbours == 3)
            {
                return 1;
            }

            return 0;
        }
        return 0;
    }
    
    /// <summary>
    /// A helper method called by GetNextGenerationCellState().
    /// Handles cases placed on the borders of the field.
    /// </summary>
    /// <param name="cell"></param>
    /// <returns></returns>
    
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

    public int[,] GetNextGenerationField()
    {
        int[,] newField = new int[Height, Width];

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                newField[i,j] = GetNextGenerationCellState(new Cell(i, j));
            }
        }
        return newField;
    }
    
    public int[,] GetGivenGenerationField(int numOfGen)
    {
        int[,] newField = new int[1,1];
        int count = 0;
        while (count < numOfGen)
        {
            // Call GetNextGenerationField with the current state of the field
            newField = GetNextGenerationField();
            count++;
        }
        return newField;
    }
    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// Overrides the build-in Equals(). To be done: Add override GetHashCode().
    /// <param name="obj">The object to compare its contents with the contents of the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
    /// </summary>
    public override bool Equals(object obj)
    {
        if (!(obj is Grid otherGrid))
        {
            return false;
        }
        if (!(Height == otherGrid.Height || Width == otherGrid.Width))
        {
            return false;
        }

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (Field![i, j] != otherGrid.Field![i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}

/// Comment on if-statements: use if-st with cases of different nature;
/// interrelated variants are to be handled by if-elseif-else statements.