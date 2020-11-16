using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Solution
{
    public class LeetCode200
    {
        //Given a 2d grid map of '1's(land) and '0's(water),
        //count the number of islands.An island is surrounded by water and is formed by connecting
        //adjacent lands horizontally or vertically.You may assume all four edges of the grid are
        //all surrounded by water.
        //    Example 1:
        //Input:
        //11110
        //11010
        //11000
        //00000
        //Output: 1
        //Example 2:
        //Input:
        //11000
        //11000
        //00100
        //00011
        //Output: 3


        public static int GetNumsOfIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;

            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            int anwser = 0;

            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        anwser++;
                        Dfs(grid, r, c);
                    }
                }
            }


            return anwser;
        }


        private static void Dfs(char[][] grid, int row, int col)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            if (row < 0 || col < 0 || row >= rowLength || col >= colLength || grid[row][col] == '0') return;

            // make the visited cell to be water. 
            grid[row][col] = '0';


            // down search
            Dfs(grid, row - 1, col);
            // up search 
            Dfs(grid, row + 1, col);
            // left search
            Dfs(grid, row, col - 1);
            // right search
            Dfs(grid, row, col + 1);
        }

    }
}
