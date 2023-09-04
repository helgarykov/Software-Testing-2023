using Lab_1;

namespace Lab_1Test;

/// <summary>
/// Class LifeGameTests for testing the functions of Grid and Translator.
/// It tests InputGameTest.txt located in teh Lab_1Test folder.
/// </summary>
public class LifeGameTests
{
    private readonly Grid _originalGrid;
    private readonly string _filePath;
    
 
    public LifeGameTests()
    {
        _filePath = Directory.GetCurrentDirectory();
        _filePath = Directory.GetParent(_filePath)!.ToString();
        _filePath = Directory.GetParent(_filePath)!.ToString();
        _filePath = Directory.GetParent(_filePath)!.ToString();
        _filePath += "/InputGameTest.txt";

        _originalGrid = new Grid(new int[,]
        {
            {0, 1, 0, 0, 0, 0, 1, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 1, 0, 0, 0, 0, 1, 0}
        });
    }

    [Test]
    public void FileExistsTest()
    {
        Assert.That(File.Exists(_filePath));
    }

    [Test]
    public void ReadFieldValues_ReturnsCorrectField()
    {
        // Arrange
        Grid expectedField = _originalGrid;

        // Act
        int[,]? rawGrid = Translator.ReadFieldValues(_filePath);  // Assuming this method returns int[,]
        Grid actualField = new Grid(rawGrid);

        // Assert
        Assert.That(expectedField, Is.EqualTo(actualField)); // This will only work if Grid has an overridden Equals method
    }
    
    [Test]
    public void GetNextGenerationCellState_ReturnsCorrectCell_Inside_3_2()
    {
        // Arrange
        Grid expectedField = _originalGrid;
        
        // Act
        Cell cell = new Cell(3, 2);
        int resultCell = expectedField.GetNextGenerationCellState(cell);
        int expectedCell = 1;
        
        // Assert
        Assert.That(resultCell, Is.EqualTo(expectedCell));
    }
    
    [Test]
    public void GetNextGenerationCellState_ReturnsCorrectCell_Inside_2_2()
    {
        // Arrange
        Grid expectedField = _originalGrid;
        
        // Act
        Cell cell = new Cell(2, 2);
       
        int resultCell = expectedField.GetNextGenerationCellState(cell);
        int expectedCell = 1;
        
        // Assert
        Assert.That(resultCell, Is.EqualTo(expectedCell));
    }
    
    // Four tests that must always fail. They test field border cells.
     [Test]
     public void GetNextGenerationCellState_Fail_BorderCell_0_0()
     {
         // Arrange
         Grid expectedField = _originalGrid;
        
         // Act
         Cell cell = new Cell(0, 0);
       
         int resultCell = expectedField.GetNextGenerationCellState(cell);
         int expectedCell = 0;
        
         // Assert
         Assert.That(resultCell, Is.EqualTo(expectedCell));
     }
     
     [Test]
     public void GetNextGenerationCellState_Fail_BorderCell_0_7()
     {
         // Arrange
         Grid expectedField = _originalGrid;
        
         // Act
         Cell cell = new Cell(0, 7);
       
         int resultCell = expectedField.GetNextGenerationCellState(cell);
         int expectedCell = 0;
        
         // Assert
         Assert.That(resultCell, Is.EqualTo(expectedCell));
     }
     
     [Test]
     public void GetNextGenerationCellState_Fail_BorderCell_4_0()
     {
         // Arrange
         Grid expectedField = _originalGrid;
        
         // Act
         Cell cell = new Cell(4, 0);
       
         int resultCell = expectedField.GetNextGenerationCellState(cell);
         int expectedCell = 0;
        
         // Assert
         Assert.That(resultCell, Is.EqualTo(expectedCell));
     }
     
     [Test]
     public void GetNextGenerationCellState_Fail_BorderCell_4_7()
     {
         // Arrange
         Grid expectedField = _originalGrid;
        
         // Act
         Cell cell = new Cell(4, 7);
       
         int resultCell = expectedField.GetNextGenerationCellState(cell);
         int expectedCell = 0;
        
         // Assert
         Assert.That(resultCell, Is.EqualTo(expectedCell));
     }

     [Test]
     
     // The test below returns correctly if the contents of the expectedObj equals the contents of the resultObj.
     public void GetNextGenerationField_ReturnsCorrect()
     {
         // Arrange
         int[,] expectedField = 
         {
             { 0, 1, 1, 0, 0, 0, 0, 0 },
             { 0, 1, 1, 0, 0, 0, 0, 0 },
             { 0, 1, 1, 1, 0, 0, 0, 0 },
             { 0, 1, 1, 0, 0, 0, 0, 0 },
             { 0, 1, 1, 0, 0, 0, 0, 0 }
         };
         
         // Act
         
         int[,]? resultField = _originalGrid.GetNextGenerationField();
         
         // Assert
         Assert.That(resultField, Is.EqualTo(expectedField));
     }

     [Test]
     public void GetGivenGenerationField_ReturnsCorrectly()
     {
         // Arrange
         int[,] expectedField = 
         {
             { 0, 1, 1, 0, 0, 0, 0, 0 },
             { 0, 1, 1, 0, 0, 0, 0, 0 },
             { 0, 1, 1, 1, 0, 0, 0, 0 },
             { 0, 1, 1, 0, 0, 0, 0, 0 },
             { 0, 1, 1, 0, 0, 0, 0, 0 }
         };
         
         // Act
         
         int[,]? resultField = _originalGrid.GetGivenGenerationField(3);
         
         // Assert
         Assert.That(resultField, Is.EqualTo(expectedField));
         
     }
}


// If a test fails. Read the info on what line in code and file it crashes.
// Then, set a breakpoint 2 line above the one that crashes to read the values
// of the variable in question.
// Right-click on the failed test and choose "Debug test" function. 
// Read the values by stepping in to find the place for the error.