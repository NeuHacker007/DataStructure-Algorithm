using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithmMosh.Heap
{
    public class ArrayMaxHeaplify
    {
        public static void MaxHeaplify(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Heaplify(nums, i);
            }

            Console.WriteLine(nums.PrintArray());
        }

        public static void Heaplify(int[] array, int index)
        {
            var largerIndex = index;

            var leftChildIndex = index * 2 + 1;

            if (leftChildIndex < array.Length
                && array[leftChildIndex] > array[largerIndex])
            {
                largerIndex = leftChildIndex;
            }

            var rightChildIndex = index * 2 + 2;

            if (rightChildIndex < array.Length
                && array[rightChildIndex] > array[largerIndex])
            {
                largerIndex = rightChildIndex;
            }

            if (index == largerIndex) return;

            var temp = array[largerIndex];
            array[largerIndex] = array[index];
            array[index] = temp;
            Heaplify(array, largerIndex);
        }
        public static void Heaplify2(int[] array, int index)
        {
            var largerIndex = index;
            while (index != largerIndex)
            {
                var leftChildIndex = index * 2 + 1;

                if (leftChildIndex < array.Length
                    && array[leftChildIndex] > array[largerIndex])
                {
                    largerIndex = leftChildIndex;
                }

                var rightChildIndex = index * 2 + 2;

                if (rightChildIndex < array.Length
                    && array[rightChildIndex] > array[largerIndex])
                {
                    largerIndex = rightChildIndex;
                }

                // if (index == largerIndex) return;

                var temp = array[largerIndex];
                array[largerIndex] = array[index];
                array[index] = temp;
            }

            //  Heaplify(array, largerIndex);
        }

    }
}
