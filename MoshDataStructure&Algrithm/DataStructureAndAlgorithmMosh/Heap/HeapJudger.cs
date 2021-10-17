using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataStructureAndAlgorithmMosh.Heap
{
    public class HeapJudger
    {
        public static bool IsMaxHeap<T>(T[] array) 
        {
            if (array.Length == 0)
            {
                return false;
            }
            for (var i = 0; i < array.Length; i++)
            {
                var leftChildIndex = GetLeftChildIndex(i);
                var rightChildIndex = GetRightChildIndex(i);
                if (leftChildIndex >= array.Length || rightChildIndex >= array.Length) break;
                if (IsCurrentLessThanLeftChild(array, i, leftChildIndex)) return false;
                if (IsCurrentLessThanRightChild(array, i, rightChildIndex)) return false;
            }

            return true;
        }

        private static bool IsCurrentLessThanRightChild<T>(T[] array, int i, int rightChildIndex)
        {
            return Comparer<T>.Default.Compare(array[i], array[rightChildIndex]) < 0;
        }

        private static bool IsCurrentLessThanLeftChild<T>(T[] array, int i, int leftChildIndex)
        {
            return Comparer<T>.Default.Compare(array[i], array[leftChildIndex]) < 0;
        }

        private static int GetRightChildIndex(int i)
        {
            return 2 * i + 2;
        }

        private static int GetLeftChildIndex(int i)
        {
            return 2 * i + 1;
        }
    }
}
