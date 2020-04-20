using System;
using System.Collections.Generic;
namespace HashTableDemo {
    /*
        Chaining solution is particularly to solve hash collision issue.
        The basic idea is that 
            We designed our array to store a linked list in each cell 
            if collision found, then we add an item in the corresponding linked list 
    */
    public class HashTableChainingSolution {

        private LinkedList<Entry>[] entries = new LinkedList<Entry>[5];

        public void Put1 (int k, string value) {
            var index = Hash (k);
            var bucket = entries[index];
            // Here we are not dealing with duplicate key in the linked list. 
            // the following solution will add multiple duplicate keys in the linked list;
            if (bucket == null) {
                bucket = new LinkedList<Entry> ();
            } else {
                var newEntry = new Entry (k, value);
                bucket.AddLast (newEntry);
            }
        }

        public void Put2 (int key, string value) {
            // var index = Hash (key);
            // if (entries[index] == null) {
            //     entries[index] = new LinkedList<Entry> ();
            // }

            // var bucket = entries[index];
            
            // in this solution, we solve the put1 issue by update the value 
            // in the linked list when their key are same.
            // in C# Hashtable, if duplicate key found it will throw an exception

            // // O(n)
            // foreach (var item in bucket) {
            //     if (item.key == key) {
            //         item.value = value;
            //         return;
            //     }
            // }
            var entry = GetEntry(key);
            if (entry != null) {
                entry.value = value;
                return;
            }
            var bucket = getOrCreateBucket (key);
            // O(1)
            bucket.AddLast (new Entry (key, value));
        }

        public String Get (int key) {

            var entry = GetEntry (key);
            return (entry == null) ? null : entry.value;

            // if (entry == null) return null;

            // return entry.value;

            // var index = Hash (key);
            // var bucket = entries[index];
            // if (bucket != null) {
            //     foreach (var item in bucket) {
            //         if (item.key == key) {
            //             return item.value;
            //         }
            //     }
            // }

            // return null;
        }

        public void Remove (int key) {
            var entry = GetEntry (key);
            if (entry == null) throw new Exception ("Entry not found");

            getBucket (key).Remove (entry);
            // var index = Hash (key);
            // var bucket = entries[index];

            // if (bucket == null) throw new Exception ("Enty is empty");

            // foreach (var item in bucket) {
            //     if (item.key == key) {
            //         bucket.Remove (item);
            //         return;
            //     }
            // }

            // throw new Exception ("Key not found");
        }
        private LinkedList<Entry> getBucket (int key) {
            return entries[Hash (key)];
        }

        private LinkedList<Entry> getOrCreateBucket (int key) {
            var index = Hash (key);
            var bucket = entries[index];

            if (bucket == null) {
                entries[index] = new LinkedList<Entry> ();
            }

            return bucket;
        }

        private Entry GetEntry (int key) {
            var bucket = getBucket (key);
            if (bucket != null) {
                foreach (var item in bucket) {
                    if (item.key == key) {
                        return item;
                    }
                }
            }
            return null;
        }

        private int Hash (int k) {
            return k % entries.Length;
        }
        private class Entry {
            public int key;
            public string value;

            public Entry (int key, string value) {
                this.key = key;
                this.value = value;
            }
        }
    }

}