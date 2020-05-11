using System;
namespace MaxHeapHeaplifyDemo {
    public class Maxheap {

        public static void Heaplify (int[] arr) {
            for (int i = 0; i < arr.Length; i++) {
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