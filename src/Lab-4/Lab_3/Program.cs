using Lab_3;


var inputFilePath = Directory.GetCurrentDirectory();
inputFilePath = Directory.GetParent(inputFilePath)!.ToString();
inputFilePath = Directory.GetParent(inputFilePath)!.ToString();
inputFilePath = Directory.GetParent(inputFilePath)!.ToString();
inputFilePath += "/Input/Input.txt";

var lines = File.ReadAllLines(inputFilePath);


char[,] GetField(string[] lines)
{
    char[,] field = new char[4, 4];
    for (int i = 0; i < 4; i++)
    {
        var result = lines[i].Split(' ');
        for (int j = 0; j < 4; j++)
        {
            field[i, j] = result[j][0]; 
        }
    }

    return field;
}

char[] GetCommands(string[] lines)
{
    string[] result = lines[4].Split(' '); 
    char[] commands = new char[result.GetLength(0)];
    for (int i = 0; i < commands.Length; i++)
    {
        if ((result[i][0] == 'R' || result[i][0] == 'L' || result[i][0] == 'D' || result[i][0] == 'U'))
        {
            commands[i] = result[i][0];
        }

        else throw new Exception("Invalid command literal");
    }
    return commands;
}

List<int> GetRow(char[,] field, int numOfRow)
{
    List<Int32> row = new List<int>(4);
    
    for (int j = 0; j < field.GetLength(1); j++)
    {
        row.Add(field[numOfRow, j] - '0');
    }
    return row;
}

List<int> GetColumn(char[,] field, int numOfCol)
{
    List<Int32> column = new List<int>(4);
    
    for (int j = 0; j < field.GetLength(0); j++)
    {
        column.Add(field[j, numOfCol] - '0');
    }
    return column;
}

List<int> GetRowOrColAfterMove(List<int> list, char direction)
{
    var result = new List<int>(4);
    if (direction == 'R' || direction =='D')
    {
        for (int i = 0; i < list.Count -1; i++)
        {
            if (!(list[i] == list[i + 1])) 
            {
                result.Add(list[i]);
            }

            else
            {
                result.Add(list[i] * 2);
            }
        }
    }
    else if (direction == 'L' || direction == 'U')
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (!(list[i] == list[i - 1])) 
            {
                result.Add(list[i]);
            }

            else
            {
                result.Add(list[i] * 2);
            }
        }

    }
    else throw new Exception("Invalid literal");

    if (result.Count < 4)
    {
        
    }

    return result;
}


char[,] field = GetField(lines);
char[] commands = GetCommands(lines);
var row = GetRow(field, 3);
foreach(var number in row){
    Console.Write($"{number} ");
}

var column = GetColumn(field, 3);
foreach(var number in column){
    Console.WriteLine(number);
}

var rowAfterMove = GetRowOrColAfterMove(row, 'R');
foreach(var number in rowAfterMove){
    Console.Write($"{number} ");
}


// var outputFilePath = Directory.GetCurrentDirectory();
// outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
// outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
// outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
// outputFilePath += "/Output/Output.txt";






