/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 08-16-2022 21:58:38
 * LastEditTime: 08-16-2022 22:20:46
 * FilePath: \CSharpLeetCodeSolution\Solution\L.119.Pascal's.Triangle.II.Easy\Leetcode119.cs
 * Description: 
 */
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
namespace DPSolution
{
    public static class Extenstion
    {
        public static void PrintResults<T>(this IEnumerable<T> items)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(',', items);

            System.Console.WriteLine(sb.ToString());
        }
    }
    public class Leetcode119
    {
        public static IList<int> Solution1(int rowIndex)
        {
            var resultSets = new List<List<int>>();

            resultSets.Add(new List<int>() { 1 });

            var rowNum = rowIndex + 1;

            for (int row = 1; row < rowNum; row++)
            {
                var curRow = new List<int>();
                var preRow = resultSets[row - 1];

                curRow.Add(1);
                for (int j = 1; j < row; j++)
                {
                    curRow.Add(preRow[j - 1] + preRow[j]);
                }
                curRow.Add(1);

                resultSets.Add(curRow);
            }
            resultSets[rowIndex].PrintResults<int>();
            return resultSets[rowIndex];
        }

        public static IList<int> Solution2(int rowIndex)
        {
            var result = new List<int>(rowIndex + 1) { 1 };

            for (int i = 0; i < rowIndex; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    result[j] = result[j] + result[j - 1];
                }
                result.Add(1);
            }
            result.PrintResults<int>();
            return result;
        }
    }
}
