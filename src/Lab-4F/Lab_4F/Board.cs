namespace Lab_4F;

/// <summary>
/// Note on GetRowOrColAfterMove: если выполняется одинаковое действие многораз,
/// то нужно делать это через цикл — мы ленимся. В данном сличае, мы итеративно
/// сравниваем соседей, значит надо двойной форлуп.
/// </summary>
public class Board
{

    public static char[,] GetField(string[] lines)
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

    public static char[] GetCommands(string[] lines)
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

    public static List<int> GetRow(char[,] field, int numOfRow)
    {
        List<Int32> row = new List<int>(4);

        for (int j = 0; j < field.GetLength(1); j++)
        {
            row.Add(field[numOfRow, j] - '0');
        }

        return row;
    }

    public static List<int> GetColumn(char[,] field, int numOfCol)
    {
        List<Int32> column = new List<int>(4);

        for (int j = 0; j < field.GetLength(0); j++)
        {
            column.Add(field[j, numOfCol] - '0');
        }

        return column;
    }

    public static List<int> GetRowOrColAfterMove(List<int> list, char direction)
    {
        var result = new List<int>(4);

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != 0)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] == list[i])
                    {
                        result.Add(list[i] * 2);
                        list[j] = 0;
                        break;
                    }
                    else if (list[j] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result.Add(list[i]);
                        break;
                    }
                }

                if (i == list.Count - 1)
                {
                    result.Add(list[i]);
                }
            }

        }

        if (result.Count < 4)
        {
            if (direction == 'R' || direction == 'D')
            {
                for (int i = result.Count; i < 4; i++) // Count = 2; 
                {
                    result.Insert(0, 0);
                }

            }
            else if (direction == 'L' || direction == 'U')
            {
                for (int i = result.Count; i < 4; i++) // Count = 2; 
                {
                    result.Add(0);
                }

            }
            else throw new Exception("Invalid ??");

        }

        return result;
        }
    }









