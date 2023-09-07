using Lab_1;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Lab_1Test;

/// <summary>
/// Class LifeGameTests for testing the functions of Grid and Translator.
/// It tests InputGameTest.txt files located in the Lab_1Test/InputsTest folder.
/// </summary>
public class LifeGameTests
{
    public static IEnumerable<TestCaseData> TestFileAndGridData()
    {
        string basePath = TestContext.CurrentContext.TestDirectory;
        basePath = Directory.GetParent(basePath)!.ToString();
        basePath = Directory.GetParent(basePath)!.ToString();
        basePath = Directory.GetParent(basePath)!.ToString();
        basePath = Directory.GetParent(basePath)!.ToString();
        string relativePath = "Lab_1Test/InputsTest"; // Set the relative path to your InputsTest directory
        string fullPath = Path.Combine(basePath, relativePath);

        // string fullPath1 = Path.Combine(fullPath, "InputGameTest1.txt");
        // string fullPath2 = Path.Combine(fullPath, "InputGameTest2.txt");
        //
        // Console.WriteLine("Full path to file 1: " + fullPath1);
        // Console.WriteLine("Full path to file 2: " + fullPath2);

        yield return new TestCaseData(
            Path.Combine(fullPath, "InputGameTest1.txt"),
            new Grid(new int[,]
            {
                {0, 1, 0, 0, 0, 0, 1, 0},
                {0, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 0, 0, 0},
                {0, 1, 0, 0, 0, 0, 1, 0}
            }),
            new Grid(new int[,]
            {
                {0, 0, 1, 0, 0, 0, 1, 0},
                {0, 0, 1, 0, 0, 0, 1, 0},
                {0, 0, 1, 0, 0, 0, 1, 0},
                {0, 0, 1, 0, 0, 0, 1, 0},
                {0, 0, 1, 0, 0, 0, 1, 0}
            }),
            4
        );

        yield return new TestCaseData(
            Path.Combine(fullPath, "InputGameTest2.txt"),
            new Grid(new int[,]
            {
                {0, 0, 0, 0, 0, 0, 0, 1},
                {0, 0, 1, 0, 0, 0, 1, 0},
                {0, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 1, 0}
            }),
            new Grid(new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 } 
            }),
            2
        );

        yield return new TestCaseData(
            Path.Combine(fullPath, "InputGameTest3.txt"), 
            new Grid(new int[,] 
            { 
                {0, 0, 0, 0, 0, 0, 0, 1},
                {0, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 0, 0, 0},
                {1, 0, 0, 0, 0, 0, 0, 1} 
            }),
            new Grid(new int[,]
            {
                { 0, 0, 1, 0, 0, 0, 0, 1 },
                { 0, 0, 1, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 0, 1 } 
            }),
            3
        );
    }

    public static IEnumerable<TestCaseData> TestCellStateData()
    {
        yield return new TestCaseData(new Grid(new int[,] 
        { 
            {0, 1, 0, 0, 0, 0, 1, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 1, 0, 0, 0, 0, 1, 0} 
        }), new Cell(3,2), 1);

        yield return new TestCaseData(new Grid(new int[,]
        {
            {0, 0, 0, 0, 0, 0, 0, 1},
            {0, 0, 1, 0, 0, 0, 1, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 0}
        }), new Cell(0, 7), 1);
        yield return new TestCaseData(new Grid(new int[,]
        {
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 1, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 1}
        }), new Cell(0, 7), 1);
    }
    

    [Test]
    [TestCaseSource(nameof(TestFileAndGridData))]
    public void FileExistsTest(string filePath, Grid unused1, Grid unused2, int unused3)
    {
        Console.WriteLine("Checking if file exists: " + filePath);
        Assert.IsTrue(File.Exists(filePath), $"File does not exist: (filePath)");
    }
    

    [TestCaseSource(nameof(TestFileAndGridData))]
    public void ReadFieldValues_ReturnsCorrectField(string filePath, Grid expectedField, Grid unused1, int unused2)
    {
        // Act
        int[,]? rawGrid = Translator.ReadFieldValues(filePath);
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist: " + filePath);
            Assert.Fail("File does not exist.");
        }
    
        if (rawGrid == null) 
        {
            Assert.Fail("ReadFieldValues returned null.");
        }
        Grid actualField = new Grid(rawGrid);

        // Assert
        Assert.That(expectedField, Is.EqualTo(actualField));
    }

    [TestCaseSource(nameof(TestCellStateData))]
    public void GetNextGenerationCellState_ReturnsCorrectCell(Grid initialGrid, Cell cell, int expectedCell)
    {
        // Arrange
        Grid expectedField = initialGrid;
        
        // Act
        int resultCell = Grid.GetNextGenerationCellState(expectedField, cell);
        
        // Assert
        Assert.That(resultCell, Is.EqualTo(expectedCell));
    }

    [TestCaseSource(nameof(TestFileAndGridData))]
    public void GetNextGenerationField_ReturnsCorrect(string unused1, Grid initialGrid, Grid expectedNextGenGrid, int unused2)
    {
        // Arrange
        int[,]? expectedField = expectedNextGenGrid.Field;
        
        // Act
        int[,] resultField = Grid.GetNextGenerationField(initialGrid);
        
        // Assert
        Assert.That(expectedField, Is.EqualTo(resultField));
    }

    [TestCaseSource(nameof(TestFileAndGridData))]
    public void GetGivenGenerationField_ReturnsCorrectly(string _, Grid initialGrid, Grid expectedGivenGenGrid,
        int numOfGen)
    {
        // Arrange
        int[,]? expectedField = expectedGivenGenGrid.Field;
        
        // Act
        int[,] resultField = Grid.GetGivenGenerationField(initialGrid, numOfGen);
        
        // Assert
        Assert.That(expectedField, Is.EqualTo(resultField));
    }
}


