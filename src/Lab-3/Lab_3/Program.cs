using Lab_3;

var filePath = Directory.GetCurrentDirectory();
filePath = Directory.GetParent(filePath)!.ToString();
filePath = Directory.GetParent(filePath)!.ToString();
filePath = Directory.GetParent(filePath)!.ToString();
filePath += "/Input/Input1.txt";

var lines = File.ReadAllLines(filePath);
var newBoard = new Board();
List<Cell> lands = newBoard.GetLandscapeFromFile(lines);
newBoard.PrintFigureOrLandscapeWithCoordinates(lands);



