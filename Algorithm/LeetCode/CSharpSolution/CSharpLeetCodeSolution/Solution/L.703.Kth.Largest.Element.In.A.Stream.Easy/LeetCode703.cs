using System;
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
        private MaxHeap heap = new MaxHeap();

        private int k;
        private int[] originArr;
        public LeetCode703V2(int k, int[] nums)
        {
            this.k = k;
            originArr = nums;
            foreach (var num in originArr)
            {
                heap.Add(num);
            }
        }

        public int Add(int item)
        { 
            //if (heap.IsEmpty()) throw new Exception("Heap is Empty ");
        
            heap.Add(item);
            List<int> temp = new List<int>();

            for (int i = 0; i < k - 1; i++)
            {
               temp.Add(heap.Remove());
            }

            var result = heap.GetMax();

            foreach (var i in temp)
            {
                heap.Add(i);
            }
            Console.WriteLine(heap);
            return result;
        }

    }

    public class MaxHeap
    {
        private List<int> list;

        public MaxHeap()
        {
            list = new List<int>();
        }


        public void Add(int item)
        {
            list.Add(item);

            BubbleUp();
        }

        public int Remove()
        {
            var removedItem = list[0];
            list[0] = list[list.Count - 1]; 
            list.RemoveAt(list.Count - 1);
            BubbleDown();

            return removedItem;
        }

        public int GetMax()
        {
            return list[0];
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public int GetSize()
        {
            return list.Count;
        }

        private void BubbleDown()
        {
            var index = 0;

            while (index <= list.Count && !IsParentValid(index))
            {
                var largerIndex = GetLargerChildIndex(index);
                list = Swap(index, largerIndex);

                index = largerIndex;
            }
        }

        private void BubbleUp()
        {
            var index = list.Count - 1;
            while (index >= 0 && list[index] > list[GetParentIndex(index)])
            {
                list = Swap(index, GetParentIndex(index));

                index = GetParentIndex(index);
            }

        }

        private int GetLargerChildIndex(int index)
        {
            if (!HasLeftChild(index)) return index;
            if (!HasRightChild(index)) return GetLeftChildIndex(index);

            return GetLeftChildValue(index) > GetRightChildValue(index)
                ? GetLeftChildIndex(index)
                : GetRightChildIndex(index);
        }

        private bool IsParentValid(int index)
        {
            if (!HasLeftChild(index)) return true;

            if (!HasRightChild(index)) return list[index] >= GetLeftChildValue(index);

            return list[index] >= GetLeftChildValue(index) && list[index] >= GetRightChildValue(index);
        }

        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) < list.Count;
        }

        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) < list.Count;
        }

        private int GetLeftChildValue(int index)
        {
            return list[GetLeftChildIndex(index)];
        }

        private int GetRightChildValue(int index)
        {
            return list[GetRightChildIndex(index)];
        }

        private int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private List<int> Swap(int first, int second)
        {
            var temp = list[first];
            list[first] = list[second];
            list[second] = temp;

            return list;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Max[ ");

            foreach (var li in list)
            {
                sb.Append($"{li},");
            }

            sb.Append("]Min");

            return sb.ToString();
        }
    }
}
