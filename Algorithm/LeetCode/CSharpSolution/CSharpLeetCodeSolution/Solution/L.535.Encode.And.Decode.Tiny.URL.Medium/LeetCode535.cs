using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class LeetCode535
    {
        //    Note: This is a companion problem to the System Design problem: Design TinyURL.

        //        TinyURL is a URL shortening service where you enter a URL such as
        //        https://leetcode.com/problems/design-tinyurl and it returns a short URL such as http://tinyurl.com/4e9iAk.
        //    Design the encode and decode methods for the TinyURL service.There is no restriction on how your encode/decode
        //    algorithm should work. You just need to ensure that a URL can be encoded to a tiny URL and the tiny URL can be decoded
        //    to the original URL.

        private static readonly string baseTinyUrl = "http://tinyurl.com/";
         private static readonly string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
         private static Dictionary<string, string> record = new Dictionary<string, string>();
         private static Random rand = new Random();
         private static string Key = GetRandomKey();


        public static string Encode(string longUrl)
        {
            while (record.ContainsKey(Key))
            {
                Key = GetRandomKey();
            }

            return $"{baseTinyUrl}{Key}";
        }


        public static string Decode(string shortUrl)
        {
            return record[shortUrl.Replace(baseTinyUrl, "")];
        }

        private static string GetRandomKey()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                sb.Append(alphabet[rand.Next(62)]);
            }

            return sb.ToString();
        }

    }
}
