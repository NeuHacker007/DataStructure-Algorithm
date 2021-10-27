/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-27-2021 13:41:03
 * LastEditTime: 10-27-2021 13:46:16
 * FilePath: \CSharpLeetCodeSolution\Solution\L.566.Reshape.The.Matrix.Easy\LeetCode566.cs
 * Description: 
 */
using System.Collections.Generic;
namespace ArraySolution
{
    public class LeetCode566
    {
        public static int[][] ReshapeMatrix(int[][] mat, int r, int c)
        {
            if (mat.Length == 0 || r * c != mat.Length * mat[0].Length)
            {
                return mat;
            }
            var result = new int[r][];
            for (int i = 0; i < r; i++)
            {
                result[i] = new int[c];
            }
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    queue.Enqueue(mat[i][j]);
                }
            }

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    result[i][j] = queue.Dequeue();
                }
            }


            return result;
        }
    }

}
