using System;
using System.Collections.Generic;
using System.Text;

namespace Solution {
    public class LeetCode509 {
        public static int GetFibonacciNumBruteForce (int n) {
            if (n < 1) return 0;
            if (n == 1 || n == 2) return 1;

            return GetFibonacciNumBruteForce (n - 1) + GetFibonacciNumBruteForce (n - 2);
        }

        public static int GetFibonacciNumDP (int n) {
            var memo = new int[n + 1];

            for (int i = 0; i < memo.Length; i++) {
                memo[i] = 0;
            }

            return GetFibonacciNum (memo, n);
        }

        private static int GetFibonacciNum (int[] memo, int n) {
            if (n == 1 || n == 2) return 1;

            if (memo[n] != 0) return memo[n];

            memo[n] = GetFibonacciNum (memo, n - 1) + GetFibonacciNum (memo, n - 2);

            return memo[n];
        }

        public static int GetFibonacciNumDPEquation (int n) {
            var dpTable = new int[n + 1];

            dpTable[1] = dpTable[2] = 1;

            for (int i = 3; i <= n; i++) {
                dpTable[i] = dpTable[i - 1] + dpTable[i - 2];
            }

            return dpTable[n];
        }
    }
}