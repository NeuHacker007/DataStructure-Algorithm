using System;
namespace MaxHeapHeaplifyDemo {
    public class Maxheap {

        public static void Heaplify (int[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                Heaplify (arr, i);
            }
        }

        //       i = 0                 80
        //       i = 1       20                    40 i = 2  
        //       i = 3    15   18 i = 4   30 i=5        35 i = 6
        //  For this tree total size is 7, 40 is the last parent node, it's index = (7/2) - 1
        //       i = 0                 80
        //       i = 1       20                    40 i = 2  
        // For this tree total size is 3, 80 is the last parent node, its index = (3/2) - 1
        // So, for any heap tree and its sub heap tree (a complete binary tree), the last parent node's index is (size / 2) - 1; 
        public static void HeaplifyEnhancement (int[] arr) {
            var lastParentIndex = (arr.Length / 2) - 1;

            for (int i = lastParentIndex; i >= 0; i--) {
                Heaplify (arr, i); 
            }
        }

        private static void Heaplify (int[] arr, int index) {
            // 1. get the larger index

            var largerChildIndex = index;

            var leftChildIndex = index * 2 + 1;
            if (leftChildIndex < arr.Length && arr[leftChildIndex] > arr[largerChildIndex]) {
                largerChildIndex = leftChildIndex;
            }

            var rightChildIndex = index * 2 + 2;
            if (rightChildIndex < arr.Length && arr[rightChildIndex] > arr[largerChildIndex]) {
                largerChildIndex = rightChildIndex;
            }

            // root node's value already great than its children
            if (largerChildIndex == index) return;

            Sawp (arr, index, largerChildIndex);

            Heaplify (arr, largerChildIndex);
        }

        private static void Sawp (int[] arr, int leftIndex, int rightIndex) {
            var temp = arr[rightIndex];
            arr[rightIndex] = arr[leftIndex];
            arr[leftIndex] = temp;
        }
    }
}