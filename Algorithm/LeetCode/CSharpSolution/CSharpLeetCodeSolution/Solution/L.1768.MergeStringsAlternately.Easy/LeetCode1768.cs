// Project: Solution
// Author:yfeva
// Date: 04/25/2024 17:04
// Created: 04/25/2024 17:04
// FileName: LeetCode1768.cs
// Description:

using System.Text;

namespace Solution.L._1768.MergeStringsAlternately.Easy;

public class LeetCode1768
{
    public string MergeString(string word1, string word2)
    {
        StringBuilder sb = new StringBuilder();
        int length1 = word1.Length;
        int length2 = word2.Length;
        int p1 = 0;
        int p2 = 0;
        while (p1 < length1 || p2 < length2 )
        {
            if (p1 < length1)
            {
                sb.Append(word1[p1++]);
            }

            if (p2 < length2)
            {
                sb.Append(word2[p2++]);
            }
        }

        return sb.ToString();
    }
}