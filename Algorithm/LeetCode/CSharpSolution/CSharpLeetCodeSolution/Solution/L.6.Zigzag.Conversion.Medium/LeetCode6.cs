// 
// Project: Solution
// Author:yifan zhang
// Date: 08/17/2022 8:57 PM
// Created: 08/17/2022 8:57 PM
// FileName: LeetCode6.cs
// Description:
using System;
using System.Collections.Generic;
using System.Text;
namespace Solution;

public class LeetCode6
{
    public static string Convert(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }

        var rows = new List<StringBuilder>();

        for (var i = 0; i < Math.Min(numRows, s.Length); i++)
        {
            rows.Add(new StringBuilder());
        }

        var curRow = 0;
        var isGoingDown = false;


        foreach (var ch in s)
        {
            rows[curRow].Append(ch);

            if (curRow == 0 || curRow == numRows - 1)
            {
                isGoingDown = !isGoingDown;
            }

            curRow += isGoingDown ? 1 : -1;
        }

        var sb = new StringBuilder();

        foreach (StringBuilder row in rows)
        {
            sb.Append(row);
        }

        Console.WriteLine(sb.ToString());
        return sb.ToString();
    }
}