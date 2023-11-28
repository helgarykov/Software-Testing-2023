namespace Lab_3;

public class Cell
{
    public int X;
    public int Y;

    public Cell( int x, int y)
    {
        X = x;
        Y = y;
    }
    public Cell( Cell otherCell)
    {
        X = otherCell.X;
        Y = otherCell.Y;
    }
    public Cell() {}
    
    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// This is especially important for testing to allow NUnit assertions to compare
    /// the content of Cell objects, not their references.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>
    /// true if the specified object is equal to the current object; otherwise, false.
    /// </returns>
    public override bool Equals(object? obj)
    {
        if (obj is Cell other)
        {
            return X == other.X && Y == other.Y;
        }
        return false;
    }
    
    /// <summary>
    /// Serves as the default hash function, deriving a hash code from the X and Y properties of the Cell object.
    /// This method is overridden to maintain hash code consistency between objects that are deemed equal by the 
    /// Equals method, which is important for objects used as keys in collections.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return (X, Y).GetHashCode();
    }
}