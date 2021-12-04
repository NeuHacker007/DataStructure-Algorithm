using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSSolution
{
    public class LeetCode1905
    {
        public static int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            var m = grid1.Length;
            var n = grid1[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid1[i][j] == 0 && grid2[i][j] == 1)
                    {
                        DFS(grid2, i, j);
                    }
                }
            }

            var res = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid2[i][j] == 1)
                    {
                        res++;
                        DFS(grid2, i, j);
                    }
                }
            }

            return res;
        }

        private static void DFS(int[][] grid, int row, int col)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            if (row < 0 || col < 0 || row >= m || col >= n || grid[row][col] == 0)
            {
                return;
            }

            grid[row][col] = 0;

            DFS(grid, row, col + 1);
            DFS(grid, row, col -1);
            DFS(grid, row + 1, col);
            DFS(grid, row -1, col);


        }
    }
}
