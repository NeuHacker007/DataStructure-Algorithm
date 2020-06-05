using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution
{
    //Given a non-empty list of words, return the k most frequent elements.

    //Your answer should be sorted by frequency from highest to lowest.If two words have the same frequency, then the word with the lower alphabetical order comes first.

    //Example 1:

    //Input: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
    //Output: ["i", "love"]
    //Explanation: "i" and "love" are the two most frequent words.

    //Note that "i" comes before "love" due to a lower alphabetical order.


    //Example 2:


    //Input: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
    //Output: ["the", "is", "sunny", "day"]
    //Explanation: "the", "is", "sunny" and "day" are the four most frequent words,
    //with the number of occurrence being 4, 3, 2 and 1 respectively.

    //Note:


    //You may assume k is always valid, 1 ≤ k ≤ number of unique elements.

    //Input words contain only lowercase letters.


    //Follow up:


    //Try to solve it in O(n log k) time and O(n) extra space.

    public class LeetCode692
    {

        public static IList<string> GetMostFreqKWords(string[] words, int k)
        {
            Dictionary<string, int> record = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!record.ContainsKey(word))
                {
                    record.Add(word, 1);
                }
                else
                {
                    record[word]++;
                }
            }

            var sortedRecord = record.OrderByDescending(r => r.Value).ThenBy(r => r.Key);

            var sortedWords = sortedRecord.Select(r => r.Key).ToList();

            var result = new List<string>();
            for (int i = 0; i < k; i++)
            {
                result.Add(sortedWords[i]);
            }

            return result;
        }
    }
}
