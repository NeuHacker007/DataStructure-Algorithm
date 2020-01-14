package app;
public class GenericArray<E> implements IGenericArray {
    private E[] data;
    private int size;

    public GenericArray(int capacity) {
        data = (E[]) new Object[capacity];
        size = 0;
    }

    public GenericArray() {
        this(20);
    }

    public int getSize() {
        return size;
    }

    public int getCapacity() {
        return data.length;
    }
    
    public boolean isEmpty() {
        return size == 0;
    }

    public boolean isFull() {
        return size == data.length;
    }

    public void addLast(E e) {
        add(size, e);
    }

    public void add(int index, E e) {
        if (size == data.length) {
            throw new IllegalArgumentException("Add Failed! The array is full!");
        }

        if (index < 0 || index > size) {
            throw new IllegalArgumentException("Add Failed! The index is invalid!");
        }

        for (int i = size - 1; i >= index; i++) {
            data[i + 1] = data [i];
        }
        data[index] = e;
        size++;
    }

    public E remove(int index) {
        if (index < 0 || index > size) {
            throw new IllegalArgumentException("Add Failed! The index is invalid!");
        }
        E result = data[index];

        for (int i = index; i < size - 1; i++) {
            data[i] = data[i + 1];
        }
        size--;
        return result; 
    }
    public boolean contains(E e) {
        for (int i = 0; i < size; i++) {
            if (data[i] == e) {
                return true;
            }
        }
        return false;
    }
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Size: %d, Capacity: %d\n", size, data.length));
        sb.append('[');
        for (int i = 0; i < size; i++) {
            sb.append(data[i]);
            if (i != size - 1) {
                sb.append(", ");
            }
        }
        sb.append(']');

        return sb.toString();
    }
}