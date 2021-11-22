/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-22-2021 09:34:22
 * LastEditTime: 11-22-2021 09:50:27
 * FilePath: \CSharpLeetCodeSolution\Solution\L.46.Permutations\LeetCode46.cs
 * Description: 
 */

using System.Collections.Generic;
namespace BackTrackSolution
{
    public class LeetCode46
    {
        static IList<IList<int>> result = new List<IList<int>>();
        public static IList<IList<int>> Permutation(int[] nums)
        {
            var track = new List<int>();
            BackTrack(nums, track);
            return result;
        }

        private static void BackTrack(int[] nums, List<int> track)
        {
            if (track.Count == nums.Length)
            {

                result.Add(new List<int>(track));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (track.Contains(nums[i])) continue;
                track.Add(nums[i]);
                BackTrack(nums, track);
                track.RemoveAt(track.Count - 1);
            }
        }
    }
}
