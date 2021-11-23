/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 11-23-2021 15:09:09
 * LastEditTime: 11-23-2021 15:28:48
 * FilePath: \CSharpLeetCodeSolution\Solution\L.34.Find.First.And.Last.Position.Of.Element.In.Sorted.Array.Medium\LeetCode34.cs
 * Description: 
 */
namespace BinarySearchSolution
{
    public class LeetCode34
    {
        public static int[] SearchRange(int[] nums, int target)
        {
            return new int[] { FindLeftBoundary(nums, target), FindRightBoundary(nums, target) };
        }

        private static int FindLeftBoundary(int[] nums, int target)
        {
            // Search range[left, right]
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    right = mid - 1;
                }
            }

            if (left >= nums.Length || nums[left] != target) return -1;

            return left;
        }


        private static int FindRightBoundary(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {

                var mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    left = mid + 1;
                }
            }

            if (right < 0 || nums[right] != target) return -1;

            return right;

        }
    }
}