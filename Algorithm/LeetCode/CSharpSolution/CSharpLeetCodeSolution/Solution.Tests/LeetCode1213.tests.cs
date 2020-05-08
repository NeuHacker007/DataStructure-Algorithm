using NUnit.Framework;
using Solution;

namespace Solution.Tests
{
    [TestFixture]
    public class LeetCode1213Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]

        public void ArraysIntersection_3IntegerArrayWithCommonInteger_ReturnCommonInteger()
        {
            int[] arr1 = new int[] { 1, 2, 3, 4, 5 };
            int[] arr2 = new[] { 1, 2, 5, 7, 9 };
            int[] arr3 = new[] { 1, 3, 4, 5, 8 };


            var result = LeetCode1213.ArraysIntersection(arr1, arr2, arr3);

            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(5));
        }

        [Test]
        public void ArraysIntersection_3IntegerArrayWithoutCommonInteger_ReturnCommonInteger()
        {
            int[] arr1 = new int[] { 1, 2, 3, 4, 5 };
            int[] arr2 = new[] { 6, 7, 8, 9, 10 };
            int[] arr3 = new[] { 11, 12, 13, 14, 15 };


            var result = LeetCode1213.ArraysIntersection(arr1, arr2, arr3);

            Assert.That(result, Is.Empty);
        }
    }
}