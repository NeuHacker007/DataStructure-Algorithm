package app;
public interface IArray {
    int getCapacity();
    int getSize();
    boolean isEmpty();
    void addLast(int item);
    void add(int index, int item);
    int remove(int index);
}