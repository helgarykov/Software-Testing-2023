namespace Lab_4Test;
using Lab_4F;


public class Tests
{


    [Test]
    public void TestGetRowOrColAfterMove()
    {
        // GIVEN
        Board newBoard = new Board();
        
        
        string[] lines = new[]
        {
            "0 0 0 0",      // 0, 8, 0, 8
            "2 0 2 8",
            "0 0 0 0",
            "0 4 0 8",
            "R U R"
        };

        // WHEN
        char[,] board = Board.GetField(lines);
        var column = Board.GetColumn(board, 3);     // 0808
        var resultCol = Board.GetRowOrColAfterMove(column, 'D');

        // THEN
        var expectedResultCol = new List<int> {0,0,0,16};
        
        Assert.That(resultCol, Is.EqualTo(expectedResultCol));

    }
    
    [Test]
    public void TestGetRowOrColAfterMove2()
    {
        // GIVEN
        Board newBoard = new Board();
        
        
        string[] lines = new[]
        {
            "0 0 0 8",      // 
            "2 0 2 0",
            "0 0 0 8",
            "0 4 0 0",
            "R U R"
        };

        // WHEN
        char[,] board = Board.GetField(lines);
        var column = Board.GetColumn(board, 3);     // 0808
        var resultCol = Board.GetRowOrColAfterMove(column, 'D');

        // THEN
        var expectedResultCol = new List<int> {0,0,0,16};
        
        Assert.That(resultCol, Is.EqualTo(expectedResultCol));

    }
    
    [Test]
    public void TestGetRowOrColAfterMove3()
    {
        // GIVEN
        Board newBoard = new Board();
        
        
        string[] lines = new[]
        {
            "0 0 0 8",      // 0, 8, 0, 
            "2 0 2 0",
            "0 0 0 8",
            "0 4 0 4",
            "R U R"
        };

        // WHEN
        char[,] board = Board.GetField(lines);
        var column = Board.GetColumn(board, 3);     // 0808
        var resultCol = Board.GetRowOrColAfterMove(column, 'D');

        // THEN
        var expectedResultCol = new List<int> {0,0,16,4};
        
        Assert.That(resultCol, Is.EqualTo(expectedResultCol));

    }
}   