/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 05-12-2021 12:57:47
 * LastEditTime: 05-12-2021 13:08:17
 * FilePath: \CSharpLeetCodeSolution\Solution\L.282.Kill.Process.Medium\LeetCode282.cs
 * Description: 
 */
using System.Collections.Generic;
namespace Solution
{
    public class LeetCode282
    {
        public static IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill)
        {
            var map = new Dictionary<int, IList<int>>();

            for (int i = 0; i < ppid.Count; i++)
            {
                if (ppid[i] > 0)
                {
                    if (map.ContainsKey(ppid[i]))
                    {
                        map[ppid[i]].Add(pid[i]);
                    }
                    else
                    {
                        map.Add(ppid[i], new List<int>() { pid[i] });
                    }
                }
            }

            var res = new List<int>();

            res.Add(kill);
            GetChildren(map, res, kill);
            return res;
        }

        public static void GetChildren(Dictionary<int, IList<int>> map, List<int> res, int kill)
        {
            if (map.ContainsKey(kill))
            {
                foreach (var item in map[kill])
                {
                    res.Add(item);
                    GetChildren(map, res, kill);
                }
            }
        }
    }

}