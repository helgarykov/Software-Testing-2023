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

    public void GetWidthAndHeight(string[] lines)
    {
        string[] dimensions = lines[0].Split(' ');
        Width = int.Parse(dimensions[0]);  
        Height = int.Parse(dimensions[1]); 
    }
    
}