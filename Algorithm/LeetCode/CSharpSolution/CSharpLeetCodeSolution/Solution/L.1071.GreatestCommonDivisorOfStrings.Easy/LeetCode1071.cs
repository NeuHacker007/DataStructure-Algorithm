// Project: Solution
// Author:yfeva
// Date: 04/26/2024 14:04
// Created: 04/26/2024 14:04
// FileName: LeetCode1071.cs
// Description:

namespace Solution.L._1071.GreatestCommonDivisorOfStrings.Easy;

public class LeetCode1071
{
    public static int GDC(int x, int y)
    {
        if (y == 0)
        {
            return x;
        }
        else
        {
            return GDC(y, x % y);
        }
    }
    public static string GetGDCString(string str1, string str2)
    {
        if (!(str1 + str2).Equals((str2 + str1)))
        {
            return "";
        }

        int gdc = GDC(str1.Length, str2.Length);

        return str1.Substring(0, gdc);
    }
}