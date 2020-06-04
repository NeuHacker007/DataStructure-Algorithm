using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dics = new Dictionary<int, int>();
            dics.Add(1,1);
            dics.Add(2,1);
            dics.Add(3,1);
            dics.Add(4,1);
            dics.Add(5,1);

            Console.WriteLine(dics.Keys.First());

            Console.ReadKey();
        }
    }
}
