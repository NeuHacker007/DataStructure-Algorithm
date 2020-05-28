using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    class LeetCode535Tests
    {
        [Test]
        [TestCase("https://leetcode.com/problems/design-tinyurl")]
        public void Encode_WhenCalled_ReturnUniqueTinyUrl(string longUrl)
        {
            var result = LeetCode535.Encode(longUrl);

            Assert.That(result, Does.Match("^http://tinyurl.com/[a-zA-Z0-9]{0,6}"));
        }
    }
}
