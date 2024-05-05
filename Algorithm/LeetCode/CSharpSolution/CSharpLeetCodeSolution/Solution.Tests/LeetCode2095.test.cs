// Project: Solution.Tests
// Author:yfeva
// Date: 05/05/2024 09:05
// Created: 05/05/2024 09:05
// FileName: LeetCode2095.test.cs
// Description:

using NUnit.Framework;
using Solution.L._2095.DeleteTheMiddleNodeOfALinkedList.Medium;

namespace Solution.Tests;

[TestFixture]
public class LeetCode2095_test
{
    [TestCase]
    public void TestLeecode2095()
    {
        var head = new LeetCode2095.LeetCode2095ListNode()
        {
            val = 1, next = new LeetCode2095.LeetCode2095ListNode()
            {
                val = 3, next = new LeetCode2095.LeetCode2095ListNode()
                {
                    val = 4,next = new LeetCode2095.LeetCode2095ListNode()
                    {
                        val = 7, next = new LeetCode2095.LeetCode2095ListNode()
                        {
                            val = 1, next = new LeetCode2095.LeetCode2095ListNode()
                            {
                                val = 2, next = new LeetCode2095.LeetCode2095ListNode()
                                {
                                    val = 6, next = null
                                }
                            }
                        }
                    }
                }
            }
        };
       var result =  LeetCode2095.DeleteMiddle(head);
    }
}