/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-29-2021 09:45:40
 * LastEditTime: 11-29-2021 10:05:07
 * FilePath: \CSharpLeetCodeSolution\Solution\L.51.N.Queens.Hard\LeetCode51.cs
 * Description: 
 */

using System.Collections.Generic;
namespace BackTrackSolution
{
    public class LeetCode51
    {
        private static IList<IList<string>> ans = new List<IList<string>>();
        public static IList<IList<string>> SolveNQueens(int n)
        {
            var board = InitBoard(n);
            BackTrack(board, 0);
            return ans;
        }

        private static void BackTrack(string[][] board, int row)
        {
            if (row == board.Length)
            {
                var rows = new List<string>();
                foreach (var item in board)
                {
                    var str = string.Empty;

                    str = string.Join(str, item);
                    rows.Add(str);
                }

                ans.Add(rows);
                return;
            }

            for (int col = 0; col < board.Length; col++)
            {
                if (!IsValid(board, row, col))
                {
                    continue;
                }

                board[row][col] = "Q";

                BackTrack(board, row + 1);

                board[row][col] = ".";
            }
        }

        private static bool IsValid(string[][] board, int row, int col)
        {
            var n = board.Length;

            for (int i = 0; i < n; i++)
            {
                if (board[i][col] == "Q") return false;
            }

            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
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
            var result = new string[n][];

            for (int i = 0; i < n; i++)
            {
                result[i] = new string[n];

                for (int j = 0; j < n; j++)
                {
                    result[i][j] = ".";
                }
            }

            return result;
        }
    }

}