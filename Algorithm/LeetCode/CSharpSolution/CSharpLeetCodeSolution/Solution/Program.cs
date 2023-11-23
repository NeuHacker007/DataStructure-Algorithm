using System;
using System.Collections.Generic;
using System.Linq;
using Solution;
using DPSolution;
using Solution.L._18._4Sum.Medium;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new[] { 1000000000, 1000000000, 1000000000, 1000000000 };
            int target = -294967296;
            Console.WriteLine(int.MaxValue);
            LeetCode18.Solution(numbers, target);
        }
    }
}