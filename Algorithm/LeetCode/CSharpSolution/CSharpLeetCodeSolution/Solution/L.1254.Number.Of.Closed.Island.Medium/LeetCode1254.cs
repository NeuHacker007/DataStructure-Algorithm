
namespace DFSSolution
{
    public class LeetCode1254
    {
        public static int ClosedIsland(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            for (var row = 0; row < m; row++)
            {
                DFS(grid, row, 0);
                DFS(grid, row, n -1);
            }

            for (var col = 0; col < n; col++)
            {
                DFS(grid, 0, col);
                DFS(grid, m -1, col);
            }

            var res = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        res++;
                        DFS(grid, i, j);
                    }
                }
            }

            return res;
        }


        private static void DFS(int[][] grid, int row, int col)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            if (row < 0 || col < 0 || row >= m || col >= n)
            {
                return;
            }

            if (grid[row][col] == 1)
            {
                return;
            }

            grid[row][col] = 1;

            DFS(grid, row, col +1);
            DFS(grid, row, col -1);
            DFS(grid, row + 1, col);
            DFS(grid, row -1, col);
        }
    }
}
