package app;
public interface IGArray<E> {
    int getCapacity();
    boolean isEmpty();
    boolean isFull();
    int getSize();
    E remove(int index);
}