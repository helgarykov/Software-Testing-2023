//Task: See the picture for the task description.

int[,] matrix = new int[5, 5];
for (int i = 0; i < matrix.GetLength(0); i++)
{
    Console.WriteLine();
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = i * 10 + j;
        Console.Write( " " + matrix[i, j]);
    }
}

Console.WriteLine();

// Filling in the right upper half of the matrix
for (int i = 0; i < matrix.GetLength(0); i++)
{
    Console.WriteLine();
    // if row nr is even, we move from right to left  
    if ((i % 2 == 0))       // if (flag)
    {
        for (int j = matrix.GetLength(1) - 1; j > i; j--)
        {
            Console.Write( " " + matrix[i, j]);
        }
    }
    else
    {
        for (int j = i + 1; j < matrix.GetLength(1); j++)
        {
            Console.Write( " " + matrix[i, j]);
        }    
    }
}
// Filling in the left bottom half of the matrix
for (int i = 0; i < matrix.GetLength(0); i++)
{
    Console.WriteLine();
    // if row nr is even, we move from right to left  
    if (i % 2 == 0)
    {
        for (int j = 0; j < i; j++)
        {
            Console.Write( " " + matrix[i, j]);
        }
    }
    else
    {
        for (int j = i - 1; j >= 0; j--)
        {
            Console.Write( " " + matrix[i, j]);
        }    
    }
}
// Filling in the diagonal
// Var 1
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (i == j)
        { 
            Console.WriteLine(" " + matrix[i, j]);
        }
    }
}

// Var 2: single for-loop
// for (int i = 0; i < matrix.GetLength(0); i++)
// {
//    Console.WriteLine(matrix[i, i]);   
// }


/*// Variant 2: Filling in the matrix without checking for whether the row is odd or even.
for (int i = 0; i < matrix.GetLength(0); i++)
{
    Console.WriteLine();
   
    for (int j = matrix.GetLength(1) - 1; j > i; j--)
    {
        Console.Write( " " + matrix[i, j]);
    }
    Console.WriteLine();
    i++;
    if (i < matrix.GetLength(0))
    {
        for (int j = i + 1; j < matrix.GetLength(1); j++)
        {
            Console.Write( " " + matrix[i, j]);
        }  
    }
}*/
//  TODO : Implement the same logic for the left bottom corner of the matrix and the diagonal.































//int[,] matrix = new int[3,4]{  {1,0,0,3},  {0,2,0,0},  {0,1,2,3}   };





