// Project: Solution
// Author:yfeva
// Date: 04/30/2024 20:04
// Created: 04/30/2024 20:04
// FileName: LeetCode125.cs
// Description:

namespace Solution.L._125.ValidPalinarome.Easy;

public class LeetCode125
{
    public static bool IsPalindrome(string s)
    {
        int start = 0;
        int end = s.Length - 1;

        while (start < end)
        {
            while (start < end && !char.IsLetterOrDigit(s[start]))
            {
                start++;
            }

            while (start < end && !char.IsLetterOrDigit(s[end]))
            {
                end--;
            }

            if (char.ToLower(s[start]) != char.ToLower(s[end]))
            {
                return false;
            }
            start++;
            end--;
        }
        return true;
    }
}