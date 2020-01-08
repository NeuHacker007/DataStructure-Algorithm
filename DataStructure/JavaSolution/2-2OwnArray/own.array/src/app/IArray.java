package app;
public interface IArray {
    int getCapacity();
    int getSize();
    boolean isEmpty();
    void add(int item);
    int remove(int index);
}