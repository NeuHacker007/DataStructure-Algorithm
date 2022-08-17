/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 08-16-2022 21:00:48
 * LastEditTime: 08-16-2022 21:40:23
 * FilePath: \CSharpLeetCodeSolution\Solution\L.118.Pascal's.Triangle.Easy\Leetcode118.cs
 * Description: 
 */
using System.Collections.Generic;
namespace DPSolution
{
    public class Leetcode118
    {
        public static IList<IList<int>> Generate(int rowNum)
        {
            var result = new List<IList<int>>();
            //1. add the first element 
            result.Add(new List<int>());
            result[0].Add(1);

            for (int row = 1; row < rowNum; row++)
            {
                var curRow = new List<int>();
                var preRow = result[row - 1];
                // First element of the row is always 1
                curRow.Add(1);

                for (int col = 1; col < row; col++)
                {
                    curRow.Add(preRow[col - 1] + preRow[col]);
                }
                // Last element of the row is always 1
                curRow.Add(1);
                result.Add(curRow);
            }
            return result;
        }
    }
}
