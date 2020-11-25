
namespace ArrayDemo {
    public interface IArray {
        void RemoveAt (int index);
        void Insert (int num);
        int IndexOf (int num);
        int Max ();
        Array Intersect (Array anotherArray);
        int[] Reverse ();

        void InsertAt (int index, int num);
    }
}