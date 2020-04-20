using System;
using System.Collections;
using System.Collections.Generic;
namespace HashTableDemo {
    public class CharacterFinder {
        public static char FindFirstNonRepeatChar (string str) {
            // Hashtable in c#, it cannot store duplicate keys
            // so if we found existing key, we just update its value 

            /*
                
                ** In Hashtable, the key cannot be null, but value can be.
                ** In Hashtable, key objects must be immutable as long as they are used as keys in the Hashtable.
                ** The capacity of a Hashtable is the number of elements that Hashtable can hold.
                ** A hash function is provided by each key object in the Hashtable.
                ** The Hashtable class implements the IDictionary, ICollection, IEnumerable, ISerializable, IDeserializationCallback, and ICloneable interfaces.
                ** In hashtable, you can store elements of the same type and of the different types.
                ** The elements of hashtable that is a key/value pair are stored in DictionaryEntry, so you can also cast the key/value pairs to a DictionaryEntry.
                ** In Hashtable, key must be unique. Duplicate keys are not allowed.

            */
            Hashtable table = new Hashtable ();

            foreach (var item in str) {
                if (table.ContainsKey (item)) {
                    table[item] = (int) table[item] + 1;
                } else {
                    table.Add (item, 1);
                }

            }

            foreach (var item in str) {
                if ((int) table[item] == 1) {
                    return item;
                }
            }

            return char.MinValue;
        }
        public static char FindFirstRepeatChar (string str) {
            HashSet<char> set = new HashSet<char>();

            foreach (var ch in str) {
                if (set.Contains(ch)) return ch;
                set.Add(ch);
            }
            return char.MinValue;
        }
    }
}