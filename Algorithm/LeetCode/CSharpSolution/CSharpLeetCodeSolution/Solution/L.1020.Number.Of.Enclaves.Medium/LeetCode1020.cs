using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSSolution
{
    public class LeetCode1020
    {
        public static int NumEnclaves(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            for (int row = 0; row < m; row++)
            {
                DFS(grid, row, 0);
                DFS(grid, row, n -1);
            }

            for (int col = 0; col < n; col++)
            {
                DFS(grid, 0, col);
                DFS(grid, m -1, col);
            }

            var res = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1) res++;
                }
            }

            return res;
        }

        private static void DFS(int[][] grid, int row, int col)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            if (row < 0 || col < 0 || row >= m || col >= n || grid[row][col] == 0) return;

            grid[row][col] = 0;

            DFS(grid, row, col + 1);
            DFS(grid, row, col -1);
            DFS(grid, row + 1, col);
            DFS(grid, row -1, col);

        }

    }
}
