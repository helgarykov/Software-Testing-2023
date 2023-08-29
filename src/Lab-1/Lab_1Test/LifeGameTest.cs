using Lab_1;

namespace Lab_1Test;

// If a test fails. Read the info on what line in code and file it crashes.
// Then, set a breakpoint 2 line above the one that crashes to read the values
// of the variable in question.
// Right-click on the failed test and choose "Debug test" function. 
// Read the values by stepping in to find the place for the error.

// [TestFixure]
public class TranslatorTests
{
    public Grid originalGrid;
    public string filePath;
    
 
    public TranslatorTests()
    {
        filePath = Directory.GetCurrentDirectory();
        filePath = (Directory.GetParent(filePath)).ToString();
        filePath = (Directory.GetParent(filePath)).ToString();
        filePath = (Directory.GetParent(filePath)).ToString();
        filePath += "/InputGameTest.txt";

        originalGrid = new Grid(new int[,]
        {
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0}
        });
    }

    [Test]
    public void FileExistsTest()
    {
        Assert.That(File.Exists(filePath));
    }

    [Test]
    public void ReadFieldValues_ReturnsCorrectField()
    {
        // Arrange
        Grid expectedField = originalGrid;
     
        // Act
        Grid actualField = new Grid(Translator.ReadFieldValues(filePath));
        
        // Assert
        Assert.AreEqual(actualField, Is.EqualTo(expectedField));
    }
    
    [Test]
    public void GetNextGenerationCellState_ReturnsCorrectCell_Inside_3_2()
    {
        // Act
        Cell cell = new Cell(3, 2);
       
        int resultCell = Grid.GetNextGenerationCellState(originalGrid, cell);
        int expectedCell = 0;
        
        // Assert
        Assert.That(resultCell, Is.EqualTo(expectedCell));
    }
    
    [Test]
    public void GetNextGenerationCellState_ReturnsCorrectCell_Inside_2_2()
    {
        // Arrange
        string? filePath = "InputGameTest.txt";
        
        int[,]? originalField = Translator.ReadFieldValues(filePath);
        
        // Act
        Grid newGrid = new Grid(originalField);
        Cell cell = new Cell(2, 2);
       
        int resultCell = newGrid.GetNextGenerationCellState(originalField, cell);
        int expectedCell = 1;
        
        // Assert
        Assert.That(resultCell, Is.EqualTo(expectedCell));
    }
    
    // Four tests that must always fail. They test filed border cells.
     [Test]
     public void GetNextGenerationCellState_Fail_BorderCell_0_0()
     {
         // Arrange
         string? filePath = "InputGameTest.txt";
        
         int[,]? originalField = Translator.ReadFieldValues(filePath);
        
         // Act
         Grid newGrid = new Grid(originalField);
         Cell cell = new Cell(0, 0);
       
         int resultCell = newGrid.GetNextGenerationCellState(originalField, cell);
         int expectedCell = 1;
        
         // Assert
         Assert.That(resultCell, Is.Not.EqualTo(expected: expectedCell));
     }
     
     [Test]
     public void GetNextGenerationCellState_Fail_BorderCell_0_7()
     {
         // Arrange
         string? filePath = "InputGameTest.txt";
        
         int[,]? originalField = Translator.ReadFieldValues(filePath);
        
         // Act
         Grid newGrid = new Grid(originalField);
         Cell cell = new Cell(0, 7);
       
         int resultCell = newGrid.GetNextGenerationCellState(originalField, cell);
         int expectedCell = 1;
        
         // Assert
         Assert.That(resultCell, Is.Not.EqualTo(expected: expectedCell));
     }
     
     [Test]
     public void GetNextGenerationCellState_Fail_BorderCell_4_0()
     {
         // Arrange
         string? filePath = "InputGameTest.txt";
        
         int[,]? originalField = Translator.ReadFieldValues(filePath);
        
         // Act
         Grid newGrid = new Grid(originalField);
         Cell cell = new Cell(4, 0);
       
         int resultCell = newGrid.GetNextGenerationCellState(originalField, cell);
         int expectedCell = 1;
        
         // Assert
         Assert.That(resultCell, Is.Not.EqualTo(expected: expectedCell));
     }
     
     [Test]
     public void GetNextGenerationCellState_Fail_BorderCell_4_7()
     {
         // Arrange
         string? filePath = "InputGameTest.txt";
        
         int[,]? originalField = Translator.ReadFieldValues(filePath);
        
         // Act
         Grid newGrid = new Grid(originalField);
         Cell cell = new Cell(4, 7);
       
         int resultCell = newGrid.GetNextGenerationCellState(originalField, cell);
         int expectedCell = 1;
        
         // Assert
         Assert.That(resultCell, Is.Not.EqualTo(expected: expectedCell));
     }

     [Test]
     
     // The test below 
     public void GetNextGenerationField_ReturnsCorrect()
     {
         // Arrange
         // Create a test file with several fields.
         string? filePath = "InputGameTest.txt";

         int[,]? originalField = Translator.ReadFieldValues(filePath);
         
         int[,] expectedField = 
         {
             { 0, 0, 0, 0, 0, 0, 0, 0 },
             { 0, 0, 0, 0, 0, 0, 0, 0 },
             { 0, 1, 1, 1, 0, 0, 0, 0 },
             { 0, 0, 0, 0, 0, 0, 0, 0 },
             { 0, 0, 0, 0, 0, 0, 0, 0 }
         };
         
         // Act
         Grid newGrid = new Grid(originalField);
         
         int[,]? resultField = newGrid.GetNextGenerationField(originalField);
         
         // Assert
         Assert.That(resultField, Is.EqualTo(expectedField));
     }
}