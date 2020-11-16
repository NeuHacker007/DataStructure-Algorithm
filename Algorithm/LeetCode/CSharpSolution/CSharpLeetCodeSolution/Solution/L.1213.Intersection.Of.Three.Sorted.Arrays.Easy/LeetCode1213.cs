using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode1213
    {
        //Given three integer arrays arr1, arr2 and arr3 sorted in strictly increasing order, return a sorted array of only
        //the integers that appeared in all three arrays.



        //    Example 1:

        //Input: arr1 = [1,2,3,4,5], arr2 = [1,2,5,7,9], arr3 = [1,3,4,5,8]
        //Output: [1,5]
        //Explanation: Only 1 and 5 appeared in the three arrays.



        //    Constraints:

        //1 <= arr1.length, arr2.length, arr3.length <= 1000
        //1 <= arr1[i], arr2[i], arr3[i] <= 2000


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
