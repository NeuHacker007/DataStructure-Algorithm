package app;
public interface IGenericArray<E> {
    int getCapacity();
    boolean isEmpty();
    boolean isFull();
    int getSize();
    int search(E e);
    void add(int index, E e);
    E remove(int index);
}