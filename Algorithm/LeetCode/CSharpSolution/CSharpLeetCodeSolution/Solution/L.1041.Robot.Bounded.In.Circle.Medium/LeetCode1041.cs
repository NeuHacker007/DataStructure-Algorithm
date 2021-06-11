/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 06-11-2021 13:33:05
 * LastEditTime: 06-11-2021 13:43:42
 * FilePath: \CSharpLeetCodeSolution\Solution\L.1041.Robot.Bounded.In.Circle.Medium\LeetCode1041.cs
 * Description: 
 */


namespace LcMathSolution
{
    public class LeetCode1041
    {
        public static bool IsRobotBounded(string instructions)
        {
            var directions = new int[4][] {
                new int[] {0, 1}, // north
                new int[] {1, 0}, // easte
                new int[] {0, -1}, // south 
                new int[] {-1, 0} // west
            };

            var x = 0;
            var y = 0;
            var index = 0;

            foreach (var ch in instructions)
            {
                if (ch == 'L')
                {
                    index = (index + 3) % 4;
                }
                else if (ch == 'R')
                {
                    index = (index + 1) % 4;
                }
                else
                {
                    x += directions[index][0];
                    y += directions[index][1];

                }



            }
            return (x == 0 && y == 0) || index != 0;
        }
    }

}