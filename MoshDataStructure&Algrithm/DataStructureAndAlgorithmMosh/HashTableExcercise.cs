using System;
using System.Collections;
namespace HashTableExcercises {

    public class HashTableExcercise {
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
    }
}