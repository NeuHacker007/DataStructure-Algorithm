/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-05-2021 09:30:42
 * LastEditTime: 10-05-2021 09:36:03
 * FilePath: \CSharpLeetCodeSolution\Solution\L.1710.Maximum.Unit.On.A.Truck.Easy\LeetCode1710.cs
 * Description: 
 */
using System;
using System.Linq;
namespace Solution
{
    public class LeetCode1710
    {
        public static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            //1. order the boxtype by the units held descending 

            var sortedBoxTypes = boxTypes.OrderByDescending(b => b[1]).ToArray();
            int unit = 0;
            foreach (var boxType in sortedBoxTypes)
            {
                int boxCount = Math.Min(truckSize, boxType[0]);
                unit += boxCount * boxType[1]; // calculate the used box and unit;
                truckSize -= boxCount; // reduce the used box.
            }

            return unit;
        }
    }
}