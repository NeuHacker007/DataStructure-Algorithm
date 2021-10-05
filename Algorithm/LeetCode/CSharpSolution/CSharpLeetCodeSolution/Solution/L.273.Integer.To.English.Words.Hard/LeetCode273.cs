/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-04-2021 22:14:37
 * LastEditTime: 10-04-2021 22:44:16
 * FilePath: \CSharpLeetCodeSolution\Solution\L.273.Integer.To.English.Words.Hard\LeetCode273.cs
 * Description: 
 */

namespace Solution
{
    //TODO: Add Problem.MD and Solution.MD
    public class LeetCode273
    {

        public static string TwoDigits(int num)
        {
            if (num == 0) return "";

            if (num < 10)
            {

                return OneDigitTranslate(num);
            }
            else if (num < 20)
            {
                return TwoDigitLess20Translate(num);
            }
            else
            {
                int tenner = num / 10;
                int rest = num - tenner * 10;

                if (rest != 0)
                {

                    return TenDigitTranslate(tenner) + " " + OneDigitTranslate(rest);
                }
                else
                {
                    return TenDigitTranslate(tenner);
                }
            }


        }

        public static string ThreeDigits(int num)
        {
            if (num == 0) return "";

            int hundred = num / 100;
            int rest = num - hundred * 100;
            string result = "";

            if (hundred * rest != 0)//101/120
            {
                result = OneDigitTranslate(hundred) + " Hundred " + TwoDigits(rest);
            }
            else if (hundred == 0 && rest != 0) //20
            {
                result = TwoDigits(rest);
            }
            else if (hundred != 0 && rest == 0) // 100
            {
                result = OneDigitTranslate(hundred) + " Hundred";
            }

            return result;
        }

        public static string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            int billion = num / 1000000000;
            int million = (num - billion * 1000000000) / 1000000;
            int thousand = (num - billion * 1000000000 - million * 1000000) / 1000;
            int rest = num - billion * 1000000000 - million * 1000000 - thousand * 1000;

            string result = "";
            if (billion != 0)
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result += " ";
                }
                result += ThreeDigits(billion) + " Billion";
            }

            if (million != 0)
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result += " ";
                }
                result += ThreeDigits(million) + " Million";
            }
            if (thousand != 0)
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result += " ";
                }
                result += ThreeDigits(thousand) + " Thousand";
            }

            if (rest != 0)
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result += " ";
                }
                result += ThreeDigits(rest);
            }

            return result;

        }

        private static string OneDigitTranslate(int num)
        {
            return num switch
            {
                1 => "One",
                2 => "Two",
                3 => "Three",
                4 => "Four",
                5 => "Five",
                6 => "Six",
                7 => "Seven",
                8 => "Eight",
                9 => "Nine",
                _ => ""
            };
        }

        private static string TwoDigitLess20Translate(int num)
        {
            return num switch
            {
                10 => "Ten",
                11 => "Eleven",
                12 => "Twleve",
                13 => "Thirteen",
                14 => "Forteen",
                15 => "Fifteen",
                16 => "Sixteen",
                17 => "Seventeen",
                18 => "Eightteen",
                19 => "Nineteen",
                _ => ""
            };
        }

        private static string TenDigitTranslate(int num)
        {
            return num switch
            {
                2 => "Twenty",
                3 => "Thirty",
                4 => "Forty",
                5 => "Fifty",
                6 => "Sixty",
                7 => "Seventy",
                8 => "Eighty",
                9 => "Ninty",
                _ => ""
            };
        }


    }

}
