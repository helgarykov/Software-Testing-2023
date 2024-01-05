

using System.Numerics;
using Lab_4F;

var inputFilePath = Directory.GetCurrentDirectory();
inputFilePath = Directory.GetParent(inputFilePath)!.ToString();
inputFilePath = Directory.GetParent(inputFilePath)!.ToString();
inputFilePath = Directory.GetParent(inputFilePath)!.ToString();
inputFilePath += "/Input/Input.txt";

var lines = File.ReadAllLines(inputFilePath); 

Board board = new Board();


char[,] field = Board.GetField(lines);
char[] commands = Board.GetCommands(lines);
var row = Board.GetRow(field, 3);


/*foreach(var number in row){
    Console.Write($"{number} ");
}
Console.WriteLine();


var column = Board.GetColumn(field, 3);
foreach(var number in column){
    Console.WriteLine(number);
}


Console.WriteLine();
var rowAfterMove = Board.GetRowOrColAfterMove(column, 'D');
foreach(var number in rowAfterMove){
     Console.Write($"{number} ");
}*/

Console.WriteLine();
var matrixAfterMove = Board.GetNewField(field, 'R');
Board.PrintField(matrixAfterMove);

