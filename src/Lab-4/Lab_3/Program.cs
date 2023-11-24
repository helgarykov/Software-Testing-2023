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
    char[] commands = new char[result.GetLength(1)];
    for (int i = 0; i < commands.Length; i++)
    {
        if (!(result[i][0] == 'R' || result[i][0] == 'L' || result[i][0] == 'D' || result[i][0] == 'U'))
        {
            commands[i] = result[i][0];
        }

        else throw new Exception("Invalid command literal");
    }
    return commands;
}

GetField(lines);
GetCommands(lines);







// var outputFilePath = Directory.GetCurrentDirectory();
// outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
// outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
// outputFilePath = Directory.GetParent(outputFilePath)!.ToString();
// outputFilePath += "/Output/Output.txt";






