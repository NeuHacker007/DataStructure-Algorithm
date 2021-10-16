using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithmMosh.Heap
{
    public static class ArrayExtend
    {
        public static string PrintArray(this int[] nums)
        {
            var sb = new StringBuilder();
            sb.Append("[");

            for (var i = 0; i < nums.Length; i++)
            {
                sb.Append(nums[i]);

                if (i == nums.Length - 1) break;
                sb.Append(",");
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
    public class HeapSort
    {
        public static void ShowHeapSortAsc(int[] nums)
        {
            var minHeap = new MinHeap<int>(nums.Length);

            foreach (var num in nums)
            {
                minHeap.Add(num);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = minHeap.Remove();
            }

            Console.WriteLine(nums.PrintArray());
        }

        public static void ShowHeapSortDesc(int[] nums)
        {
            var maxHeap = new MaxHeap<int>(nums.Length);


            foreach (var num in nums)
            {
                maxHeap.Add(num);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = maxHeap.Remove();
            }

            Console.WriteLine(nums.PrintArray());
        }
    }
}
