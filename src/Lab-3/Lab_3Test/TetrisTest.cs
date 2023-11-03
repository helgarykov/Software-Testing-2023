using Lab_3;
namespace Lab_3Test;


public class Tests
{
    
    [Test]
    public void TestGetWidthAndHeightReturnsCorrect()
    {
        // GIVEN
        Board newBoard = new Board();
        
        string input = 
            "7 8\n" +
            "..p....." +
            "\n.ppp...." +
            "\n..p....." +
            "\n........" +
            "\n...#...." +
            "\n...#...#" +
            "\n#..#####";
        string[] lines = input.Split("\n");
        
        // WHEN
        newBoard.GetWidthAndHeight(lines);
        
        // THEN
        Assert.That(newBoard.Width, Is.EqualTo(8), "width is not 8");
        Assert.That(newBoard.Height, Is.EqualTo(7), "height is not 7");
    }
    
    [Test]
    public void GetFigureFromFile_ShouldReturnExpectedCells()
    {
        // GIVEN
        List<Cell> expectedFigure = new List<Cell>()
        {
            new Cell(0, 2),
            new Cell(1, 1),
            new Cell(1, 2),
            new Cell(1, 3),
            new Cell(2, 2)
        }; 
        
        string input = 
            "7 8\n" +
            "..p....." +
            "\n.ppp...." +
            "\n..p....." +
            "\n........" +
            "\n...#...." +
            "\n...#...#" +
            "\n#..#####";
        string[] lines = input.Split("\n");
        Board newBoard = new Board();
        
        // WHEN
        List<Cell> actualFigure = newBoard.GetFigureAndLandscape(lines,true);
        
        // THEN
       Assert.That(expectedFigure, Is.EqualTo(actualFigure), "figure is not as expected");
    }
    
    [Test]
    public void GetLandscapeFromFile_ShouldReturnExpectedCells()
    {
        // GIVEN
        List<Cell> expectedLandscape = new List<Cell>()
        {
            new Cell(4, 3),
            new Cell(5, 3),
            new Cell(5, 7),
            new Cell(6, 0),
            new Cell(6, 3),
            new Cell(6, 4),
            new Cell(6, 5),
            new Cell(6, 6),
            new Cell(6, 7)
        }; 
        
        string input = 
            "7 8\n" +
            "..p....." +
            "\n.ppp...." +
            "\n..p....." +
            "\n........" +
            "\n...#...." +
            "\n...#...#" +
            "\n#..#####";
        string[] lines = input.Split("\n");
        Board newBoard = new Board();
        
        // WHEN
        List<Cell> actualLandscape = newBoard.GetFigureAndLandscape(lines,false);
        
        // THEN
        Assert.That(expectedLandscape, Is.EqualTo(actualLandscape), "landscape is not as expected");
    }
    [Test]
    public void ProcessFigureOneCycleTest()
    {
        // GIVEN
        
        string input = 
            "7 8\n" +
            "..p....." +
            "\n.ppp...." +
            "\n..p....." +
            "\n........" +
            "\n...#...." +
            "\n...#...#" +
            "\n#..#####";
        string[] lines = input.Split("\n");
        Board newBoard = new Board(lines);
        
        List<Cell> originalFigure = newBoard.GetFigureAndLandscape(lines,true);
        List<Cell> expectedFigure = originalFigure;
        foreach (var cell in expectedFigure)
        {
            cell.X++;
        }
        
        // WHEN
        newBoard.ProcessFigureOneCycle();
        
        
        // THEN
        Assert.That(expectedFigure, Is.EqualTo(newBoard.Figure), "figure is not as expected");
    }
    //TODO: add another test of ProcessFigureOneCycleTest ALSO delegates and stringBuilder.
    
}