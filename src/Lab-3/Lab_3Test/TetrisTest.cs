namespace Lab_3Test;


public class Tests
{
    
    [Test]
    public void TestGetWidthAndHeightReturnsCorrect()
    {
        // Set
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
        
        // When
        newBoard.GetWidthAndHeight(lines);
        
        // Then
        Assert.That(newBoard.Width, Is.EqualTo(7), "width is not 7");
        Assert.That(newBoard.Height, Is.EqualTo(8), "height is not 8");
    }
}