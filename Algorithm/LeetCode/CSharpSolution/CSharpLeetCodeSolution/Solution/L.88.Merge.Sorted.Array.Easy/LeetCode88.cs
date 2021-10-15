/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-14-2021 21:19:37
 * LastEditTime: 10-14-2021 21:47:22
 * FilePath: \CSharpLeetCodeSolution\Solution\L.88.Merge.Sorted.Array.Easy\LeetCode88.cs
 * Description: 
 */

using System.Text;
namespace ArraySolution
{

    public static class ExtendMethod
    {
        public static string PrintArray(this int[] array)
        {
            var sb = new StringBuilder();

            foreach (var item in array)
            {
                sb.Append(item);
                sb.Append(",");
            }

            return sb.ToString().TrimEnd(',');
        }
    }

    public class LeetCode88
    {
        //TODO: Add the Problem MD and Solution MD
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var p1 = m - 1;
            var p2 = n - 1;
            var p = m + n - 1;
            while (p1 > -1 && p2 > -1)
            {

                if (nums1[p1] > nums2[p2])
                {
                    nums1[p--] = nums1[p1--];
                }
                else
                {
                    nums1[p--] = nums2[p2--];
                }
            }

            while (p2 > -1)
            {
                nums1[p--] = nums2[p2--];
            }
            System.Console.WriteLine(nums1.PrintArray());
        }
    }
}
