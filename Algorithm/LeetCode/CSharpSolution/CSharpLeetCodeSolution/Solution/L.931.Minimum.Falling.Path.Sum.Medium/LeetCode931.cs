/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-16-2021 09:19:42
 * LastEditTime: 11-16-2021 09:42:03
 * FilePath: \CSharpLeetCodeSolution\Solution\L.931.Minimum.Falling.Path.Sum.Medium\LeetCode931.cs
 * Description: 
 */

using System;
namespace DPSolution
{

    public class LeetCode931
    {
        static int[][] memo;
        public static int MinFallingPathSum(int[][] matrix)
        {
            var rowLength = matrix.Length;

            memo = new int[rowLength][];
            var res = int.MaxValue;
            for (int i = 0; i < rowLength; i++)
            {
                memo[i] = new int[rowLength];
            }

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    memo[i][j] = 66666;
                }
            }

            for (int col = 0; col < rowLength; col++)
            {
                res = Math.Min(res, DP(matrix, rowLength - 1, col));
            }

            return res;
        }


        private static int DP(int[][] matrix, int rowIndex, int colIndex)
        {
            if (rowIndex < 0
                || colIndex < 0
                || rowIndex >= matrix.Length
                || colIndex >= matrix[0].Length)
            {
                return 999999;
            }

            if (rowIndex == 0)
            {
                return matrix[0][colIndex];
            }

            if (memo[rowIndex][colIndex] != 66666)
            {

                return memo[rowIndex][colIndex];
            }
            else
            {
                memo[rowIndex][colIndex] = matrix[rowIndex][colIndex] + Min(
                    DP(matrix, rowIndex - 1, colIndex),
                    DP(matrix, rowIndex - 1, colIndex - 1),
                    DP(matrix, rowIndex - 1, colIndex + 1)
                );
            }

            return memo[rowIndex][colIndex];
        }

        private static int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }

}