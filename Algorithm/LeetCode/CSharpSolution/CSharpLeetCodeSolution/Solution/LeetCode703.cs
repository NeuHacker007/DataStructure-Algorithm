﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution
{
    //Design a class to find the kth largest element in a stream.Note that it is the kth largest element in the sorted order, not the kth distinct element.

    //Your KthLargest class will have a constructor which accepts an integer k and an integer array nums, which contains initial elements from the stream.For each call to the method KthLargest.add, return the element representing the kth largest element in the stream.

    //Example:

    //int k = 3;
    //int[] arr = [4, 5, 8, 2];
    //KthLargest kthLargest = new KthLargest(3, arr);
    //kthLargest.add(3);   // returns 4
    //kthLargest.add(5);   // returns 5
    //kthLargest.add(10);  // returns 5
    //kthLargest.add(9);   // returns 8
    //kthLargest.add(4);   // returns 8

    public class LeetCode703V1
    {
        List<int> numsList = new List<int>();
        int K;
        public LeetCode703V1(int k, int[] nums)
        {
            this.K = k;

            foreach (var num in nums)
            {
                numsList.Add(num);
            }
        }

        public int Add(int val)
        {
            numsList.Add(val);

            var sorteddList = numsList.OrderByDescending(x => x).ToList();

            return sorteddList[K - 1];
        }
    }

    public class LeetCode703V2
    {

    }
}
