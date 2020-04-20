using System.Collections.Generic;
namespace DataStructureAndAlgorithmMosh {
    class Program {
        static void Main (string[] args) {
            LinkedList<Entry> test = new LinkedList<Entry> ();
            test.AddLast (new Entry (1, "Ivan"));
            test.AddLast (new Entry (2, "Eva"));
            test.AddLast (new Entry (3, "KK"));

            foreach (Entry item in test) {
                System.Console.WriteLine (item.key);
            }
        }
    }

    class Entry {
        public int key;
        public string value;

        public Entry (int key, string value) {
            this.key = key;
            this.value = value;
        }
    }
}