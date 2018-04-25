using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[2][];
            matrix[0] = new int[4] { 1, 0, 1, 1 };
            matrix[1] = new int[4] { 0, 1, 0, 1 };
            
            int island = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int columnValue = i;
                    int rowValue = j;
                    
                    if (matrix[i][j] == 1)
                    {
                        // check neighbours 

                        while(CheckColumnValues(matrix, columnValue, j))
                        {
                            columnValue++;
                        }

                        while (NextRowValueisOne(matrix, i, rowValue))
                        {
                            rowValue++;
                        }

                        island++;
                    }

                    j = rowValue;
                }
            }

            Console.WriteLine($"The number of island(s) in the matrix are {island}");
            Console.WriteLine($"{matrix[0][0]}, {matrix[1][0]}");

        }

        static bool NextRowValueisOne(int[][] matrix, int x, int y)
        {
            // check index is not out of bands
            if ((y + 1) < matrix[x].Length && matrix[x][y + 1] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static bool CheckColumnValues(int[][] matrix, int x, int y)
        {
            // check index is not out of bands
            if ((x + 1) < matrix.Length && matrix[x][y] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
