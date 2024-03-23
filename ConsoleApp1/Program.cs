using System;
using System.Collections.Generic;
using System.Linq;

class SudokuPuzzleValidator
{
    static void Main(string[] args)
    {
        // Define Sudoku puzzles
        int[][] goodSudoku1 = {
            new int[] {7,8,4,  1,5,9,  3,2,6},
            new int[] {5,3,9,  6,7,2,  8,4,1},
            new int[] {6,1,2,  4,3,8,  7,5,9},
            new int[] {9,2,8,  7,1,5,  4,6,3},
            new int[] {3,5,7,  8,4,6,  1,9,2},
            new int[] {4,6,1,  9,2,3,  5,8,7},
            new int[] {8,7,6,  3,9,4,  2,1,5},
            new int[] {2,4,3,  5,6,1,  9,7,8},
            new int[] {1,9,5,  2,8,7,  6,3,4}
        };

        int[][] goodSudoku2 = {
            new int[] {1,4, 2,3},
            new int[] {3,2, 4,1},
            new int[] {4,1, 3,2},
            new int[] {2,3, 1,4}
        };

        int[][] badSudoku1 =  {
            new int[] {1,2,3, 4,5,6, 7,8,9},
            new int[] {1,2,3, 4,5,6, 7,8,9},
            new int[] {1,2,3, 4,5,6, 7,8,9},
            new int[] {1,2,3, 4,5,6, 7,8,9},
            new int[] {1,2,3, 4,5,6, 7,8,9},
            new int[] {1,2,3, 4,5,6, 7,8,9},
            new int[] {1,2,3, 4,5,6, 7,8,9},
            new int[] {1,2,3, 4,5,6, 7,8,9},
            new int[] {1,2,3, 4,5,6, 7,8,9}
        };

        int[][] badSudoku2 = {
            new int[] {1,2,3,4,5},
            new int[] {1,2,3,4},
            new int[] {1,2,3,4},  
            new int[] {1}
        };

        // Validate Sudoku puzzles
        Console.WriteLine(ValidateSudoku(goodSudoku1)); // Output: True
        Console.WriteLine(ValidateSudoku(goodSudoku2)); // Output: True
        Console.WriteLine(ValidateSudoku(badSudoku1));  // Output: False
        Console.WriteLine(ValidateSudoku(badSudoku2));  // Output: False
    }

    static bool ValidateSudoku(int[][] puzzle)
    {
        int n = puzzle.Length;

        // Check rows and columns
        if (puzzle.Any(row => !IsValid(row, n)) || puzzle.SelectMany(row => row).Distinct().Count() != n)
        {
            return false;
        }

        // Check little squares
        int sqrtN = (int)Math.Sqrt(n);
        return Enumerable.Range(0, sqrtN)
            .All(i => Enumerable.Range(0, sqrtN)
                .All(j => IsValid(puzzle.Skip(i * sqrtN).Take(sqrtN)
                                           .SelectMany(row => row.Skip(j * sqrtN).Take(sqrtN))
                                           .ToArray(), n)));
    }

    static bool IsValid(int[] values, int n)
    {
        return values.OrderBy(x => x).SequenceEqual(Enumerable.Range(1, n));
    }
}
