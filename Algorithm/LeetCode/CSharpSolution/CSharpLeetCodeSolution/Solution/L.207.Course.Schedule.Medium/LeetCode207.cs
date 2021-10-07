/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-06-2021 21:11:39
 * LastEditTime: 10-06-2021 21:39:42
 * FilePath: \CSharpLeetCodeSolution\Solution\L.207.Course.Schedule.Medium\LeetCode207.cs
 * Description: 
 */
using System.Collections.Generic;


namespace GraphSolution
{
    //TODO: Add Problem.MD and Solution.MD
    public class LeetCode207
    {
        private static Dictionary<int, bool> visited = new Dictionary<int, bool>();
        private static Dictionary<int, bool> _onPath = new Dictionary<int, bool>();
        private static bool _hasCircle = false;
        public static bool CanFinish(int numCourse, int[][] prerequisites)
        {
            var graph = BuildGraph(numCourse, prerequisites);

            for (var i = 0; i < numCourse; i++)
            {
                Traverse(graph, i);
            }

            return !_hasCircle;
        }

        private static void Traverse(Dictionary<int, List<int>> adjacentList, int s)
        {
            if (_onPath.ContainsKey(s) && _onPath[s])
            {
                _hasCircle = true;
            }

            if (visited.ContainsKey(s) || _hasCircle)
            {
                return;
            }

            _onPath.Add(s, true);
            visited.Add(s, true);

            foreach (int g in adjacentList[s])
            {
                Traverse(adjacentList, g);
            }
            _onPath[s] = false;
        }
        private static Dictionary<int, List<int>> BuildGraph(int numCourse, int[][] prerequisites)
        {

            var adjacentList = new Dictionary<int, List<int>>();
            //1. build adjacent list 
            for (var i = 0; i < numCourse; i++)
            {
                adjacentList.Add(i, new List<int>());
            }

            //2. add edges

            foreach (var prerequisite in prerequisites)
            {
                var from = prerequisite[1];
                var to = prerequisite[0];

                adjacentList[from].Add(to);
            }

            return adjacentList;
        }
    }

}