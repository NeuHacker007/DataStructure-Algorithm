/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 02-23-2022 20:54:59
 * LastEditTime: 02-23-2022 22:24:06
 * FilePath: \CSharpLeetCodeSolution\Solution\L.265.Paint.House.II.Hard\LeetCode265.cs
 * Description: 
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPSolution
{
    public class LeetCode265
    {
        /*
        i-1, 0 
             1 
             2      
             3
             4
             k-1
        
        i,   j => the i th room with the color of j

         If i th room painted with color j, 
         then 
         scenario 1: i - 1 th room, MinCost(paint color (0 .. k-1)) and the min cost color is not j; 

         scenario 2:  i - 1 th room, MinCost(paint color (0 .. k-1)) and the min cost color is j, then we need to take the second mincost color to paint. 
          
          dp[i][j]: the minimum cost of painting houses[0..j] ending with the cost[i][j];
        */

        public static int MinCostII(int[][] costs)
        {
            int roomNum = costs.Length;
            int colors = costs[0].Length;

            if (roomNum == 0) return 0;

            int[][] dp = new int[roomNum][];

            for (int i = 0; i < roomNum; i++)
            {
                dp[i] = new int[colors];

                for (int j = 0; j < colors; j++)
                {
                    dp[i][j] = 0;
                }
            }

            int firstMinumumColor = -1;
            int secondMinumumColor = -1;
            for (int i = 0; i < roomNum; i++)
            {
                int firstMinCost = int.MaxValue;
                int secondMinCost = int.MaxValue;

                int firstNewMinColor = 0;
                int secondNewMinColor = 0;

                for (int j = 0; j < colors; j++)
                {
                    if (j == firstMinumumColor)
                    {
                        dp[i][j] = i == 0 ? costs[i][j] : dp[i - 1][secondMinumumColor] + costs[i][j];
                    }
                    else
                    {
                        dp[i][j] = (i == 0) ? costs[i][j] : dp[i - 1][firstMinumumColor] + costs[i][j];
                    }

                    if (dp[i][j] < firstMinCost)
                    {
                        secondMinCost = firstMinCost;
                        secondNewMinColor = firstNewMinColor;
                        firstMinCost = dp[i][j];
                        firstNewMinColor = j;
                    }
                    else if (dp[i][j] < secondMinCost)
                    {
                        secondMinCost = dp[i][j];
                        secondNewMinColor = j;
                    }
                }
                firstMinumumColor = firstNewMinColor;
                secondMinumumColor = secondNewMinColor;

            }
            return dp[roomNum - 1][firstMinumumColor];
        }


        public static int MinCostII_Sort(int[][] costs)
        {
            int numOfRooms = costs.Length;
            int numOfColors = costs[0].Length;
            if (numOfRooms == 0) return 0;
            int[][] dp = new int[numOfRooms][];

            for (int i = 0; i < numOfRooms; i++)
            {
                dp[i] = new int[numOfColors];
                for (int j = 0; j < numOfColors; j++)
                {
                    dp[i][j] = 0;
                }
            }

            for (int j = 0; j < numOfColors; j++)
            {
                dp[0][j] = costs[0][j];
            }
            for (int i = 1; i < numOfRooms; i++)
            {
                List<Tuple<int, int>> temp = new List<Tuple<int, int>>();

                for (int j = 0; j < numOfColors; j++)
                {
                    temp.Add(new Tuple<int, int>(dp[i - 1][j], j));
                }

                temp.Sort((x, y) => { return x.Item1 - y.Item1; });

                for (int j = 0; j < numOfColors; j++)
                {
                    if (j == temp[0].Item2)
                    {
                        dp[i][j] = temp[1].Item1 + costs[i][j];
                    }
                    else
                    {
                        dp[i][j] = temp[0].Item1 + costs[i][j];
                    }
                }
            }

            int result = int.MaxValue;

            for (int i = 0; i < numOfColors; i++)
            {
                result = Math.Min(result, dp[numOfRooms - 1][i]);
            }
            return result;
        }
    }

}