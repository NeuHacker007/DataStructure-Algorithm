/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-17-2022 10:04:42
 * LastEditTime: 01-17-2022 10:15:30
 * FilePath: \CSharpLeetCodeSolution\Solution\L.91.Decode.Ways.Medium\LeetCode91.cs
 * Description: 
 */

namespace DPSolution
{
    public class LeetCode91
    {
        public static int NumDecodings(string s)
        {
            var m = s.Length;

            s = '#' + s;

            int[] dp = new int[m + 1];

            dp[0] = 1;

            dp[1] = s[1] == '0' ? 0 : 1;

            for (int i = 2; i <= m; i++)
            {
                //1. Consider the last one digit
                if (s[i] == '0')
                {
                    // if last digit is '0' the digit before
                    // last digit cannot be great than 3 because
                    // we only 26 letters to map
                    if (s[i - 1] >= '3')
                    {
                        return 0;
                    }
                }
                else
                {
                    dp[i] += dp[i - 1];
                }
                //2. Consider the last two digits

                if (s[i - 1] == '1' && s[i] >= '0' && s[i] <= '9')
                {
                    dp[i] += dp[i - 2];
                }
                else if (s[i - 1] == '2' && s[i] >= '0' && s[i] <= '6')
                {
                    dp[i] += dp[i - 2];
                }



            }
            return dp[m];
        }
    }

}
