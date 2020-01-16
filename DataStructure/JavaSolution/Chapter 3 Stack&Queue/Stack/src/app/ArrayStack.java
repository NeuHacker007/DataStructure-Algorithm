package app;

public class ArrayStack<E> implements IStack<E> {
    private GArray<E> array;
    public ArrayStack(int capacity) {
        array = new GArray<E>(20);
    }
   
    public void push(E e) {
        array.addLast(e);
    }

    public E pop() {
        return array.removeLast();
    }

    public E peek() {
        return array.getLast();
    }

    public int getSize() {
        return array.getSize();
    }

    public boolean isEmpty() {
        return array.isEmpty(); 
    }
}