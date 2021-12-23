/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 12-14-2021 13:30:13
 * LastEditTime: 12-14-2021 13:30:14
 * FilePath: \CSharpLeetCodeSolution\Solution\L.48.Rotate.Image.Medium\LeetCode48.cs
 * Description: 
 */


namespace Array2DLoopSolution {
    public class LeetCode48
    {
        public static void Rotate(int[][] matrix)
        {
            DiagnalReverse(matrix);
            ReverseRest(matrix);
        }

        private static void DiagnalReverse(int[][] matrix)
        {
            var n = matrix.Length;
            for (var i = 0; i < n; i++)
            {
                for (var j = i; j < n; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

        private static void ReverseRest(int[][] matrix)
        {
            var n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n/2; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = temp;
                }
            }
        }
    }
}

