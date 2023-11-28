using Lab_3;

var inputFilePath = Directory.GetCurrentDirectory();
inputFilePath = Directory.GetParent(inputFilePath)!.ToString();
inputFilePath = Directory.GetParent(inputFilePath)!.ToString();
inputFilePath = Directory.GetParent(inputFilePath)!.ToString();
inputFilePath += "/Input/Input1.txt";

var lines = File.ReadAllLines(inputFilePath);


var outputFilePath = Directory.GetCurrentDirectory();
outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
outputFilePath += "/Output/Output1.txt";


var newBoard = new Board(lines);
newBoard.PrintFigure();
newBoard.ProcessFigureSeveralCycles();
char[,] BoardTxt = newBoard.BoardToText();
//Board.BoardTxtToConsole(BoardTxt);
Board.BoardTxtToFile(outputFilePath,BoardTxt);
//newBoard.PrintFigure();




