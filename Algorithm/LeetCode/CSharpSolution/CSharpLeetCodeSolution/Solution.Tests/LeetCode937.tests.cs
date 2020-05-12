using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode937Tests
    {
        [Test]
        [TestCase(new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" }, new string[] { "let1 art can", "let3 art zero", "let2 own kit dig", "dig1 8 1 5 1", "dig2 3 6" })]
        public void ReorderLogFilesWithLinq_WhenCalled_ReturnAnOrderedLogs(string[] logs, string[] expectedResult)
        {
            var result = LeetCode937.ReorderLogFilesWithLinq(logs);

            Assert.That(result, Is.EquivalentTo(expectedResult));
        }
    }
}
