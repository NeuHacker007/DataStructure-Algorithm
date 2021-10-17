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
            // int i = 0;
            //var leftChildIndex = 2 * i + 1;
            //var rightChildIndex = 2 * i + 2;
            for (var i = 0; i < array.Length; i++)
            {
                var leftChildIndex = 2 * i + 1;
                var rightChildIndex = 2 * i + 2;
                if (leftChildIndex >= array.Length || rightChildIndex >= array.Length) break;
                if (Comparer<T>.Default.Compare(array[i], array[leftChildIndex]) < 0) return false;
                if (Comparer<T>.Default.Compare(array[i], array[rightChildIndex]) < 0) return false;
            }

            return true;
        }


    }
}
