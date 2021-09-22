/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 09-21-2021 20:35:57
 * LastEditTime: 09-21-2021 20:42:05
 * FilePath: \CSharpLeetCodeSolution\Solution\L.252.Meeting.Rooms.Easy\LeetCode252.cs
 * Description: 
 */

using System;
using System.Linq;
namespace LcArraySolution
{
    public class LeetCode252
    {
        public static bool CanAttendMeetings(int[][] intervals)
        {

            var orderedIntervals = intervals.OrderBy(i => i[0]).ToArray();

            for (int i = 0; i < orderedIntervals.Length - 1; i++)
            {
                if (orderedIntervals[i][1] > orderedIntervals[i + 1][0])
                {
                    return false;
                }
            }
            return true;
        }
    }
}