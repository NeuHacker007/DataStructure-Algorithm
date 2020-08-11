using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode953
    {
        //TODO: Logic is not correct, need to be fixed.
        public static bool IsAlienSorted(string[] words, string order)
        {
            var index = new int[26];

            for (int i = 0; i < order.Length; ++i)
            {
                index[order[i] - 'a'] = i;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];

                var word2 = words[i + 1];

                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        if (index[word1[j] - 'a'] < index[word2[j] - 'a'])
                        {
                            return false;
                        }
                    }

                    break;
                }

                if (word1.Length > word2.Length)
                {
                    return false;
                }

            }

            return false;
        }
    }
}
