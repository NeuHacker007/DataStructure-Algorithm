using System;
using System.Collections.Generic;
using System.Text;

namespace BackTraceSolution
{
    public class LeetCode79
    {
        public static bool Exist(char[][] board, string word)
        {

            var rowLength = board.Length;
            var colLength = board[0].Length;

            bool[][] visited = new bool[rowLength][];

            for (int i = 0; i < rowLength; i++)
            {
                visited[i] = new bool[colLength];
            }

            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                for (int colIndex = 0; colIndex < colLength; colIndex++)
                {

                    if (word[0] == board[rowIndex][colIndex])
                    {
                        if (Helper(board,rowIndex,colIndex,word,0, visited)) return true; 
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board">传入棋盘</param>
        /// <param name="rowIndex">当前的行位置</param>
        /// <param name="colIndex">当前的列位置</param>
        /// <param name="word">需要查找的单词</param>
        /// <param name="index">当前单词字母的位置</param>
        /// <param name="visited">是否已经访问 (因为同一个字母只能用一次)</param>
        /// <returns></returns>
        private static bool Helper(char[][] board,
            int rowIndex,
            int colIndex,
            string word,
            int index, bool[][] visited)
        {
            if (index == word.Length) return true;
            
            // 超出边界
            if (rowIndex < 0 
                || colIndex < 0 
                || rowIndex >= board.Length 
                || colIndex >= board[0].Length)
            {
                return false;
            }
            // 如果访问过了就不能再访问了
            if (visited[rowIndex][colIndex]) return false;

            // 如果当前值并不等于 当前要找的word 中的字符
            if (board[rowIndex][colIndex] != word[index]) return false;


            visited[rowIndex][colIndex] = true;

            if (
                Helper(board, rowIndex + 1, colIndex, word, index + 1, visited)
                || Helper(board,rowIndex -1, colIndex,word,index + 1, visited)
                || Helper(board,rowIndex, colIndex + 1, word,index + 1, visited)
                || Helper(board,rowIndex, colIndex -1, word, index + 1, visited))
            {
                return true;
            }

            // 撤销选择
            visited[rowIndex][colIndex] = false;
            
            return false;
        }
        
    }
}
