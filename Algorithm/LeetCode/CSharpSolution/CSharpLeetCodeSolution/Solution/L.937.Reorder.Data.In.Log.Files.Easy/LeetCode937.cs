using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LcStringSolution
{
    public class LeetCode937
    {
        public static string[] ReorderLogFilesWithLinq(string[] logs)
        {
            if (logs.Length == 0) return logs;

            var result = logs.Where(line => !line.Split(" ")[1].All(char.IsDigit))
                .OrderBy(line => line.Substring(line.IndexOf(" ", StringComparison.Ordinal) + 1))
                .ThenBy(line => line.Substring(0, line.IndexOf(" ", StringComparison.Ordinal)))
                .Union(logs.Where(line => line.Split(" ")[1].All(char.IsDigit)))
                .ToList();

            return result.ToArray();
        }
    }
}
