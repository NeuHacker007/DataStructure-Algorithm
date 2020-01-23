package app;
public class GArray<E> implements IGArray<E> {
    private E[] data;
    private int size;

    public GArray(int capacity) {
        data = (E[]) new Object[capacity];
        size = 0;
    }

    public GArray() {
        this(20);
    }
    public E get(int index) {
        if (index < 0 || index >= size) {
            throw new IllegalArgumentException("Get failed! index invalid");
        }
        return data[index];
    }

    public void set(int index, E e) {
        if (index < 0 || index >= size) {
            throw new IllegalArgumentException("Get failed! index invalid");
        }
        data[index] = e;
    }

    public E getFirst() {
        return get(0);
    }

    public E getLast() {
        return get(size - 1);
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
            // throw new IllegalArgumentException("Add Failed! The array is full!");
            this.resize(2 * data.length);
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
        if (index < 0 || index >= size) {
            throw new IllegalArgumentException("Add Failed! The index is invalid!");
        }
        E result = data[index];

        for (int i = index; i < size - 1; i++) {
            data[i] = data[i + 1];
        }
        size--;
        data[size] = null;
        if (size == data.length / 4 && data.length / 2 != 0) {
            this.resize(data.length / 2);
        }
        return result; 
    }

    public E removeLast() {
        return remove(size - 1);
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

    private void resize(int newCapacity) {
        E[] newData = (E[]) new Object[newCapacity];
        for (int i = 0; i < size; i++) {
            newData[i] = data[i];
        }
        data = newData;
    }
}