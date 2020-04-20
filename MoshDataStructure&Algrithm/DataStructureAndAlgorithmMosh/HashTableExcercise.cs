using System;
using System.Collections;
using System.Collections.Generic;
namespace HashTableExcercises {

    public class HashTableExcercise {

        //  o(n)
        public static int FindMostRepeatedEle (int[] array) {
            if (array.Length == 0) throw new Exception ("Array is empty");

            Hashtable table = new Hashtable ();
            // (O(n))
            foreach (var item in array) {
                if (table.ContainsKey (item)) {
                    table[item] = (int) table[item] + 1;
                } else {
                    table.Add (item, 1);
                }
            }
            var max = int.MinValue;
            var result = int.MinValue;

            // (O(n))
            foreach (var key in table.Keys) {
                if (((int) table[key]) > max) {
                    max = (int) table[key];
                    result = (int) key;
                }

            }
            return result;
        }
        public static int[] TwoSum () {
            return new int[5];
        }

        public static int CountPairsWithKDiff (int[] array, int k) {

            HashSet<int> set = new HashSet<int> ();

            foreach (var item in array) {
                set.Add (item);
            }
            int count = 0;
            foreach (var item in array) {
                if (set.Contains (item + k)) {
                    count++;
                }
            }
            return count;
        }

        public static int CountPairsWithKDiffByMosh (int[] array, int k) {
            HashSet<int> set = new HashSet<int> ();

            foreach (var item in array) {
                set.Add (item);
            }

            int count = 0;
            foreach (var item in array) {
                if (set.Contains (item + k)) {
                    count++;
                }
                if (set.Contains (item - k)) {
                    count++;
                }
                set.Remove (item);
            }
            return count;
        }
    }
}