//Task: 
// Create a matrix of natural numbers (not a square one).
// Count the total number of zero elements.
// Take row with the max number of zero elements in the matrix
// and make it as the 1st row in the matrix.
//      
//      1   0   0   3
//      0   2   0   0
//      0   1   2   3

// Variant 1
int[,] matrix = new int[3,4]{  {1,0,0,3},  {0,2,0,0},  {0,1,2,3}   };
int count;
int[] zero_counters = new int[matrix.GetLength(0)];

for(int i = 0; i < matrix.GetLength(0); i++){
    count = 0;
    for(int j = 0; j < matrix.GetLength(1); j++){
        if (matrix[i, j] == 0){
            count++;
            zero_counters[i] = count;
        }
    }
    Console.WriteLine($"row[{i}]:{count}");
}
int max = zero_counters[0];
int max_id = 0;
for(int i = 0; i < zero_counters.GetLength(0); i++){

    if(zero_counters[i] > max){
        max = zero_counters[i];
        max_id = i;
    }
}
Console.WriteLine($"max:{max}");

for(int j = 0; j < matrix.GetLength(1); j++){
    matrix[0, j] = matrix[max_id, j];
}
for(int i = 0; i < matrix.GetLength(0); i++){
    for(int j = 0; j < matrix.GetLength(1); j++){
        Console.Write(matrix[i,j] + " ");
    }
    Console.WriteLine();
}

// Variant 2 (a bit improved)

// int[,] matrix = new int[3,4]{  {1,0,0,3},  {0,2,0,0},  {0,1,2,3}   };
// int count;
// int[] zero_counters = new int[matrix.GetLength(0)];
//
// int max = 0;
// int max_id = 0;
//
// for(int i =0;i<matrix.GetLength(0);i++){
//     count = 0;
//     for(int j=0;j<matrix.GetLength(1);j++){
//         if (matrix[i,j] == 0){
//             count++;
//             zero_counters[i] = count;
//         }
//
//     }
//     if(count>max){
//         max = count;
//         max_id = i;
//     }
//     Console.WriteLine($"row[{i}]:{count}");
// }
//
//
//
// for(int j = 0; j<matrix.GetLength(1);j++){
//     matrix[0,j] = matrix[max_id,j];
// }
// for(int i =0;i<matrix.GetLength(0);i++){
//     for(int j=0;j<matrix.GetLength(1);j++){
//         Console.Write(matrix[i,j]+" ");
//     }
//     Console.WriteLine();
// }




