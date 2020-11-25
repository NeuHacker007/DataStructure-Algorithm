using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Solution;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode2Tests
    {
        [Test]
        public void AddTwoNumbers_TwoNonEmptyLinkedList_ExpectSumOfValue()
        {
            ListNodeLc2 list1 = new ListNodeLc2(2);
            list1.Next = new ListNodeLc2(4);
            list1.Next.Next = new ListNodeLc2(3);

            ListNodeLc2 list2 = new ListNodeLc2(5);
            list2.Next = new ListNodeLc2(6);
            list2.Next.Next = new ListNodeLc2(4);

            ListNodeLc2 list3 = new ListNodeLc2(7);
            list3.Next = new ListNodeLc2(0);
            list3.Next.Next = new ListNodeLc2(8);

            var result =  LeetCode2.AddTwoNumbers(list1, list2);

            while (result != null || list3 != null)
            {
                Assert.AreEqual(list3.Value, result.Value);
                result = result.Next;
                list3 = list3.Next;
            }
        }
    }
}
