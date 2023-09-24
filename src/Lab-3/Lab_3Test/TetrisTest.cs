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
        Assert.That(newBoard.Width, Is.EqualTo(7), "width is not 7");
        Assert.That(newBoard.Height, Is.EqualTo(8), "height is not 8");
    }
    
    [Test]
    public void GetFigureFromFile_ShouldReturnExpectedCells()
    {
        // GIVEN
        List<Cell> expectedFigure = new List<Cell>()
        {
            new Cell(1, 2),
            new Cell(2, 1),
            new Cell(2, 2),
            new Cell(2, 3),
            new Cell(3, 2)
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
        List<Cell> actualFigure = newBoard.GetFigureFromFile(lines);
        
        // THEN
       Assert.That(expectedFigure, Is.EqualTo(actualFigure), "figure is not as expected");
    }
    
    [Test]
    public void GetLandscapeFromFile_ShouldReturnExpectedCells()
    {
        // GIVEN
        List<Cell> expectedLandscape = new List<Cell>()
        {
            new Cell(5, 3),
            new Cell(6, 3),
            new Cell(6, 7),
            new Cell(7, 0),
            new Cell(7, 3),
            new Cell(7, 4),
            new Cell(7, 5),
            new Cell(7, 6),
            new Cell(7, 7)
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
        List<Cell> actualLandscape = newBoard.GetLandscapeFromFile(lines);
        
        // THEN
        Assert.That(expectedLandscape, Is.EqualTo(actualLandscape), "landscape is not as expected");
    }
}