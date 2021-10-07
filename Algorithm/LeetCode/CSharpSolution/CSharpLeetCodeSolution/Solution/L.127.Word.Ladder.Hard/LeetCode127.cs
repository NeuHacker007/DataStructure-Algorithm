/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-06-2021 14:22:09
 * LastEditTime: 10-06-2021 20:45:25
 * FilePath: \CSharpLeetCodeSolution\Solution\L.127.Word.Ladder.Hard\LeetCode127.cs
 * Description: 
 */
using System.Collections.Generic;
using System.Linq;
namespace GraphSolution
{
    //TODO: Add Problem.MD and Solution.MD
    public class LeetCode127
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(beginWord)) return 0;

            Dictionary<string, List<string>> adjacentList = new Dictionary<string, List<string>>();
            var bwlength = beginWord.Length;

            // 1. Build up the adjacent list graph
            foreach (var word in wordList)
            {
                for (int i = 0; i < bwlength; i++)
                {
                    var newWord = word.Substring(0, i) + "*" + word.Substring(i + 1, bwlength - i - 1);

                    if (!adjacentList.ContainsKey(newWord))
                    {
                        adjacentList.Add(newWord, new List<string>());
                    }

                    adjacentList[newWord].Add(word);
                }
            }

            // 2. BFS 
            Queue<Dictionary<string, int>> queue = new Queue<Dictionary<string, int>>();

            queue.Enqueue(new Dictionary<string, int>() { { beginWord, 1 } });

            // 3. No circle - no repeat words 
            Dictionary<string, bool> visited = new Dictionary<string, bool>();

            visited.Add(beginWord, true);

            // 3. Traverse 

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                var word = node.Keys.First();
                var level = node[word];

                for (int i = 0; i < bwlength; i++)
                {
                    var newWord = word.Substring(0, i) + "*" + word.Substring(i + 1, bwlength - i - 1);
                    if (!adjacentList.ContainsKey(newWord)) continue;

                    var adjacentWords = adjacentList[newWord];

                    foreach (var adjacentWord in adjacentWords)
                    {
                        if (adjacentWord.Equals(beginWord))
                        {
                            return level + 1;
                        }
                        if (!visited.ContainsKey(adjacentWord))
                        {
                            visited.Add(adjacentWord, true);
                            queue.Enqueue(new Dictionary<string, int>() { { adjacentWord, level + 1 } });
                        }
                    }
                }
            }
            return 0;
        }
    }
}