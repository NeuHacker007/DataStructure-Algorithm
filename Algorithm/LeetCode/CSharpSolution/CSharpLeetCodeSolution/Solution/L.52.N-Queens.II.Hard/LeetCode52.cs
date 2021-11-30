/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-29-2021 19:19:15
 * LastEditTime: 11-29-2021 19:34:06
 * FilePath: \CSharpLeetCodeSolution\Solution\L.52.N-Queens.II.Hard\LeetCode52.cs
 * Description: 
 */


namespace BackTrackSolution
{

    public class LeetCode52
    {
        public static int TotalQueens(int n)
        {
            var board = InitBoard(n);
            return BackTrack(board, 0);
        }


        private static int BackTrack(string[][] board, int row)
        {
            if (row == board.Length)
            {
                return 1;
            }
            var possiblePlacements = 0;
            for (int col = 0; col < board[0].Length; col++)
            {
                if (!IsValid(board, row, col)) continue;

                board[row][col] = "Q";

                possiblePlacements += BackTrack(board, row + 1);

                board[row][col] = ".";
            }
            return possiblePlacements;
        }

        private static bool IsValid(string[][] board, int row, int col)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][col] == "Q") return false;
            }

            for (int i = row - 1, j = col + 1; i >= 0 && j < board.Length; i--, j++)
            {
                if (board[i][j] == "Q") return false;
            }

            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i][j] == "Q") return false;
            }

            return true;
        }


        private static string[][] InitBoard(int n)
        {
            var board = new string[n][];

            for (int i = 0; i < n; i++)
            {
                board[i] = new string[n];

                for (int j = 0; j < n; j++)
                {
                    board[i][j] = ".";
                }
            }
            return board;
        }
    }
}
