/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 09-27-2021 21:21:08
 * LastEditTime: 09-27-2021 21:29:45
 * FilePath: \CSharpLeetCodeSolution\Solution\L.253.MeetRooms.II.Medium\LeetCode253.cs
 * Description: 
 */

using System.Linq;
namespace LcTreeSolution
{

    public class LeetCode253
    {
        public static int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;

            int[] startsTime = new int[intervals.Length];
            int[] endsTime = new int[intervals.Length];

            for (var i = 0; i < intervals.Length; i++)
            {
                startsTime[i] = intervals[i][0];
                endsTime[i] = intervals[i][1];
            }

            var sortedStartsTime = startsTime.OrderBy(s => s).ToArray();
            var sortedEndsTime = endsTime.OrderBy(e => e).ToArray();

            var p1 = 0;
            var p2 = 0;
            int usedRoom = 0;
            while (p1 < sortedStartsTime.Length)
            {
                if (sortedStartsTime[p1] >= sortedEndsTime[p2])
                {
                    usedRoom -= 1;
                    p2++;
                }
                usedRoom += 1;
                p1++;
            }

            return usedRoom;
        }
    }

}