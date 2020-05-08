using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode1213
    {
        public static IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
        {
            List<int> result = new List<int>();

            HashSet<int> hs1 = new HashSet<int>();
            HashSet<int> hs2 = new HashSet<int>();
            HashSet<int> hs3 = new HashSet<int>();

            foreach (var item in arr1)
            {
                hs1.Add(item);
            }
            foreach (var item in arr2)
            {
                hs2.Add(item);
            }
            foreach (var item in arr3)
            {
                hs3.Add(item);
            }
            foreach (var item in arr1)
            {
                if (hs2.Contains(item) && hs3.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;

        }
    }
}
