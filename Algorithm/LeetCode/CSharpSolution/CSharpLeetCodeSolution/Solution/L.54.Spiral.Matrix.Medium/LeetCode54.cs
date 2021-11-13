/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-12-2021 20:23:39
 * LastEditTime: 11-12-2021 20:35:23
 * FilePath: \CSharpLeetCodeSolution\Solution\L.54.Spiral.Matrix.Medium\LeetCode54.cs
 * Description: 
 */

using System.Collections.Generic;
using System.Linq;
namespace ArraySolution
{

    public class LeetCode54
    {
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            var rowLength = matrix.Length;
            var colLength = matrix[0].Length;

            var result = new List<int>();

            var up = 0;
            var left = 0;
            var right = colLength - 1;
            var down = rowLength - 1;

            while (result.Count < rowLength * colLength)
            {

                for (var col = left; col <= right; col++)
                {
                    result.Add(matrix[up][col]);
                }

                for (var row = up + 1; row <= down; row++)
                {
                    result.Add(matrix[row][right]);
                }

                if (up != down)
                {
                    for (var col = right - 1; col >= left; col--)
                    {
                        result.Add(matrix[down][col]);
                    }
                }

                if (left != right)
                {
                    for (var row = down - 1; row > up; row--)
                    {
                        result.Add(matrix[row][left]);
                    }
                }

                left++;
                up++;
                right--;
                down--;
            }

            return result;
        }
    }


}